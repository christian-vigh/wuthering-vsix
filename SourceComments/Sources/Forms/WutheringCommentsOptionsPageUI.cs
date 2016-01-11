using	System ;
using	System. Collections. Generic ;
using	System. ComponentModel ;
using	System. Drawing ;
using	System. Data ;
using   System. IO ;
using	System. Linq ;
using	System. Text ;
using	System. Threading. Tasks ;
using	System. Windows. Forms ;

using	Wuthering. WutheringComments ;


namespace Wuthering. WutheringCommentsPackage
   {
	public partial class WutheringCommentsOptionsPageUI : UserControl
	   {
		// Since we use a user control for displaying the options page, we need to have a reference
		// to the underlying DialogPage object
		public WutheringCommentsOptionsPage	OptionsPage ;


		/// <summary>
		/// Initialize the tools options page.
		/// </summary>
		public WutheringCommentsOptionsPageUI ( WutheringCommentsOptionsPage  page )
		   {
			InitializeComponent ( ) ;
			OptionsPage	=  page ;
		    }


		/// <summary>
		/// Last-chance UI adjustments before the very first display of the options page
		/// </summary>
		public void  Initialize()  
		   {      
			FilenameTextbox. Text			=  OptionsPage. CustomFile ;
			EmbracingStartIndentationTextbox. Text	=  OptionsPage. SpacesBeforeEmbracingStart. ToString ( ) ;
			EmbracingStopIndentationTextbox. Text	=  OptionsPage. SpacesBeforeEmbracingStop. ToString ( ) ;

			UseCustomFileCheckbox. Checked		=  OptionsPage. UseCustomFile ;
			UseCustomFileCheckbox. Focus ( ) ;
		    }

		
		/// <summary>
		/// Changes the ui state whenever the "Use custom file" checkbox is checked or unchecked.
		/// </summary>
		private void UseCustomFileCheckbox_CheckedChanged ( object sender, EventArgs e )
		   {
			ChangeUIState ( ) ;
			LoadDefinitions ( ) ;
		    }


		/// <summary>
		/// Opens a new definitions file without opening it, unless the "Use custom file" checkbox
		/// is checked.
		/// </summary>
		private void  FileOpenButton_Click  ( object  sender, EventArgs  e )
		   {
			FileOpenDialog. Title	=  "Load an external definitions file" ;

			if  ( FileOpenDialog. ShowDialog ( )  ==  DialogResult. OK )
			   { 
				SetFile ( FileOpenDialog. FileName ) ;
				ChangeUIState ( ) ;
			    }
		    }


		/// <summary>
		/// Generates a definitions file from stock definitions.
		/// </summary>
		private void  GenerateButton_Click  ( object  sender, EventArgs  e )
		   {
			FileSaveDialog. Title	=  "Save embedded definitions to external file" ;

			if  ( FileSaveDialog. ShowDialog ( )  ==  DialogResult. OK )
			   {
				SaveToFile ( FileSaveDialog. FileName, XmlCommentsDocument. StockDefinitions ) ;
				ChangeUIState ( ) ;
				MessageBox. Show ( "Embedded definitions saved" ) ;
			    }
		    }


		/// <summary>
		/// Edits the comments definitions file.
		/// </summary>
		private void  EditButton_Click  ( object  sender, EventArgs  e )
		   {
			if  ( String. IsNullOrWhiteSpace ( FilenameTextbox. Text ) )
			   {
				if  ( MessageBox. Show ( "You can only edit comment definitions coming from an external file " +
							 "but none has been specified so far; do you want to generate one from embedded definitions ?", 
							 "Question",
							 MessageBoxButtons. YesNo )  ==  DialogResult. No )
					return ;

					GenerateButton_Click ( null, null ) ;
			    }

			WutheringCommentsEditor		editor		=  new WutheringCommentsEditor ( FilenameTextbox. Text ) ;

			editor. ShowDialog ( ) ;
			LoadDefinitions ( ) ;
		    }


		/// <summary>
		/// Saves specified definitions contents to the specified output file.
		/// </summary>
		private void  SaveToFile ( string  filename, string  contents )
		   {
			File. WriteAllText ( filename, contents ) ;
			SetFile ( FileSaveDialog. FileName ) ;
		    }


		/// <summary>
		/// Sets the current definitions file.
		/// </summary>
		private void  SetFile ( string  filename )
		   {
			OptionsPage. CustomFile			=  
			FilenameTextbox. Text			=  FileSaveDialog. FileName ;
		    }


		/// <summary>
		/// Loads the definitions from the currently specified filename.
		/// </summary>
		private void  LoadDefinitions ( )
		   {
			WutheringCommentsPackage. XmlComments	=  OptionsPage. GetXmlDefinitions ( ) ;
			UseCustomFileCheckbox. Checked		=  true ;
		    }


		/// <summary>
		/// Changes the UI state according to the "Use custom 
		/// </summary>
		private void  ChangeUIState ( )
		   {
			OptionsPage. UseCustomFile	=  UseCustomFileCheckbox. Checked ;

			if  ( UseCustomFileCheckbox. Checked )
			   {
				FilenameTextbox. Enabled		=  true ;

				if  ( File. Exists ( FilenameTextbox.Text ) )
					FilenameTextbox. ForeColor	=  Color. Black ;
				else
					FilenameTextbox. ForeColor	=  Color. Red ;
			    }
			else
			   { 
				FilenameTextbox. Enabled		=  false ;

				if  ( File. Exists ( FilenameTextbox.Text ) )
					FilenameTextbox. ForeColor	=  Color. Gray ;
				else
					FilenameTextbox. ForeColor	=  Color. DarkRed ;				
			    }
		    }
	    }
    }
