/**************************************************************************************************************

    NAME
	CommentType.cs

    DESCRIPTION
	Encapsulates a <comment-types> node and instanciate a CommentType object for each <comment-type> child node.

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
	public class CommentTypes	:  XmlCommentListNode<CommentType>
	   {
		public	CommentType	Default		{ get ; private set ; }


		public		CommentTypes ( )
		   { }

		public		CommentTypes ( Comments  parent, XmlNode  node, string  subtag )
		   {
			Initialize ( parent, node, subtag ) ;
		    }


		public override void  Initialize ( Comments  parent, XmlNode  node, string  subtag )
		   {
			base. Initialize ( parent, node, subtag ) ;

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
		// Node name (ie, the value of the "name" attribute)
		public string		Name		{ get ; set ; }

		public		CommentType ( )
		   { }

		public  CommentType ( Comments  parent, XmlNode  node )
		   {
			Initialize ( parent, node ) ;
		    }

		public override void  Initialize ( Comments  parent, XmlNode  node )
		   {
			base. Initialize ( parent, node ) ;

			Name		=  GetAttributeValue ( "name" ) ;
		    }

	    }
    }
