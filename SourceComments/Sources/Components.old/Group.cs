/**************************************************************************************************************

    NAME
	Group.cs

    DESCRIPTION
	Encapsulates a <groups> node and instanciates a Group object for each <group> child node.
	The Group object in turns creates a CommentBlock instance for each <comment> child node.
 
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
	public class Groups	:  XmlCommentListNode<Template>
	   {
		public		Groups ( ) : base ( ) { }

		public		Groups ( Comments  parent, XmlNode  node, string  subtag )
		   {
			Initialize ( parent, node, subtag ) ;
		    }


		public override void  Initialize ( Comments  parent, XmlNode  node, string  subtag )
		   {
			base. Initialize ( parent, node, subtag ) ;
		    }
	    }


	public class Group	:  XmlCommentNode
	   {
		// Node name (ie, the value of the "name" attribute)
		public string		Name		{ get ; set ; }
		public string		Description	{  get ; set ; }
		public CommentBlocks	CommentBlocks	{  get ; set ; }


		public		Group ( ) : base ( ) { }

		public  Group ( Comments  parent, XmlNode  node )
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
