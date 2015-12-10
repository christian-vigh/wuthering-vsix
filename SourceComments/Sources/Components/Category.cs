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

		public		Categories ( XmlNode  node, string  subtag ) : base ( node, subtag )
		   {			
		    }
	    }


	public class Category	:  XmlCommentNode
	   {
		public string	Description	{  get ; set ; }


		public		Category ( ) : base ( ) { Compound = true ; }

		public  Category ( XmlNode  node )
		   {
			Compound = true ;
			Initialize ( node ) ;
		    }


		public override void  Initialize ( XmlNode  node )
		   {
			base. Initialize ( node ) ;

			Name		=  GetAttributeValue ( "name" ) ;
			Description	=  GetAttributeValue ( "description" ) ;
			Text		=  GetNodeText ( true ) ;
		    }
	    }
    }
