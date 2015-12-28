/**************************************************************************************************************

    NAME
	WutheringComments.cs

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
using   System. ComponentModel ;
using	System. ComponentModel. Design ;
using   System. Collections ;
using   System. Collections. Generic ;
using   System. Windows. Forms ;
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
	[PackageRegistration ( UseManagedResourcesOnly = true ) ]
	[InstalledProductRegistration ( "PackageName", "PackageDescription", "1.0", IconResourceID = 400 ) ]
	[ProvideMenuResource ( "Menus.ctmenu", 1 ) ]
	[ProvideOptionPage ( typeof ( WutheringCommentsOptionsPage ), "Wuthering Tools", "Comments", 0, 0, true)]
	[Guid ( Symbols. Guids. PackageGuid ) ]
	public sealed class WutheringCommentsPackage	: Utilities. VsPackage
	   {
		public  WutheringCommentsPackage ( )
		   {
		    }


		/// <summary>
		/// Performs the following :
		/// <list type="-">
		/// <item>Registers the callback for handling the Insertxxx menu items</item>
		/// </list>
		/// </summary>
		protected override void Initialize ( )
		   {
			base. Initialize ( ) ;

			RegisterMenuCommands 
			   ( 
				Symbols. Guids. SourceCommentsMenuGuid, 
				InsertCommentMenuItemCallback,
				new uint [] 
				   { 
					Symbols. Commands. InsertBlockHeaderComment, 
					Symbols. Commands. InsertClassHeaderComment, 
					Symbols. Commands. InsertFileHeaderComment, 
					Symbols. Commands. InsertFunctionHeaderComment, 
					Symbols. Commands. InsertMethodHeaderComment, 
					Symbols. Commands. InsertStandardComment 
				    }  
			     ) ;
		    }


		private void  InsertCommentMenuItemCallback  ( object  sender, EventArgs  e, CommandID  cmd )
		{
			MessageBox ( "Item #" + cmd.ID ) ;
		}

	    }
    }
