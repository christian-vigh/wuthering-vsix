using  System ;
using  System. Collections. Generic ;
using  System. Linq ;
using  System. Text ;
using  System. Threading. Tasks ;
using  System. Xml ;

namespace Wuthering. WutheringComments
   {
	public class Comments		:  XmlCommentNode
	   {
		public  Author			Author		{ get ; private set ; }
		public  Categories		Categories	{ get ; private set ; }
		public  CommentTypes		CommentTypes	{ get ; private set ; }
		public  Templates		Templates	{ get ; private set ; }


		public  Comments  ( XmlNode  root ) : base ( root )
		   {
			foreach ( XmlNode  CommentNode  in  root )
			   {
				switch  ( CommentNode. Name. ToLower ( ) )
				   {
					case	"author" :
						Author		=  new Author ( CommentNode ) ;
						break ;

					case	"categories" :
						Categories	=  new Categories ( CommentNode ) ;
						break ;

					case	"comment-types" :
						CommentTypes	=  new CommentTypes ( CommentNode ) ;
						break ;

					case	"templates" :
						Templates	=  new Templates ( CommentNode ) ;
						break ;
				    }
			    }
		    }
	    }
    }
