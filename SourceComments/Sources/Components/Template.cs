/**************************************************************************************************************

    NAME
	Categories.cs

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
		public	Template	Default		{ get ; private set ; }


		public		Templates ( ) : base ( ) { }

		public		Templates ( XmlNode  node, string  subtag ) : base ( node, subtag )
		   {
		    }


		public override void  Initialize ( XmlNode  node, string  subtag )
		   {
			base. Initialize ( node, subtag ) ;
		    }
	    }


	public class Template	:  XmlCommentNode
	   {
		public string		Description	{  get ; set ; }
		public CommentBlocks	CommentBlocks	{  get ; set ; }


		public		Template ( ) : base ( ) { }

		public  Template ( XmlNode  node )
		   {
			Initialize ( node ) ;
		    }


		public override void  Initialize ( XmlNode  node )
		   {
			base. Initialize ( node ) ;

			Name		=  GetAttributeValue ( "name" ) ;
			Description	=  GetAttributeValue ( "description" ) ;
			CommentBlocks	=  new CommentBlocks ( node, "comment" ) ;


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
