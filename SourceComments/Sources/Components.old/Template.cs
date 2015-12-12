/**************************************************************************************************************

    NAME
	Template.cs

    DESCRIPTION
	Encapsulates a <templates> node and instanciates a Template object for each <template> child node.
	The Template object in turns creates a CommentBlock instance for each <comment> child node.
 
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


namespace Wuthering. WutheringComments
   {
	public class Templates	:  XmlCommentListNode<Template>
	   {
		public		Templates ( )
		   { }

		public		Templates ( Comments  parent, XmlNode  node, string  subtag )
		   {
			Initialize ( parent, node, subtag ) ;
		    }


		public override void  Initialize ( Comments  parent, XmlNode  node, string  subtag )
		   {
			base. Initialize ( parent, node, subtag ) ;
		    }
	    }


	public class Template	:  XmlCommentNode
	   {
		// Node name (ie, the value of the "name" attribute)
		public string		Name		{ get ; set ; }
		// Node description
		public string		Description	{  get ; set ; }
		// Comment blocks (by category)
		public CommentBlocks	CommentBlocks	{  get ; set ; }


		public		Template ( )
		   { }

		public  Template ( Comments  parent, XmlNode  node )
		   {
			Initialize ( parent, node ) ;
		    }


		public override void  Initialize ( Comments  parent, XmlNode  node )
		   {
			base. Initialize ( parent, node ) ;

			Name		=  GetAttributeValue ( "name" ) ;
			Description	=  GetAttributeValue ( "description" ) ;
			CommentBlocks	=  new CommentBlocks ( parent, node, "comment" ) ;


		    }


		public override string ToString ( )
		   {
			StringBuilder		result		=  new StringBuilder ( ) ;

			result. Append ( GetOpeningTag ( true ) + "\n" ) ;
			result. Append ( "\t" ) ; 
			result. Append ( CommentBlocks. ToString ( ). Replace ( "\n", "\n\t" ) ) ;
			result. Append ( "\n" ) ;
			result. Append ( GetClosingTag ( ) ) ;

			return ( result. ToString ( ) ) ;
		    }
	    }
    }
