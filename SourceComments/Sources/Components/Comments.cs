/**************************************************************************************************************

    NAME
	Comments.cs

    DESCRIPTION
	Encapsulates the <template>, <group> and <comment> nodes.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/012/12]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using  System ;
using  System. Collections. Generic ;
using  System. Linq ;
using  System. Text ;
using  System. Text. RegularExpressions ;
using  System. Threading. Tasks ;
using  System. Xml ;

using  VsPackage ;
using  Thrak. Structures ;
using  Thrak. Types ;
using  Thrak. Xml ;


namespace Wuthering. WutheringComments
   {
 	/// <summary>
	/// Encapsulates a &lt;comment&gt; node within a &lt;template&gt; node. 
	/// This is also a base class for comments within a &lt;group&gt; node.
	/// </summary>
	public class  Comment		:  WrappedNamedNode
	   {
		// Regular expression to match a variable reference
		private const string		VariableRegexPattern	=  
			@"
				\{\$
					(?<var> [^\s:}]+)
					(
						\s* : \s*
						(?<options> [^}]+)
					 )?
				\}
			 " ;
		// Regex options for matching a variable reference
		private const RegexOptions	VariableRegexOptions	=  RegexOptions. IgnoreCase | 
									   RegexOptions. IgnorePatternWhitespace | 
									   RegexOptions. ExplicitCapture ;

		// Lines of text
		public string []	TextLines ;


		public	Comment ( XmlCommentsDocument  document, XmlNode  node ) : base ( document, "category", node )
		   {
			TextLines	=  node. GetAlignedTextLines ( ) ; 
		    }


		/// <summary>
		/// Returns the comment contents after variable expansion.
		/// </summary>
		/// <param name="store">Variable store</param>
		/// <returns>Array of strings containing the initial comments with all variable references expanded</returns>
		public virtual string []  GetLines ( CommentVariables  store )
		   {
			List<string>	lines		=  new List<string> ( ) ;


			foreach  ( string  line  in  TextLines )
			   {
				MatchCollection		matches		=  Regex. Matches ( line, VariableRegexPattern, VariableRegexOptions ) ;
				
				if  ( matches. Count  ==  0 )
				   {
					lines. Add ( line ) ;
					continue ;
				    }

				StringBuilder	newline		=  new StringBuilder ( ) ;
				int		next_index	=  0 ;

				foreach ( Match  match  in  matches )
				   {
					if  ( match. Index  >  0 )
						newline. Append ( line. Substring ( next_index, match. Index - next_index ) ) ;

					next_index	=  match. Index + match. Length ;

					string		vname		=  match. Groups [ "var" ]. Value ;
					string		options		=  match. Groups [ "options" ]. Value ;
					string		value		=  store. Expand ( vname, options ) ;

					newline. Append ( value ) ;
				    }

				if  ( next_index  <  line. Length )
					newline. Append	( line. Substring ( next_index ) ) ;

				lines. Add ( newline. ToString ( ) ) ;
			    }

			return ( lines. ToArray ( ) ) ;
		    }


		/// <summary>
		/// Returns the xml code corresponding to this node.
		/// </summary>
		public override string  ToString ( )
		   {
			StringBuilder	result	=  new StringBuilder ( ) ;

			result. Append ( Node. GetOpeningTag ( ) ) ;
			result. Append ( XmlCommentsDocument. EOL ) ;

			foreach  ( string  line  in  TextLines )
			   {
				result. Append ( '\t' ) ;
				result. Append ( line ) ;
				result. Append ( XmlCommentsDocument. EOL ) ;
			    }

			result. Append ( Node. GetClosingTag ( ) ) ;
			return ( result. ToString ( ) ) ;
		    }
	    }
   }
