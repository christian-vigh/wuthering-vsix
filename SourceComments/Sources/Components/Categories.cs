/**************************************************************************************************************

    NAME
	Categories.cs

    DESCRIPTION
	Encapsulates the <categories> and <category> nodes.

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
using  System. Threading. Tasks ;
using  System. Xml ;

using  Utilities ;
using  Thrak. Types ;
using  Thrak. Xml ;


namespace Wuthering. WutheringComments
   {
	/// <summary>
	/// Encapsulates the &lt;categories&gt; node and its descendants.
	/// </summary>
	public class Categories		:  WrappedNodeList<Category>
	   {
		/// <summary>
		/// Parses the &lt;categories&gt; node and its child &lt;category&gt; nodes.
		/// </summary>
		/// <param name="document">Base xml document.</param>
		/// <param name="base_node">Node related to the &lt;categories&gt; node.</param>
		public Categories ( XmlValidatedDocument  document, XmlNode  base_node ) : base ( document, base_node )
		   { 
			foreach  ( XmlNode node  in  base_node. ChildNodes )
			   {
				switch  ( node. Name. ToLower ( ) )
				   {
					case	"category" :
						Category	category	=  new Category ( document, node ) ;

						try
						   { 
							Add ( category ) ;
						    }
						catch ( XmlException )
						   {
							Parent. AddValidationMessage ( XmlParseErrorSeverity. Error, "Category \"" +
									category. Name + "\" is defined more than once." ) ;
						    }
						break ;

					default :
						Parent. AddValidationMessage ( XmlParseErrorSeverity. Error, "Unrecognized tag <" +
									node. Name + ">" ) ;
						break ;
				    }
			    }
		    }


		/// <summary>
		/// Returns the xml code corresponding to this node.
		/// </summary>
		public override string  ToString ( )
		   {
			StringBuilder	result	=  new StringBuilder ( ) ;

			result. Append ( Node. GetOpeningTag ( ) ) ;
			result. Append ( CommentsParser. EOL ) ;

			foreach  ( Category  category in NodeList )
			   {
				result. Append ( '\t' ) ;
				result. Append ( category. ToString ( ) ) ;
				result. Append ( CommentsParser. EOL ) ;
			    }

			result. Append ( Node. GetClosingTag ( ) ) ;
			return ( result. ToString ( ) ) ;
		    }
	    }


	/// <summary>
	/// Encapsulates a &lt;category&gt; node.
	/// </summary>
	public class  Category		:  WrappedNamedNode
	   {
		public Category ( XmlValidatedDocument  document, XmlNode  node ) : base ( document, "name", node )
		   { }
	    }
    }