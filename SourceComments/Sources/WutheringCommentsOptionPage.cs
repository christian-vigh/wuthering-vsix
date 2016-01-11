/**************************************************************************************************************

    NAME
	CommentsOptionPage.cs

    DESCRIPTION
	Dialog page object for comment options.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/12/09]     [Author : CV]
	Initial version.

 **************************************************************************************************************/
using	System ;
using	System. Globalization ;
using   System. IO ;
using	System. Runtime. InteropServices ;
using	System. ComponentModel ;
using	System. ComponentModel. Design ;
using   System. Collections ;
using   System. Collections. Generic ;
using	System. Windows. Forms ;
using   EnvDTE ;
using	Microsoft. Win32 ;
using	Microsoft. VisualStudio ;
using	Microsoft. VisualStudio. Shell. Interop ;
using	Microsoft. VisualStudio. OLE. Interop ;
using	Microsoft. VisualStudio. Settings ;
using	Microsoft. VisualStudio. Shell. Settings ;
using	Microsoft. VisualStudio. Shell ;
using	VsPackage ;
using	Wuthering. WutheringComments ;


namespace Wuthering. WutheringCommentsPackage
   {
	[ClassInterface ( ClassInterfaceType. AutoDual )]
	[Guid ( "EA8680A0-4D08-4042-BA73-719F76F8A57E" )]
	public class	WutheringCommentsOptionsPage	:  DialogPage
	   {
		# region  Options page settings
		[Category ( "Comments" )]
		[Description ( "Indicates if an external file should be used in place of stock definitions bundled with this package" )]
		public bool		UseCustomFile			{ get ; set ; }

		[Category ( "Comments" )]
		[Description ( "File containing xml comments definitions" )]
		public string		CustomFile			{ get ; set ; }

		[Category ( "Comments" )]
		[Description ( "Number of characters to insert before the start of an embraced construct" )]
		public int		SpacesBeforeEmbracingStart	{ get ; set ; }

		[Category ( "Comments" )]
		[Description ( "Number of characters to insert before the end of an embraced construct" )]
		public int		SpacesBeforeEmbracingStop	{ get ; set ; }
		# endregion

		// Custom dialog page defined as a UserControl
		private WutheringCommentsOptionsPageUI		DialogPage ;


		# region Window() : retrieves a custom options page form
		[Browsable(false)]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility. Hidden )]
		protected override IWin32Window  Window
		   {   
			get   
			   {      
				WutheringCommentsOptionsPageUI	 page	= new WutheringCommentsOptionsPageUI ( this ) ; 
				
				page. Initialize ( ) ;
				DialogPage	=  page ;
				LoadSettings ( ) ;
				
				return ( page ) ;
			    }
		    }
		# endregion

		# region DialogPage events
		/// <summary>
		/// Applies new settings supplied by the user.
		/// </summary>
		protected override void OnApply ( DialogPage. PageApplyEventArgs e )
		   {
			if  ( SaveSettings ( ) )
				base. OnApply ( e ) ;
			else
				e. ApplyBehavior	=  ApplyKind. Cancel ;
		    }


		/// <summary>
		/// Performs some operations when the tools page is displayed.
		/// </summary>
		protected override void OnActivate ( CancelEventArgs e )
		   {
		    }
		# endregion


		# region Support functions
		/// <summary>
		/// Get the xml comments definitions, either from the specified file or from the stock definitions.
		/// </summary>
		public XmlCommentsDocument	GetXmlDefinitions ( )
		   {
			if  ( UseCustomFile )
			   {
				if  ( File. Exists ( CustomFile ) )
				    {
					XmlCommentsDocument		parser	=  new XmlCommentsDocument ( File. ReadAllText ( CustomFile ) ) ;

					if  ( parser. IsValid )
						return ( parser ) ;

					MessageBox. Show ( "The file specified in the Wuthering Tools/Comments options page (\"" +
								CustomFile + "\") contains some errors ; use the built-in tools comment definitions " +
							   "editor to correct the issues.\r\n" +
							   "Standard definitions will be used instead" ) ;
				     }
				else
				    {
					MessageBox. Show ( "The file specified in the Wuthering Tools/Comments options page (\"" +
								CustomFile + "\") does not exist.\r\n" +
							   "Standard definitions will be used instead" ) ;
				     }
			    }
		
			return ( new XmlCommentsDocument ( ) ) ;
		    }


		/// <summary>
		/// Loads settings into the tools option page.
		/// </summary>
		private void  LoadSettings ( )
		   {
			DialogPage. UseCustomFileCheckbox. Checked		=  UseCustomFile ;
			DialogPage. FilenameTextbox. Text			=  CustomFile ;
			DialogPage. EmbracingStartIndentationTextbox. Text	=  SpacesBeforeEmbracingStart. ToString ( ) ;
			DialogPage. EmbracingStopIndentationTextbox. Text	=  SpacesBeforeEmbracingStop. ToString ( ) ;
		    }


		/// <summary>
		/// Saves the wuthering comments settings
		/// </summary>
		private bool  SaveSettings ( )
		   {
			uint		intval ;

			UseCustomFile	=  DialogPage. UseCustomFileCheckbox. Checked ;
			CustomFile	=  DialogPage. FilenameTextbox. Text ;

			if  ( uint. TryParse ( DialogPage. EmbracingStartIndentationTextbox. Text, out intval ) )
				SpacesBeforeEmbracingStart	=  ( int ) intval ;
			else
			   {
				MessageBox. Show ( "Invalid positive integer value \"" + DialogPage. EmbracingStartIndentationTextbox. Text + "\"" ) ;
				DialogPage. EmbracingStartIndentationTextbox. Focus ( ) ;
				DialogPage. EmbracingStartIndentationTextbox. SelectAll ( ) ;

				return ( false ) ;
			    }

			if  ( uint. TryParse ( DialogPage. EmbracingStopIndentationTextbox. Text, out intval ) )
				SpacesBeforeEmbracingStop	=  ( int ) intval ;
			else
			   {
				MessageBox. Show ( "Invalid positive integer value \"" + DialogPage. EmbracingStopIndentationTextbox. Text + "\"" ) ;
				DialogPage. EmbracingStopIndentationTextbox. Focus ( ) ;
				DialogPage. EmbracingStopIndentationTextbox. SelectAll ( ) ;

				return ( false ) ;
			    }

			return ( true ) ;
		    }
		# endregion
	    }
    }
