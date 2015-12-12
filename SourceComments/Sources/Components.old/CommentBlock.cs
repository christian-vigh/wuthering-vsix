/**************************************************************************************************************

    NAME
	CommentBlock.cs

    DESCRIPTION
	Loads a <comment> block and applies proper formatting to the node text so that its shape does not 
	change when inserted at a particular column position.
  
 	The global appearance is also preserved ; consider the following example :
 	
 	<comment ...>
 		*---------------------------------
 		
 			some text
 			
 		 ---------------------------------*
 	</comment>
 	
 	If this comment is inserted at column#1, then :
 	- the line starting with '*' will be at column 1
 	- 'some text' will be one tab stop further to the right
 	- And the final line that ends with "---*" will seem to start at column 2.
 	
 	This is done by expanding tabs at the beginning of each line and finding the position of the first 
 	non-space character. The smallest position found will serve as a start position for all text contents.
 
 	Note also that newlines after the <comment> tag and after the last line of contents (before </comment>)
 	will be removed. However, you can still specify empty lines anywhere within the text contents : they 
 	will be preserved. This allows you to have a pretty-well formatted xml file without having the burden of
	preserving alignments.

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
using  Utilities ;


namespace Wuthering. WutheringComments
   {
	public class CommentBlocks	:  XmlCommentListNode<CommentBlock>
	   {
		public		CommentBlocks ( ) : base ( ) { }

		public		CommentBlocks ( Comments  parent, XmlNode  node, string  subtag ) 
		   {
			Initialize ( parent, node, subtag ) ;
		    }


		public override string ToString ( )
		   {
			StringBuilder	result		=  new StringBuilder ( ) ;

			foreach  ( KeyValuePair<string, CommentBlock>  item  in  Items )
			   {
				result. Append ( item. Value. ToString ( ) ) ;
				result. Append ( "\n" ) ;
			    }

			return ( result. ToString ( ). TrimEnd ( ) ) ;
		    }
	    }


	public class CommentBlock	:  XmlCommentNode
	   {
		// Node name (ie, the value of the "name" attribute)
		public string		Name		{ get ; set ; }
		public string		Category	{ get ; set ; }
		public string []	TextLines	{ get ; private set ; }
		protected string	UnderlyingText ;


		public		CommentBlock ( ) : base ( ) { }

		public  CommentBlock ( Comments  parent, XmlNode  node )
		   {
			Initialize ( parent, node ) ;
		    }


		public override string   Text		
		   {
			get { return ( UnderlyingText ) ; }
			set { ParseText ( value ) ; }
		    }

		public override void  Initialize ( Comments  parent, XmlNode  node )
		   {
			base. Initialize ( parent, node ) ;

			Name		=  
			Category	=  GetAttributeValue ( "category" ) ;
			Text		=  GetNodeText ( false ) ;
		    }


		public override string  ToString ( )
		   {
			StringBuilder	result		=  new StringBuilder ( GetOpeningTag ( true ) ) ;


			result. Append ( "\n" ) ;

			foreach  ( string  line  in  TextLines )
			   {
				result. Append ( "\t" ) ;
				result. Append ( line ) ;
				result. Append ( "\n" ) ;
			    }

			result. Append ( GetClosingTag ( ) ) ;

			return ( result. ToString ( ) ) ;
		    }


		/// <summary>
		/// Parses a comment block and preserve its original relative alignment.
		/// </summary>
		/// <param name="text">Text (node content) to be parsed.</param>
		protected void  ParseText ( string  text )
		   {
			UnderlyingText			=   text ;
			text				=   text. Replace ( "\r", "" ) ;

			string [] lines			=  text. Split ( new char [] { '\n' } ) ;
			int	min_start_column	=  int. MaxValue ;

			for  ( int  i = 0 ; i  < lines. Length ; i ++ )
			   { 
				lines [i]	=  lines [i]. ExpandTabs ( 8, true ) ;

				int	index		=  Array. FindIndex ( lines [i]. ToCharArray ( ), 
									ch => ! char. IsWhiteSpace ( ch ) ) ;

				if  ( index  >=  0  &&  index  <  min_start_column )
					min_start_column	=  index ;
			    }

			for  ( int  i = 0 ; i  <  lines. Length ; i ++ )
			   {
				if  ( lines [i]. Length  >  min_start_column )
					lines [i]	=  lines [i]. Substring ( min_start_column ) ;
			    }

			TextLines	=  lines ;
		    }
	    }
    }
