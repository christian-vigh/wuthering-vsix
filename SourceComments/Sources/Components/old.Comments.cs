/**************************************************************************************************************

    NAME
	Comments.cs

    DESCRIPTION
	Encapsulates the <template>, <group> and <comment> nodes.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/012/12]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using  System ;
using  System. Collections. Generic ;
using  System. Linq ;
using  System. Text ;
using  System. Threading. Tasks ;
using  System. Xml ;

using  Utilities ;
using  Thrak. Types ;
using  Thrak. Xml ;


namespace Wuthering. WutheringComments
   {
	/// <summary>
	/// Encapsulates &lt;comment&gt; nodes within a &lt;template&gt; node.
	/// </summary>
	public class  TemplateComments	:  Comments<TemplateComment>
	   {
		public TemplateComments ( XmlValidatedDocument  document, XmlNode  base_node ) : base ( document, base_node )
		   { }


		protected override TemplateComment  CreateChild ( XmlNode  node )
		   {
			return ( new TemplateComment ( Parent, node ) ) ;
		    }
	    }


	/// <summary>
	/// Encapsulates &lt;comment&gt; nodes within a &lt;group&gt; node.
	/// </summary>
	public class  GroupComments	:  Comments<GroupComment>
	   {
		public GroupComments ( XmlValidatedDocument  document, XmlNode  base_node ) : base ( document, base_node )
		   { }


		protected override GroupComment  CreateChild ( XmlNode  node )
		   {
			return ( new GroupComment ( Parent, node ) ) ;
		    }
	    }


	/// <summary>
	/// Encapsulates a &lt;comment&gt; node within a &lt;template&gt; node. 
	/// This is also a base class for comments within a &lt;group&gt; node.
	/// </summary>
	public class  Comment		:  NamedWrappedNode
	   {
		public string []	TextLines ;


		public	Comment ( XmlValidatedDocument  document, XmlNode  node ) : base ( document, "category", node )
		   {
			TextLines	=  node. GetAlignedTextLines ( ) ; 
		    }


		/// <summary>
		/// Returns the xml code corresponding to this node.
		/// </summary>
		public override string  ToString ( )
		   {
			StringBuilder	result	=  new StringBuilder ( ) ;

			result. Append ( Node. GetOpeningTag ( ) ) ;
			result. Append ( CommentsParser. EOL ) ;

			foreach  ( string  line  in  TextLines )
			   {
				result. Append ( '\t' ) ;
				result. Append ( line ) ;
				result. Append ( CommentsParser. EOL ) ;
			    }

			result. Append ( Node. GetClosingTag ( ) ) ;
			return ( result. ToString ( ) ) ;
		    }
	    }


	/// <summary>
	/// Encapsulates a &lt;comment&gt; node within a &lt;template&gt; node. 
	/// </summary>
	public class  TemplateComment	:  Comment
	   {
		public	TemplateComment ( XmlValidatedDocument  document, XmlNode  node ) : base ( document, node )
		   { }
	    }


	/// <summary>
	/// Encapsulates a &lt;comment&gt; node within a &lt;group&gt; node. 
	/// </summary>
	public class  GroupComment	:  Comment
	   {
		public	GroupComment ( XmlValidatedDocument  document, XmlNode  node ) : base ( document, node )
		   {
		    }


		/// <summary>
		/// Gets/sets the template reference for this comment.
		/// </summary>
		public string  Template
		   {
			get { return ( Node. GetAttributeValue ( "template" ) ) ; }
			set { Node. SetAttributeValue ( "template", value ) ; }
		    }


		/// <summary>
		/// Gets/sets 
		/// </summary>
		public string  TemplateCategory
		   {
			get { return ( Node. GetAttributeValue ( "template-category" ) ) ; }
			set { Node. SetAttributeValue ( "template-category", value ) ; }
		    }
	    }
    }