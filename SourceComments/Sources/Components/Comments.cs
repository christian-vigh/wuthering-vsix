/**************************************************************************************************************

    NAME
	Comments.cs

    DESCRIPTION
	The Comments class is the top-level class that contain the <wuthering-comments> definitions.
	The class tree is the following ("x -->* y" denotes a collection x of y objects) :
 
 	Comments
 		. Author
 		. Categories
 		  -->* Category
 		. CommentTypes
 		  -->* CommentType
 		. Templates
 		  -->* Template
 		       -->* CommentBlock

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
	public class Comments		:  XmlCommentNode
	   {
		public  Author			Author		{ get ; private set ; }
		public  Categories		Categories	{ get ; private set ; }
		public  CommentTypes		CommentTypes	{ get ; private set ; }
		public  Templates		Templates	{ get ; private set ; }


		public  Comments  ( XmlNode  root ) : base ( root )
		   {
			Compound	=  true ;

			foreach ( XmlNode  CommentNode  in  root )
			   {
				switch  ( CommentNode. Name. ToLower ( ) )
				   {
					case	"author" :
						Author		=  new Author ( CommentNode ) ;
						break ;

					case	"categories" :
						Categories	=  new Categories ( CommentNode, "category" ) ;
						break ;

					case	"comment-types" :
						CommentTypes	=  new CommentTypes ( CommentNode, "comment-type" ) ;
						break ;

					case	"templates" :
						Templates	=  new Templates ( CommentNode, "template" ) ;
						break ;
				    }
			    }
		    }


		public override string  ToString ( )
		   {
			StringBuilder	result	=  new StringBuilder ( GetOpeningTag ( true ) + "\n" ) ;

			// <author>
			result. Append ( Author. ToXmlString ( ) + "\n\n" ) ;

			// Categories
			result. Append ( Categories. ToXmlString ( ) + "\n\n" ) ;

			// Comment types
			result. Append ( CommentTypes. ToXmlString ( ) + "\n\n" ) ;

			// Templates
			result. Append ( Templates. ToXmlString ( ) + "\n\n" ) ;

			// End of <wuthering-comments>
			result. Append ( GetClosingTag ( ) ) ;

			return ( result. ToString ( ) ) ;
		    }
	    }
    }
