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
using	System. Linq ;
using   System. Windows. Forms ;
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
using	Wuthering. WutheringCommentsPackage. Symbols ;


namespace Wuthering. WutheringCommentsPackage
   {
	using	WindowActivatedEventHandler	=  _dispWindowEvents_WindowActivatedEventHandler ;


	[PackageRegistration ( UseManagedResourcesOnly = true ) ]
	[InstalledProductRegistration ( WutheringCommentsPackage. PACKAGE_NAME, "A set of personal VS tools", "1.0", IconResourceID = 400 ) ]
	[ProvideMenuResource ( "Menus.ctmenu", 1 ) ]
	[ProvideAutoLoad ( UIContextGuids80. NoSolution ) ]
	[ProvideAutoLoad ( UIContextGuids80. SolutionExists ) ]
	[ProvideOptionPage ( typeof ( WutheringCommentsOptionsPage ), WutheringCommentsPackage. PACKAGE_NAME, WutheringCommentsPackage. COMMENTS_PAGE, 0, 0, true )]
	[ProvideProfile ( typeof ( WutheringCommentsOptionsPage ), WutheringCommentsPackage. PACKAGE_NAME, WutheringCommentsPackage. COMMENTS_PAGE, 0, 0, true )]
	[Guid ( Symbols. Guids. Package ) ]
	public sealed class WutheringCommentsPackage	: VsPackage. VsPackage
	   {
		public const string	PACKAGE_NAME		=  "Wuthering Tools" ;
		public const string	COMMENTS_PAGE		=  "Comments" ;


		// Visual Studio DTE object
		private		DTE				EnvDTE ;
		// Options page settings
		private		WutheringCommentsOptionsPage	CommentsOptionsPage ;
		// Currently active xml comment definitions document
		internal	XmlCommentsDocument		XmlComments ;
		// Menu command ids
		private		Dictionary<uint,string>		CommentsMenuCommands	=  new  Dictionary<uint,string> ( )
		   {
			{ Symbols. Commands. InsertBlockHeaderComment	, "block"	},
			{ Symbols. Commands. InsertClassHeaderComment	, "class"	},
			{ Symbols. Commands. InsertFileHeaderComment	, "header"	},
			{ Symbols. Commands. InsertFunctionHeaderComment, "function"	},
			{ Symbols. Commands. InsertMethodHeaderComment	, "method"	},
			{ Symbols. Commands. InsertStandardComment	, "standard"	},
			{ Symbols. Commands. SourceCommentsSubMenuGroup	, null		},
			{ Symbols. Commands. EmbraceSelection		, null		},
			{ Symbols. Commands. ArrifySelection		, null		},
			{ Symbols. Commands. SourceFormatSubMenuGroup	, null		}
		    } ;
		

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
			// Initially disable everything
			RegisterMenuCommands ( Symbols. Guids. SourceCommentsMenu, 
				CommentsMenuCommands. Select ( x => x. Key ). ToArray ( ), OnMenuCommand ) ;
			EnableCommentsMenu ( false ) ;

			// Get the DTE object
			EnvDTE	=  GetDTE ( ) ;	

			// Get the comments options page
			CommentsOptionsPage	=  GetDialogPage<WutheringCommentsOptionsPage> ( ) ;
			XmlComments		=  CommentsOptionsPage. GetXmlDefinitions ( ) ;

			// Install event handlers
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
			if  ( IsSourceDocument ( got_focus ) )
				EnableCommentsMenu ( true, got_focus. Document. FullName ) ;
			else
				EnableCommentsMenu ( false ) ;
		    }


		/// <summary>
		/// Handles Edit/Comments menu items.
		/// </summary>
		private void  OnMenuCommand  ( MenuCommand  sender, EventArgs  e )
		   {
			Document	current_document	=  EnvDTE. ActiveDocument ;
			string		current_category	=  CommentsMenuCommands [ ( uint ) sender. CommandID. ID ] ;

			switch  ( ( uint ) sender. CommandID. ID )
			   {
				case	Symbols. Commands. InsertBlockHeaderComment :
				case	Symbols. Commands. InsertClassHeaderComment :
				case	Symbols. Commands. InsertFileHeaderComment :
				case	Symbols. Commands. InsertFunctionHeaderComment :
				case	Symbols. Commands. InsertMethodHeaderComment :
				case	Symbols. Commands. InsertStandardComment :
					XmlComments. InsertComment ( current_document, current_category ) ;
					break ;

				case	Symbols. Commands. EmbraceSelection :
					XmlComments. Enclose ( current_document, "{", "}",
								CommentsOptionsPage. SpacesBeforeEmbracingStart,
								CommentsOptionsPage. SpacesBeforeEmbracingStop ) ;
					break ;

				case	Symbols. Commands. ArrifySelection :
					XmlComments. Enclose ( current_document, "[", "]",
								CommentsOptionsPage. SpacesBeforeEmbracingStart,
								CommentsOptionsPage. SpacesBeforeEmbracingStop ) ;
					break ;
			    }
		    }

		# endregion

		# region Support functions
		/// <summary>
		/// Sets the enabled state of comments menu items.
		/// </summary>
		private void	EnableCommentsMenu ( bool  enabled, string  path = null )
		   {
			MenuCommandService	menu		=  GetCommandService ( ) ;
			Guid			guid		=  new Guid ( Guids. SourceCommentsMenu ) ;


			foreach  ( KeyValuePair<uint,string>  command  in  CommentsMenuCommands )
			   {
				CommandID	id	=  new CommandID ( guid, ( int ) command. Key ) ;
				MenuCommand	cmd	=  menu. FindCommand ( id ) ;

				if  ( enabled  &&  path  !=  null  &&  ! HasCategory ( path, command. Key ) )
					cmd. Enabled	=  false ;
				else
					cmd. Enabled	=  enabled ;
			    }
		    }


		/// <summary>
		/// Checks if there is a comment category for the specified file.
		/// </summary>
		private bool	HasCategory ( string  path, uint  key )
		   {
			if  ( path  ==  null )
				return ( false ) ;
			else if  ( CommentsMenuCommands [ key ]  ==  null )
				return ( true ) ;

			return ( XmlComments. Groups. HasCategory ( Path. GetExtension ( path ), CommentsMenuCommands [ key ] ) ) ;
		    }


		/// <summary>
		/// Returns true if the specified window contains a document whose extension is covered by the current xml comments definitions.
		/// </summary>
		private bool  IsSourceDocument ( Window  win )
		   {
			return
			   (
				win. Kind	==  "Document"  &&
				win. Document   !=  null	&& 
				XmlComments. Groups. FindGroupByExtension ( Path. GetExtension ( win. Document. FullName ) )  !=  null 
			    ) ;
		    }
		# endregion
	    }
    }
