/**************************************************************************************************************

    NAME
	Templates.cs

    DESCRIPTION
	Encapsulates the <templates> and <template> nodes.

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
	/// Encapsulates the &lt;templates&gt; node and all its child &lt;template&gt; nodes.
	/// </summary>
	public class Templates		:  WrappedCommentGroupList<Template, Comment>
	   {
		/// <summary>
		/// Parses the &lt;templates&gt; node and its child &lt;template&gt; nodes.
		/// </summary>
		/// <param name="document">Base xml document.</param>
		/// <param name="base_node">Node related to the &lt;template&gt; node.</param>
		public Templates ( XmlValidatedDocument  document, XmlNode  base_node ) : base ( document, base_node, "template" )
		   { }


		protected override Template  CreateChild ( XmlValidatedDocument  document, XmlNode  base_node )
		   { return ( new Template ( document, base_node ) ) ; }

		protected override TemplateComments ( XmlValidatedDocument  document, XmlNode  base_node )
		   { return ( new TemplateComments ( document, base_node ) ) ; }
	    }


	/// <summary>
	/// Encapsulates a &lt;template&gt; node and all its &lt;comment&gt; child nodes.
	/// </summary>
	public class  Template		:  WrappedCommentGroupNode<Comment>
	   {
		/// <summary>
		/// Parses the &lt;template&gt; node and its child &lt;comment&gt; nodes.
		/// </summary>
		/// <param name="document">Base xml document.</param>
		/// <param name="base_node">Node related to the &lt;categories&gt; node.</param>
		public Template ( XmlValidatedDocument  document, XmlNode  base_node ) : base ( document, base_node, "name" )
		   { }


		protected override Comment	CreateChild ( XmlValidatedDocument  document, XmlNode  base_node )
		   { return ( new Comment ( document, base_node ) ) ; }
	    }
    }