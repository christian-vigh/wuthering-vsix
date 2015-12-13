/**************************************************************************************************************

    NAME
	Templates.cs

    DESCRIPTION
	Encapsulates the <templates>, <template> and <comment> tree.

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
	/// Encapsulates a &lt;templates&gt; node. 
	/// </summary>
	public class	Templates	:  WrappedGroupList<Template,TemplateComment>
	   {
		public  Templates ( XmlValidatedDocument  document, XmlNode  base_node ) :
				base ( document, base_node, "template", "name" )
		   { }

		protected override  Template  CreateObject ( XmlValidatedDocument  document, XmlNode  base_node )
		   { return ( new Template ( document, base_node ) ) ; }
	    }


	/// <summary>
	/// Encapsulates &lt;template&gt; nodes within a &lt;templates&gt; node. 
	/// </summary>
	public class	Template	:  WrappedGroupItem<TemplateComment>
	   {
		public Template ( XmlValidatedDocument  document, XmlNode  base_node ) :
				base ( document, base_node, "comment", "name" )
		   { }


		protected override  TemplateComment  CreateObject ( XmlValidatedDocument  document, XmlNode  base_node )
		   { return ( new TemplateComment ( document, base_node ) ) ; }
	    }


	/// <summary>
	/// Encapsulates a &lt;comment&gt; node within a &lt;template&gt; node. 
	/// </summary>
	public class  TemplateComment	:  Comment
	   {
		public	TemplateComment ( XmlValidatedDocument  document, XmlNode  node ) : base ( document, node )
		   { }
	    }

    }
