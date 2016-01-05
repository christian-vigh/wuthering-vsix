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
using	Utilities ;
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
		public bool		UseCustomFile		{ get ; set ; }

		[Category ( "Comments" )]
		[Description ( "File containing xml comments definitions" )]
		public string		CustomFile		{ get ; set ; }

		[Category ( "Comments" )]
		[Description ( "Last know modification time of external xml comments file" )]
		public DateTime		LastUpdate		{ get ; set ; }
		# endregion

		# region Window() : retrieves a custom options page form
		[Browsable(false)]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility. Hidden )]
		protected override IWin32Window  Window
		   {   
			get   
			   {      
				WutheringCommentsOptionsPageUI	 page	= new WutheringCommentsOptionsPageUI ( this ) ; 
				
				page. Initialize ( ) ;
				
				return ( page ) ;
			    }
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
					XmlCommentsDocument		parser	=  new XmlCommentsDocument ( ConfigurationEditor. Text ) ;

					if  ( parser. IsValid )
						return ( parser ) ;

					MessageBox. Show ( "The file specified in the Wuthering Tools/Comments options page (\"" +
								CustomFile + "\" contains some errors ; use the built-in tools comment definitions " +
							   "editor to correct the issues.\r\n" +
							   "Standard definitions will be used instead" ) ;
				     }
				else
				    {
					MessageBox. Show ( "The file specified in the Wuthering Tools/Comments options page (\"" +
								CustomFile + "\" does not exist.\r\n" +
							   "Standard definitions will be used instead" ) ;
				     }
			    }

			return ( new XmlCommentsDocument ( ) ) ;
		    }
		# endregion
	    }
    }
