﻿/**************************************************************************************************************

    NAME
	VsPackage.cs

    DESCRIPTION
	Extends the VSIX Shell Package class, mainly to shorten the quantity of code needed to perform the
	tiniest action.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/09/12]     [Author : CV]
	Initial version.

 **************************************************************************************************************/
using	System ;
using	System. Collections. Generic ;
using	System. ComponentModel. Design ;
using	System. IO ;
using	System. Linq ;
using   System. Reflection ;
using	System. Text ;
using	System. Threading. Tasks ;
using	EnvDTE ;
using	Microsoft. VisualStudio ;
using	Microsoft. VisualStudio. Shell. Interop ;
using	Microsoft. VisualStudio. OLE. Interop ;
using	Microsoft. VisualStudio. Shell ;


namespace VsPackage
   {
	# region	Shortcuts and aliases
	// Shortcuts
	using	UIShell			=  Microsoft. VisualStudio. Shell. Interop. IVsUIShell ;
	using	MenuCommandService	=  OleMenuCommandService ;


	/// <summary>
	/// Alias to the OLEMSGBUTTON enum.
	/// </summary>
	public enum  MSGBUTTON
	   {
		ABORTRETRYIGNORE		=  OLEMSGBUTTON. OLEMSGBUTTON_ABORTRETRYIGNORE,
		OK				=  OLEMSGBUTTON. OLEMSGBUTTON_OK,
		OKCANCEL			=  OLEMSGBUTTON. OLEMSGBUTTON_OKCANCEL,
		RETRYCANCEL			=  OLEMSGBUTTON. OLEMSGBUTTON_RETRYCANCEL,
		YESALLNOCANCEL			=  OLEMSGBUTTON. OLEMSGBUTTON_YESALLNOCANCEL,
		YESNO				=  OLEMSGBUTTON. OLEMSGBUTTON_YESNO,
		YESNOCANCEL			=  OLEMSGBUTTON. OLEMSGBUTTON_YESNOCANCEL
	    }

	/// <summary>
	/// Alias to the OLEMSGDEFBUTTON enum.
	/// </summary>
	public enum  MSGDEFBUTTON
	   {
		BUTTON_1			=  OLEMSGDEFBUTTON. OLEMSGDEFBUTTON_FIRST,
		BUTTON_2			=  OLEMSGDEFBUTTON. OLEMSGDEFBUTTON_SECOND,
		BUTTON_3			=  OLEMSGDEFBUTTON. OLEMSGDEFBUTTON_THIRD,
		BUTTON_4			=  OLEMSGDEFBUTTON. OLEMSGDEFBUTTON_FOURTH
	    }

	/// <summary>
	/// Alias to the OLEMSGICON enum.
	/// </summary>
	public enum  MSGICON
	   {
		CRITICAL			=  OLEMSGICON. OLEMSGICON_CRITICAL,
		INFO				=  OLEMSGICON. OLEMSGICON_INFO,
		NOICON				=  OLEMSGICON. OLEMSGICON_NOICON,
		QUERY				=  OLEMSGICON. OLEMSGICON_QUERY,
		WARNING				=  OLEMSGICON. OLEMSGICON_WARNING
	    }
	# endregion

	# region VsPackage class
	public class 	VsPackage	:  Microsoft. VisualStudio. Shell. Package
	  {
		// Shortcuts
		protected Func<int, int>	ThrowOnFailure		=  Microsoft. VisualStudio. ErrorHandler. ThrowOnFailure ;

		// This delegate allows a menu item callback function to have a 3rd parameter, the menu item id....
		protected delegate void		MenuCommandHandler ( MenuCommand  sender, EventArgs  e ) ;

		// Base directory where the vsix is installed
		public string	PackageDirectory	{ get ; private set ; }


		/// <summary>
		/// Some initialization stuff, such as retrieving the vsix installation directory.
		/// </summary>
		public  VsPackage ( )
		   {
			String		codebase	=  this. GetType ( ). Assembly. GetName ( ). CodeBase ;

			this. PackageDirectory	=  Path. GetDirectoryName ( codebase ) ;
		    }


		# region	Service and misc object retrieval methods
		/// <summary>
		/// Returns a tools options page of the specified type.
		/// </summary>
		public  T  GetDialogPage<T> ( ) 
			where T : DialogPage
		   {
			return ( ( T ) GetDialogPage ( typeof ( T ) ) ) ;
		    }


		/// <summary>
		/// Retrieves the IMenuCommandService interface.
		/// </summary>
		/// <returns>An IMenuCommandService interface, renamed as MenuCommandService.</returns>
		public MenuCommandService  GetCommandService ( )
		   {
			return ( ( MenuCommandService ) GetService ( typeof ( IMenuCommandService ) ) ) ;
		    }

		
		/// <summary>
		/// Retrieves an interface to the MS DTE.
		/// </summary>
		/// <returns>A DTE object.</returns>
		public  DTE  GetDTE ( )
		   {
			return ( ( DTE ) GetService ( typeof ( SDTE ) ) ) ;
		    }


		/// <summary>
		/// Retrieves the SVsUIShell service interface.
		/// </summary>
		/// <returns>An IVsUIShell interface, renamed as UIShell.</returns>
		public UIShell  GetUIShell ( )
		   {
			return ( ( UIShell ) GetService ( typeof ( SVsUIShell ) ) ) ;
		    }
		# endregion


		# region	MessageBox() method
		/// <summary>
		/// Simplified message box display. This method uses the ShowMessageBox() method from the UIShell object.
		/// Note that use can still use the Windows.Forms.MessageBox.Show() function instead.
		/// </summary>
		/// <param name="text">Message text.</param>
		/// <param name="title">Message title. If not specified, a default title will be built based on the icon specified.</param>
		/// <param name="buttons">Button(s) to show in the message box. Default is Ok.</param>
		/// <param name="defbutton">Default button (ie, button which receives the focus).</param>
		/// <param name="icon">Icon to be displayed on the left of the message. Default is none.</param>
		/// <returns>The id of the button that was clicked.</returns>
		public int  MessageBox ( string		text, 
					 string		title		=  null, 
					 MSGBUTTON	buttons		=  MSGBUTTON. OK, 
					 MSGDEFBUTTON	defbutton	=  MSGDEFBUTTON. BUTTON_1, 
					 MSGICON	icon		=  MSGICON. NOICON )
		   {
			UIShell		shell		=  GetUIShell ( ) ;
			Guid		clsid		=  Guid. Empty ;
			int		result ;

			if  ( String. IsNullOrWhiteSpace ( title ) )
			   {
				switch ( icon )
				   {
					case  MSGICON. CRITICAL		:  title	=  "Error message "	; break ;
					case  MSGICON. INFO		:  title	=  "Information"	; break ;
					case  MSGICON. QUERY		:  title	=  "Question"		; break ;
					case  MSGICON. WARNING		:  title	=  "Warning"		; break ;
					case  MSGICON. NOICON		:  
					default				:  title	=  "Message"		; break ;
				    }

				title	+=  " from the Wuthering." + Assembly. GetCallingAssembly ( ). GetName ( ). Name + " package :" ;
			    }

			ThrowOnFailure 
			   (
				shell. ShowMessageBox ( 0, ref clsid, title, text, String. Empty, 0, 
						( OLEMSGBUTTON ) buttons, ( OLEMSGDEFBUTTON ) defbutton, ( OLEMSGICON ) icon, 0, out result )
			    ) ;

			return ( result ) ;
		    }
# endregion


		# region	RegisterMenuCommands() method
		/// <summary>
		/// Registers a callback for a series of menu ids.
		/// </summary>
		/// <param name="guid_string">Guid of a &lt;group&gt; node in the .vsct file.</param>
		/// <param name="handler">Callback function.</param>
		/// <param name="idlist">List of menu ids to be associated with this callback.</param>
		/// <returns>False if the menu command service could not be retrieved, true otherwise.</returns>
		protected bool	RegisterMenuCommands ( string  guid_string, uint []  idlist, MenuCommandHandler  handler )
		   {
			// Get the menu command service object
			MenuCommandService		mcs	=  GetCommandService ( ) ;

			if  ( mcs  ==  null )		// well, this should never happen but who knows...
				return ( false ) ;

			// A Guid object is needed
			Guid		guid		=  new Guid ( guid_string ) ;

			// Loop through the list of menu item ids
			foreach  ( uint  id  in  idlist )
			   {
				// You need a CommandID object...
				CommandID	cmdid		=  new CommandID ( guid, ( int ) id ) ;
				// ... to create a MenuItem one. Note that the callback is wrapped in a lambda function,
				// to give it a MenuCommand object for the "sender" parameter
				MenuCommand	menuitem	=  new MenuCommand 
				   ( 
					( object  sender, EventArgs  e ) =>
					   {
						handler ( ( MenuCommand ) sender, e ) ;
					    },
					cmdid
				    ) ;

				// Register this handler
				mcs. AddCommand ( menuitem ) ;
			    }

			return ( true ) ;
		    }
		# endregion
	   }
	# endregion
    }
