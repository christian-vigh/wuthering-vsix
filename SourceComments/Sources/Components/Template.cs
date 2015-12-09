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

		public		Templates ( XmlNode  node ) : base ( node )
		   {
		    }


		public override void  Initialize ( XmlNode  node )
		   {
			base. Initialize ( node ) ;
		    }
	    }


	public class Template	:  XmlCommentNode
	   {
		public string	Description	{  get ; set ; }


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
		    }

	    }
    }
