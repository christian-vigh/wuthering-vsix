using  System ;
using  System. Collections. Generic ;
using  System. Linq ;
using  System. Text ;
using  System. Threading. Tasks ;
using  System. Xml ;


namespace Wuthering. WutheringComments
   {
	public class XmlCommentNode
	   {
		public	XmlNode		Node		{ get ; protected set ; }
		public  int		NestingLevel	{ get ; protected set ; }
		public string		Name		{ get ; set ; }


		public		XmlCommentNode ( )
		   { }

		public XmlCommentNode ( XmlNode  nd )
		   {
			Initialize ( nd ) ;
		    }


		public virtual  void	Initialize ( XmlNode  nd )
		   {
			Node		=  nd ;
			NestingLevel	=  0 ;
			nd		=  nd. ParentNode ;
			
			while  ( nd  !=  null )
			   {
				NestingLevel ++ ;
				nd	=  nd. ParentNode ;
			    }

			NestingLevel -- ;	// Count one less, since the top level node is the XmlDocument itself
		    }


		public string  GetAttributeValue ( string  name, string  default_value = "" )
		   {
			try
			   {
				return  ( this. Node. Attributes [ name ]. Value. Trim ( ) ) ; 
			    }
			catch
			   {
				return ( default_value ) ;
			    }
		    }


		public string  GetNodeText ( bool  trim = false )
		   {
			string		text		=  Node. InnerText ;

			if  ( trim )
				return ( Node. InnerText. Trim ( ) ) ;
			else
				return ( Node. InnerText ) ;
		    }
	    }


	public class	XmlCommentListNode<T> 		:  XmlCommentNode
				where T : XmlCommentNode, new ()
	   {
		public Dictionary<string, T>		Items	{ get ; private set ; }


		public	XmlCommentListNode ( )
		   { }


		public XmlCommentListNode ( XmlNode  nd ) : base ( nd )
		   {
			Initialize ( nd ) ;
		    }


		public override void	Initialize ( XmlNode  nd )
		   {
			base. Initialize ( nd ) ;

			Items		=  new Dictionary<string,T> ( StringComparer. CurrentCultureIgnoreCase ) ;


			foreach  ( XmlNode  child  in  nd. ChildNodes )
			   {
				T	item		=  new T ( ) ;

				item. Initialize ( child ) ;
				Items [ item. Name ]	=  item ;
			    }
		    }


		public T  this [ string  index ]
		   {
			get 
			   { 
				try
				   {
					return ( Items [ index ] ) ; 
				    }
				catch
				   {
					return ( null ) ;
				    }
			     }
			set { Items [ index ]	=  value ; }
		    }
	   }
    }
