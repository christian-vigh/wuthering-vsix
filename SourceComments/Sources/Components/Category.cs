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

		public		Categories ( XmlNode  node ) : base ( node )
		   {
			
		    }
	    }


	public class Category	:  XmlCommentNode
	   {
		public string	Description	{  get ; set ; }
		public string	Text		{  get ; set ; }


		public		Category ( ) : base ( ) { }

		public  Category ( XmlNode  node )
		   {
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
