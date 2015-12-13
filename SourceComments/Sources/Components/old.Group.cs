/**************************************************************************************************************

    NAME
	Groups.cs

    DESCRIPTION
	Encapsulates the <groups> and <group> nodes.

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
	/// Encapsulates the &lt;groups&gt; node and all its child &lt;group&gt; nodes.
	/// </summary>
	public class Groups		:  WrappedCommentGroupList<Group, GroupComment>
	   {
		/// <summary>
		/// Parses the &lt;groups&gt; node and its child &lt;group&gt; nodes.
		/// </summary>
		/// <param name="document">Base xml document.</param>
		/// <param name="base_node">Node related to the &lt;template&gt; node.</param>
		public Groups ( XmlValidatedDocument  document, XmlNode  base_node ) : base ( document, base_node, "group" )
		   { }

		protected override Group  CreateChild ( XmlValidatedDocument  document, XmlNode  base_node )
		   { return ( new Group ( document, base_node ) ) ; }
	    }


	/// <summary>
	/// Encapsulates a &lt;group&gt; node and all its &lt;comment&gt; child nodes.
	/// </summary>
	public class  Group		:  WrappedCommentGroupNode<GroupComment>
	   {
		/// <summary>
		/// Parses the &lt;group&gt; node and its child &lt;comment&gt; nodes.
		/// </summary>
		/// <param name="document">Base xml document.</param>
		/// <param name="base_node">Node related to the &lt;categories&gt; node.</param>
		public Group ( XmlValidatedDocument  document, XmlNode  base_node ) : base ( document, base_node, "language" )
		   { }
			

		protected override GroupComment  CreateChild ( XmlValidatedDocument  document, XmlNode  base_node )
		   { return ( new GroupComment ( document, base_node ) ) ; }

		protected override GroupComments  CreateList ( XmlValidatedDocument  document, XmlNode  base_node )
		   { return ( new GroupComments ( document, base_node ) ) ; }
	    }
    }