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
	public class CommentVariables		:  VariableStore<string>
	   {
		// List of variables and values
		private	Dictionary<string, object>	List		=  new Dictionary<string, object> ( StringComparer. CurrentCultureIgnoreCase ) ;
		// Parent document that contains all the comments information
		private XmlCommentsDocument		Parent ;


		/// <summary>
		/// Creates a variable store and defines default variables.
		/// </summary>
		public  CommentVariables ( XmlCommentsDocument  parent ) : base ( )
		   { 
			Parent		=  parent ;
			DefineDefaultVariables ( ) ;
		    }


		/// <summary>
		/// Gets the value of a variable. This version does not expand variables referenced in variables.
		/// (in fact the current version only returns the variable value).
		/// </summary>
		/// <param name="variable_name">Variable to be expanded</param>
		/// <param name="options">Reserved for future use.</param>
		/// <returns>The value of the specified variable.</returns>
		public string  Expand ( string  variable_name, string  options = null )
		   {
			StringBuilder	result		=  new StringBuilder ( ) ;

			if  ( IsDefined ( variable_name ) )
			   {
				result. Append ( this [ variable_name ] ) ;
			    }	

			return ( result. ToString ( ) ) ;
		    }


		/// <summary>
		/// Define default variables.
		/// </summary>
		private void DefineDefaultVariables ( )
		   {
			// Add author-related variables
			Define 
			   (
				new string [] { "author", "author-name" },
				new Func<string> ( ( ) => { return ( Parent. Author. Name ) ; } ) 
			    ) ;
			Define 
			   (
				new string [] { "initials", "author-initials" },
				new Func<string> ( ( ) => { return ( Parent. Author. Initials ) ; } ) 
			    ) ;
			Define 
			   (
				new string [] { "email", "author-email" },
				new Func<string> ( ( ) => { return ( Parent. Author. Email ) ; } ) 
			    ) ;
			Define 
			   (
				new string [] { "website", "author-website" },
				new Func<string> ( ( ) => { return ( Parent. Author. WebSite ) ; } ) 
			    ) ;

			// Date/time variables
			Define 
			   (
				"datetime",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "yyyy-MM-dd HH:mm" ) ) ; } ) 
			    ) ;
			Define 
			   (
				"date",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "yyyy-MM-dd" ) ) ; } ) 
			    ) ;
			Define 
			   (
				"year",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "yyyy" ) ) ; } ) 
			    ) ;
			Define 
			   (
				"month",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "MM" ) ) ; } ) 
			    ) ;
			Define 
			   (
				"day",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "dd" ) ) ; } ) 
			    ) ;
			Define 
			   (
				"time",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "HH:mm:ss" ) ) ; } ) 
			    ) ;
			Define 
			   (
				"hour",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "HH" ) ) ; } ) 
			    ) ;
			Define 
			   (
				"minute",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "mm" ) ) ; } ) 
			    ) ;
			Define 
			   (
				"second",
				new Func<string> ( ( ) => { return ( DateTime. Now. ToString ( "ss" ) ) ; } ) 
			    ) ;
		    }
	    }
    }