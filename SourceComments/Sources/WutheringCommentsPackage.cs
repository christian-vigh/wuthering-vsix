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
using	System. IO ;
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
	using	WindowActivatedEventHandler	=  _dispWindowEvents_WindowActivatedEventHandler ;


	[PackageRegistration ( UseManagedResourcesOnly = true ) ]
	[InstalledProductRegistration ( "Wuthering Tools", "A set of personal VS tools", "1.0", IconResourceID = 400 ) ]
	[ProvideMenuResource ( "Menus.ctmenu", 1 ) ]
	[ProvideAutoLoad ( UIContextGuids80. NoSolution ) ]
	[ProvideAutoLoad ( UIContextGuids80. SolutionExists ) ]
	[ProvideOptionPage ( typeof ( WutheringCommentsOptionsPage ), "Wuthering Tools", "Comments", 0, 0, true )]
	[ProvideProfile ( typeof ( WutheringCommentsOptionsPage ), "Wuthering Tools", "Comments", 0, 0, true )]
	[Guid ( Symbols. Guids. PackageGuid ) ]
	public sealed class WutheringCommentsPackage	: Utilities. VsPackage
	   {
		// Visual Studio DTE object
		private		DTE				EnvDTE ;
		// Options page settings
		private		WutheringCommentsOptionsPage	CommentsOptionsPage ;
		// Currently active xml comment definitions document
		internal	XmlCommentsDocument		XmlComments ;
		

		public  WutheringCommentsPackage ( )
		   { }


		# region Initializations
		/// <summary>
		/// Performs the following :
		/// <list type="-">
		/// <item>Registers the callback for handling the Insertxxx menu items</item>
		/// </list>
		/// </summary>
		protected override void Initialize ( )
		   {
			base. Initialize ( ) ;

			// Register commands as a "Comments" submenu in the "Edit" menu
			RegisterMenuCommands 
			   ( 
				Symbols. Guids. SourceCommentsMenuGuid, 
				OnInsertComment,
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

			// Get the DTE object
			EnvDTE	=  GetDTE ( ) ;	

			// Get the comments options page
			CommentsOptionsPage	=  GetDialogPage<WutheringCommentsOptionsPage> ( ) ;
			XmlComments		=  CommentsOptionsPage. GetXmlDefinitions ( ) ;

			// Install event handlers
			MessageBox ( "initialize" ) ;

			WindowEvents	winevents	=  EnvDTE. Events. get_WindowEvents ( ) ;

			EnvDTE. Events. WindowEvents. WindowActivated	+=  new WindowActivatedEventHandler ( OnWindowActivated ) ;
		    }
		# endregion

		# region Event handlers
		/// <summary>
		/// Handles the state of the Edit/Comments menu : hidden if currently activated window is a document
		/// with an unsupported extension or is not a document at all, visible otherwise.
		/// </summary>
		private void  OnWindowActivated ( Window  got_focus, Window  lost_focus )
		   {
			MessageBox ( "activated" ) ;
		    }


		/// <summary>
		/// Handles Edit/Comments menu items.
		/// </summary>
		private void  OnInsertComment  ( object  sender, EventArgs  e, CommandID  cmd )
		   {
			MessageBox ( "Item #" + cmd.ID ) ;
		    }
		# endregion

		# region Support functions
		/// <summary>
		/// Returns true if the specified window contains a document whose extension is covered by the current xml comments definitions.
		/// </summary>
		private bool  IsSourceDocument ( Window  win )
		   {
			return
			   (
				win. Kind	==  "Document"  &&
				win. Document   !=  null	&& 
				XmlComments. Groups. FindGroupByExtension ( Path. GetExtension ( win. Document. Path ) )  !=  null 
			    ) ;
		    }
		# endregion
	    }
    }
