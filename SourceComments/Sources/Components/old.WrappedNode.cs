/**************************************************************************************************************

    NAME
	Author.cs

    DESCRIPTION
	Encapsulates an XmlNode element.

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
using  Thrak. Types ;
using  Thrak. Xml ;


namespace Wuthering. WutheringComments
   {
	/// <summary>
	/// Wraps an existing XmlNode object.
	/// </summary>
	public class WrappedNode
	   {
		public XmlValidatedDocument	Parent		{ get ; private set ; }
		public XmlNode			Node		{ get ; private set ; }


		public WrappedNode ( XmlValidatedDocument  document, XmlNode  node )
		   {
			Parent		=  document ;
			Node		=  node ;
		    }


		public override string ToString ( )
		   {
			return ( Node. GetOpeningTag ( true ) ) ;
		    }
	    }


	/// <summary>
	/// Wraps an existing XmlNode object and specify the attribute who will be used as the node name.
	/// </summary>
	public class  NamedWrappedNode	:  WrappedNode
	   {
		protected string	NameAttributeName	{ get ; private set ; }


		public  NamedWrappedNode ( XmlValidatedDocument  document, string  name_attrname, XmlNode  node ) : 
				base ( document, node ) 
		   { 
			NameAttributeName	=  name_attrname ;
		    }


		public string  Name
		   {
			get { return ( Node. GetAttributeValue ( NameAttributeName ) ) ; }
			set { Node. SetAttributeValue ( NameAttributeName, value ) ; }
		    }
	    }


	/// <summary>
	/// Implements a list of named Xml nodes.
	/// </summary>
	public class WrappedNodeList<T>
			where T : NamedWrappedNode
	   {
		public XmlValidatedDocument		Parent		{ get ; private set ; }
		public XmlNode				Node		{ get ; private set ; }
		protected List<T>			NodeList	=  new List<T> ( ) ;


		public WrappedNodeList ( XmlValidatedDocument  document = null, XmlNode  node = null )
		   {
			Parent		=  document ;
			Node		=  node ;
		    }


		/// <summary>
		/// Add the specified node to the list. Throws an exception if the node is already defined.
		/// </summary>
		/// <param name="node">Node to be added.</param>
		public void  Add ( T  node )
		   {
			string		name	=  node. Name ;
			T		search	=  __find ( name ) ;

			if  ( search  ==  null )			
				NodeList. Add ( node ) ;
			else
				throw new XmlException ( "Tried to add an existing node \"" + name + "\"" ) ;
		    }


		/// <summary>
		/// Renames an existing node.
		/// </summary>
		/// <param name="old_name">Old node name</param>
		/// <param name="new_name">New node name</param>
		public void  Rename ( string  old_name, string  new_name )
		   {
			T	old_node	=  __find ( old_name ),
				new_node	=  __find ( new_name ) ;

			if  ( old_node  ==  null )
				throw new XmlException ( "Tried to rename a non-existing node \"" + old_name + "\"" ) ;

			if  ( new_node  !=  null )
				throw new XmlException ( "Rename node \"" + old_name + "\" : node \"" + new_name + "\" already exists." ) ;
				
			old_node. Name	=  new_name ;
		    }


		/// <summary>
		/// Removes an existing node.
		/// </summary>
		/// <param name="name">Name of the node to be removed.</param>
		public void  Remove ( string  name )
		   {
			T	node	=  __find ( name ) ;

			if  ( node  ==  null )
				throw new XmlException ( "Tried to remove a non-existing node \"" + name + "\"" ) ;
			else
				NodeList. Remove ( node ) ;
		    }


		/// <summary>
		/// Checks if the specified node exists.
		/// </summary>
		/// <param name="name">Name of the node to be checked for existence.</param>
		/// <returns>True if the node exists, false otherwise.</returns>
		public bool  Exists ( string  name )
		   {
			return ( __find ( name )  !=  null ) ;
		    }


		/// <summary>
		/// Finds a node by its name.
		/// </summary>
		/// <param name="name">Name of the node to be searched.</param>
		/// <returns>A NamedWrappedNode object if the specified node exists, false otherwise.</returns>
		private T  __find ( string  name )
		   {
			foreach  ( T  node  in  NodeList )
			   {
				if  ( string. Compare ( node. Name, name, true )  ==  0 )
					return ( node ) ;
			    }

			return ( null ) ;
		    }
	    }


	/// <summary>
	/// Encapsulates the &lt;groups&gt; node and all its child &lt;group&gt; nodes.
	/// </summary>
	public abstract class WrappedCommentGroupList<T,CT>	:  WrappedNodeList<T>
		where  T : NamedWrappedNode
	   {
		protected string	Tag		{ get ; private set ; }
		protected string	Title		{ get ; private set ; }

		/// <summary>
		/// Parses the &lt;groups&gt; node and its child &lt;group&gt; nodes.
		/// </summary>
		/// <param name="document">Base xml document.</param>
		/// <param name="base_node">Node related to the &lt;template&gt; node.</param>
		public WrappedCommentGroupList ( XmlValidatedDocument	document, 
						 XmlNode		base_node,  
						 string			tag,
						 string			title	=  null		) : base ( document, base_node )
		   { 
			Tag		=  tag. ToLower ( ) ;
			
			if  ( title  ==  null )
				title	=  tag ;

			Title	=  title ;


			foreach  ( XmlNode node  in  base_node. ChildNodes )
			   {
				if  ( node. Name  ==  Tag )
				   {
					T		item	=  CreateChild ( document, node ) ;

					try
					   { 
						Add ( item ) ;
					    }
					catch ( XmlException  e )
					   {
						Parent. AddValidationMessage ( XmlParseErrorSeverity. Error, 
								Title. UppercaseFirst ( ) + " \"" +
								item. Name + "\" is defined more than once." ) ;
					    }
				    }
				else
						Parent. AddValidationMessage ( XmlParseErrorSeverity. Error, "Unrecognized tag <" +
									node. Name + ">" ) ;
			    }
		    }


		/// <summary>
		/// Creates a child comment.
		/// </summary>
		protected abstract T	CreateChild ( XmlValidatedDocument  document, XmlNode  base_node ) ;


		/// <summary>
		/// Returns the xml code corresponding to this node.
		/// </summary>
		public override string  ToString ( )
		   {
			StringBuilder	result	=  new StringBuilder ( ) ;

			result. Append ( Node. GetOpeningTag ( ) ) ;
			result. Append ( CommentsParser. EOL ) ;

			foreach  ( T  item in NodeList )
			   {
				result. Append ( '\t' ) ;
				result. Append ( item. ToString ( ). Replace ( "\n", "\n\t" ) ) ;
				result. Append ( CommentsParser. EOL ) ;
			    }

			result. Append ( Node. GetClosingTag ( ) ) ;
			return ( result. ToString ( ) ) ;
		    }
	    }

	/// <summary>
	/// Encapsulates a comment child node.
	/// </summary>
	public abstract class  WrappedCommentGroupNode<T>	:  NamedWrappedNode
		where T : Comment
	   {
		protected string	Tag		{ get ; private set ; }
		// Inner <comment> nodes
		public Comments<T>	Comments	{ get ; private set ; }


		/// <summary>
		/// Parses the &lt;template&gt; node and its child &lt;comment&gt; nodes.
		/// </summary>
		/// <param name="document">Base xml document.</param>
		/// <param name="base_node">Node related to the &lt;categories&gt; node.</param>
		public WrappedCommentGroupNode ( XmlValidatedDocument  document, XmlNode  base_node, string  tag ) : 
				base ( document, tag, base_node )
		   { 
			Comments	=  CreateList ( document, base_node ) ;

			foreach  ( XmlNode node  in  base_node. ChildNodes )
			   {
				if  ( node. Name  ==  tag )
				   {
					T		item	=  CreateChild ( document, node ) ;

					try
					   { 
						Comments. Add ( item ) ;
					    }
					catch ( XmlException  e )
					   {
						Parent. AddValidationMessage ( XmlParseErrorSeverity. Error, 
								"Comment \"" +
								item. Name + "\" is defined more than once." ) ;
					    }
				    }
				else
						Parent. AddValidationMessage ( XmlParseErrorSeverity. Error, "Unrecognized tag <" +
									node. Name + ">" ) ;
			    }
		    }

		/// <summary>
		/// Creates a child comment.
		/// </summary>
		protected abstract T	CreateChild ( XmlValidatedDocument  document, XmlNode  base_node ) ;

		/// <summary>
		/// Creates the comment list.
		/// </summary>
		protected abstract Comments<T>	CreateList ( XmlValidatedDocument  document, XmlNode  base_node ) ;


		/// <summary>
		/// Returns the xml code corresponding to this node.
		/// </summary>
		public override string ToString ( )
		   {
			StringBuilder	result	=  new StringBuilder ( ) ;

			result. Append ( Node. GetOpeningTag ( ) ) ;
			result. Append ( CommentsParser. EOL ) ;

			result. Append ( '\t' ) ;
			result. Append ( Comments. ToString ( ). Replace ( "\n", "\n\t" ) ) ;
			result. Append ( CommentsParser. EOL ) ;

			result. Append ( Node. GetClosingTag ( ) ) ;

			return ( result. ToString ( ) ) ;
		    }
	    }

    }
