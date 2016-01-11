/**************************************************************************************************************

    NAME
	WutheringCommentsEditor.cs

    DESCRIPTION
	A small editor to modify comment definitions. This editor is based on ScintillaNet.
	The choice has been made to operate on text content rather than on file : this allows to have the
	greatest part of the code that can be run from both the VS package and the comment UI test application.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/012/10]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using  System ;
using  System. Collections. Generic ;
using  System. ComponentModel ;
using  System. Data ;
using  System. Drawing ;
using  System. IO ;
using  System. Linq ;
using  System. Text ;
using  System. Threading. Tasks ;
using  System. Windows. Forms ;
using  System. Xml ;

using  Thrak. Types ;
using  Thrak. Xml ;
using  ScintillaNET ;

using  Wuthering ;

namespace Wuthering. WutheringComments
   {
	public partial class WutheringCommentsEditor : Form
	   {
		public string				Filename		{ get ; private set ; }
		/// <summary>
		/// Text to be edited. Will be updated when the user clicks the Save button.
		/// </summary>
		public	string				EditedText		{ get ; private set ; }
		/// <summary>
		/// A boolean flag indicating whether the contents have been modified or not.
		/// </summary>
		public bool				Modified		{ get ; private set ; }

		// Max width in pixels for the line numbers margin
		private int				MaxLineNumberWidth	=  0 ;
		private WutheringCommentsErrorList	ErrorListForm		=  null ;


		/// <summary>
		/// Initializes the editor.
		/// </summary>
		/// <param name="text">Initial text to be edited.</param>
		public WutheringCommentsEditor ( string  filename )
		   {
			InitializeComponent ( ) ;
			Filename	=  filename ;
			EditedText	=  File. ReadAllText ( filename ) ;
			Modified	=  false ;
			Text		=  "Editing : " + filename ;
		    }


		# region Form events
		/// <summary>
		/// Configures editor's appearance.
		/// </summary>
		private void WutheringCommentsEditor_Load ( object sender, EventArgs e )
		   {
			// Edited text contents
			ConfigurationEditor. Text				=  EditedText ;

			// Use the same font and font size for everything
			ConfigurationEditor. Styles [ Style. Default ]. Font	=  "Consolas" ;
			ConfigurationEditor. Styles [ Style. Default ]. Size	=  10 ;

			// Set margin 0 to display right-aligned text (for the line numbers)
			ConfigurationEditor. Margins [0]. Type			=  MarginType. RightText ;

			// And remove the default margin #1 set for the symbols
			ConfigurationEditor. Margins [1]. Width			=  0 ;

			// Tell the editor that no changes have been performed so far
			ConfigurationEditor. SetSavePoint ( ) ;
		    }
		

		/// <summary>
		/// Update line numbers and status bar once the form has been loaded.
		/// </summary>
		private void WutheringCommentsEditor_Shown ( object sender, EventArgs e )
		   {
			ConfigurationEditor. Focus ( ) ;
			ConfigurationEditor. SelectionStart	=  0 ;
			ConfigurationEditor. SelectionEnd	=  0 ;
			UpdateLineNumbers ( 1 ) ;
			UpdateStatusbar ( ) ;

			// Validate the document upon startup
			XmlCommentsDocument		parser	=  new XmlCommentsDocument ( ConfigurationEditor. Text ) ;
			
			if  ( ! parser. IsValid )
				DisplayParseErrors ( parser ) ;
		    }


		/// <summary>
		/// Asks for a confirmation if the contents have been modified but not saved.
		/// </summary>
		private void WutheringCommentsEditor_FormClosing ( object sender, FormClosingEventArgs e )
		   {
			e. Cancel	=  false ;

			if  ( ConfigurationEditor. Modified )
			   {
				DialogResult	status	=  MessageBox. Show ( "Contents have been modified ; do you want to save your changes ?", "Confirmation" ) ;

				if  ( status  ==  DialogResult. OK )
					SaveContents ( ) ;
			    }
		    }
		# endregion


		# region Button events
		/// <summary>
		/// Save editor contents.
		/// </summary>
		private void  SaveButton_Click ( object sender, EventArgs e )
		   {
			SaveContents ( ) ;
		    }


		/// <summary>
		/// Validates xml contents using the xsd definition.
		/// </summary>
		private void ValidateButton_Click ( object sender, EventArgs e )
		   {
			XmlCommentsDocument		parser	=  new XmlCommentsDocument ( ConfigurationEditor. Text ) ;
			
			if  ( parser. IsValid )
				MessageBox. Show ( "Xml contents are valid" ) ;
			else
				DisplayParseErrors ( parser ) ;
		    }


		/// <summary>
		/// Closes the current window.
		/// </summary>
		private void CloseButton_Click ( object sender, EventArgs e )
		   {
			Close ( ) ;
		    }
		# endregion


		# region ScintillaNet events
		/// <summary>
		/// Updates line numbering when lines have been deleted.
		/// </summary>
		private void  ConfigurationEditor_Delete ( object  sender, ModificationEventArgs  e )
		   {
			if  ( e. LinesAdded  !=  0 )
				UpdateLineNumbers ( ConfigurationEditor. LineFromPosition ( e. Position ) ) ;
		    }


		/// <summary>
		/// Updates line numbering when lines have been inserted.
		/// </summary>
		private void  ConfigurationEditor_Insert ( object  sender, ModificationEventArgs  e )
		   {
			if  ( e. LinesAdded  !=  0 )
				UpdateLineNumbers ( ConfigurationEditor. LineFromPosition ( e. Position ) ) ;
		    }
		    

		/// <summary>
		/// Update the status bar when something has changed.
		/// </summary>
		private void ConfigurationEditor_UpdateUI ( object sender, UpdateUIEventArgs e )
		   {
			UpdateStatusbar ( ) ;
		    }
		# endregion


		# region Private methods
		/// <summary>
		/// Displays parsing errors in a modal form.
		/// </summary>
		private void  DisplayParseErrors ( XmlCommentsDocument  parser )
		   {
			if  ( ErrorListForm  ==  null )
				ErrorListForm	=  new WutheringCommentsErrorList ( ) ;

			ErrorListForm. ShowDialog ( parser. ValidationMessages ) ;
		    }


		/// <summary>
		/// Saves the edited contents to the EditedText property and set the Modified member to true.
		/// </summary>
		private void  SaveContents ( )
		   {
			EditedText	=  ConfigurationEditor. Text ;
			File. WriteAllText ( Filename, EditedText ) ;
			Modified	=  false ;

			ConfigurationEditor. SetSavePoint ( ) ;
			UpdateStatusbar ( ) ;
		    }


		/// <summary>
		/// Updates the line numbers margin.
		/// </summary>
		/// <param name="start_line">Index of the starting line to be redisplayed.</param>
		private void  UpdateLineNumbers  ( int  start_line )
		   {
			// Check if margin width needs an adjustment (for example, when jumping from 99 lines to 100)
			int	width		=  ConfigurationEditor. Lines. Count. ToString ( ). Length ;

			if  ( width  !=  MaxLineNumberWidth )
			   {
				MaxLineNumberWidth				=  width ;
				ConfigurationEditor. Margins [0]. Width		= 
					ConfigurationEditor. TextWidth ( Style. LineNumber, "0". Repeat ( width ) ) + 6 ;
			    }

			// Recompute line numbers
			for  ( int  i = start_line; i < ConfigurationEditor. Lines. Count ; i ++ )
			   {
				ConfigurationEditor. Lines [i]. MarginStyle	=  Style. LineNumber ;
				ConfigurationEditor. Lines [i]. MarginText	=  ( i + 1 ). ToString ( ) ;
			    }
		    }


		/// <summary>
		/// Updates information in the status bar.
		/// </summary>
		private void UpdateStatusbar ( )
		   {
			SBLineCount. Text	=  "Lines: " + ConfigurationEditor. Lines. Count. ToString ( ) ;
			SBSize. Text		=  "Size: " + ConfigurationEditor. Text. Length. ToString ( ) ;

			// Current line and column
			int		index		=  ConfigurationEditor.GetColumn ( ConfigurationEditor. CurrentPosition ) ;
			int		line		=  ConfigurationEditor. LineFromPosition ( index ) ;
			int		firstchar	=  ConfigurationEditor. Lines [ line ]. Position ;
			int		column		=  index - firstchar ;

			SBPosition. Text	=  "L" + ( line + 1 ) + " C" + ( column + 1 ) ;

			// Modified flag
			if  ( ConfigurationEditor. Modified )
			   {
				SBModified. Text		=  "*" ;
				SBModified. ToolTipText		=  "Contents have been modified" ;
				SaveButton. Enabled		=  true ;
			    }
			else
			   {
				SBModified. Text		=  "" ;
				SBModified. ToolTipText		=  "" ;
				SaveButton. Enabled		=  false ;
			    }
		    }
		# endregion 
	    }
    }
