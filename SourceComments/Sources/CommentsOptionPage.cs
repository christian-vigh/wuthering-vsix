/**************************************************************************************************************

    NAME
	CommentsOptionPage.cs

    DESCRIPTION
	A VSIX package to handle customized comments insertions.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/12/09]     [Author : CV]
	Initial version.

 **************************************************************************************************************/
using	System ;
using	System. Globalization ;
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
		
		public string		ExampleString		{ get ; set ; }

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


	    }
    }
