/**************************************************************************************************************

    NAME
	Categories.cs

    DESCRIPTION
	Encapsulates a <categories> node and instanciate a Category object for each <category> child node.

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
	public class Categories	:  XmlCommentListNode<Category>
	   {
		public		Categories ( ) : base ( ) { }

		public		Categories ( Comments  parent, XmlNode  node, string  subtag )
		   {			
			Initialize ( parent, node, subtag ) ;
		    }
	    }


	public class Category	:  XmlCommentNode
	   {
		// Node name (ie, the value of the "name" attribute)
		public override string	Name		{ get ; set ; }
		public string		Description	{ get ; set ; }


		public		Category ( ) 
		   { Compound = true ; }

		public  Category ( Comments  parent, XmlNode  node )
		   {
			Compound = true ;
			Initialize ( parent, node ) ;
		    }


		public override void  Initialize ( Comments  parent, XmlNode  node )
		   {
			base. Initialize ( parent, node ) ;

			Name		=  GetAttributeValue ( "name" ) ;
			Description	=  GetAttributeValue ( "description" ) ;
			Text		=  GetNodeText ( true ) ;
		    }
	    }
    }
