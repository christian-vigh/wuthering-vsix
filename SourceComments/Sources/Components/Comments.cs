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
using  System. Threading. Tasks ;
using  System. Xml ;

using  Utilities ;
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
		public string []	TextLines ;


		public	Comment ( XmlValidatedDocument  document, XmlNode  node ) : base ( document, "category", node )
		   {
			TextLines	=  node. GetAlignedTextLines ( ) ; 
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
