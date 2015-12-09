using  System ;
using  System. Collections. Generic ;
using  System. Linq ;
using  System. Text ;
using  System. Threading. Tasks ;
using  System. Xml ;


namespace Wuthering. WutheringComments
   {
	public class CommentTypes	:  XmlCommentListNode<CommentType>
	   {
		public	CommentType	Default		{ get ; private set ; }


		public		CommentTypes ( ) : base ( ) { }

		public		CommentTypes ( XmlNode  node ) : base ( node )
		   {
		    }


		public override void  Initialize ( XmlNode  node )
		   {
			base. Initialize ( node ) ;

			foreach  ( KeyValuePair<string, CommentType>  item  in  Items )
			   {
				if  ( String. Compare ( item. Key, "custom", true )  ==  0 )
				   {
					Default		=  item. Value ;
					break ;
				    }
			    }

			if  ( Default  ==  null )
				throw new XmlException ( "At least one <comment-type> node must be defined." ) ;
		    }
	    }


	public class CommentType	:  XmlCommentNode
	   {
		public		CommentType ( ) : base ( ) { }

		public  CommentType ( XmlNode  node )
		   {
			Initialize ( node ) ;
		    }

		public override void  Initialize ( XmlNode  node )
		   {
			base. Initialize ( node ) ;

			Name		=  GetAttributeValue ( "name" ) ;
		    }

	    }
    }
