/**************************************************************************************************************

    NAME
	Variables.cs

    DESCRIPTION
	List of variables that can be expanded during comment expansion.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/012/10]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using  System ;
using  System. Collections. Generic ;
using  System. Linq ;
using  System. Text ;
using  System. Threading. Tasks ;
using  System. Xml ;

using  Utilities ;
using  Thrak. Types ;
using  Thrak. Structures ;
using  Thrak. Xml ;


namespace Wuthering. WutheringComments
   {
	/// <summary>
	/// Variable store.
	/// </summary>
	public class Variables
	   {
		// List of variables and values
		private	Dictionary<string, object>	List		=  new Dictionary<string, object> ( StringComparer. CurrentCultureIgnoreCase ) ;
		// Parent document that contains all the comments information
		private XmlCommentsDocument		Parent ;


		/// <summary>
		/// Creates a variable store and defines default variables.
		/// </summary>
		public  Variables ( XmlCommentsDocument  parent )
		   { 
			Parent		=  parent ;
			AddDefaultVariables ( ) ;
		    }


		# region Default variable definitions
		private void AddDefaultVariables ( )
		   {
			// Add author-related variables
			AddVariable 
			   (
				new string [] { "author", "author-name" },
				new Func<string> ( ( ) => { return ( Parent. Author. Name ) ; } ) 
			    ) ;
			AddVariable 
			   (
				new string [] { "initials", "author-initials" },
				new Func<string> ( ( ) => { return ( Parent. Author. Initials ) ; } ) 
			    ) ;
			AddVariable 
			   (
				new string [] { "email", "author-email" },
				new Func<string> ( ( ) => { return ( Parent. Author. Email ) ; } ) 
			    ) ;
			AddVariable 
			   (
				new string [] { "website", "author-website" },
				new Func<string> ( ( ) => { return ( Parent. Author. WebSite ) ; } ) 
			    ) ;

			// Date/time variables
			AddVariable 
			   (
				"datetime",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "yyyy-MM-dd HH:mm" ) ) ; } ) 
			    ) ;
			AddVariable 
			   (
				"date",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "yyyy-MM-dd" ) ) ; } ) 
			    ) ;
			AddVariable 
			   (
				"year",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "yyyy" ) ) ; } ) 
			    ) ;
			AddVariable 
			   (
				"month",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "MM" ) ) ; } ) 
			    ) ;
			AddVariable 
			   (
				"day",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "dd" ) ) ; } ) 
			    ) ;
			AddVariable 
			   (
				"time",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "HH:mm:ss" ) ) ; } ) 
			    ) ;
			AddVariable 
			   (
				"hour",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "HH" ) ) ; } ) 
			    ) ;
			AddVariable 
			   (
				"minute",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "mm" ) ) ; } ) 
			    ) ;
			AddVariable 
			   (
				"second",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "ss" ) ) ; } ) 
			    ) ;
		    }
		# endregion



	    }
    }