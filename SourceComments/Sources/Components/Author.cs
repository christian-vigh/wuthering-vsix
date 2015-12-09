using  System ;
using  System. Collections. Generic ;
using  System. Linq ;
using  System. Text ;
using  System. Threading. Tasks ;
using  System. Xml ;


namespace Wuthering. WutheringComments
   {
	public class Author	:  XmlCommentNode
	   {
		public string	Initials	{  get ; set ; }
		public string	Email		{  get ; set ; }
		public string	WebSite		{  get ; set ; } 


		public  Author ( XmlNode  node ) : base ( node )
		   {
			Name		=  GetAttributeValue ( "name" ) ;
			Initials	=  GetAttributeValue ( "initials" ) ;
			Email		=  GetAttributeValue ( "email" ) ;
			WebSite		=  GetAttributeValue ( "website" ) ;
		    }
	    }
    }
