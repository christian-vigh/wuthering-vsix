/**************************************************************************************************************

    NAME
	XmlCommentBase.cs

    DESCRIPTION
	Base classes for Xml nodes and collections of xml nodes.

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
	/// <summary>
	/// Base class for all the nodes within the definition file.
	/// </summary>
	public class XmlCommentNode
	   {
		// Parent XmlComments root object
		public	Comments	Parent ;
		// Original xml node
		public	XmlNode		Node		{ get ; protected set ; }
		// Node nesting level (0 = root tag). The document element is not included into this count
		public  int		NestingLevel	{ get ; protected set ; }
		// Node text
		public virtual string	Name		{  get ; set ; }
		// Node text
		public virtual string	Text		{  get ; set ; }
		// Indicates whether this node contains children (XmlCommentListNode class)
		protected bool		Compound	=  false ;
		


		public XmlCommentNode ( Comments  parent, XmlNode  nd )
		   {
			Initialize ( parent, nd ) ;
		    }


		/// <summary>
		/// Constructor and initializer.
		/// The only justification to have a public constructor and an initializer method is due
		/// to the fact that the XmlCommentListNode is a template class that scans child xml nodes
		/// and instanciate an object of the template type parameter. This requires a public
		/// constructor with no parameters.
		/// The Initialize() method is kept public, in case someone would like to use the constructor
		/// without parameters.
		/// </summary>
		public		XmlCommentNode ( )
		   { }


		public virtual  void	Initialize ( Comments  parent, XmlNode  nd )
		   {
			Parent		=  parent ;
			Node		=  nd ;
			Text		=  GetNodeText ( false ) ;
			NestingLevel	=  0 ;
			nd		=  nd. ParentNode ;
			
			while  ( nd  !=  null )
			   {
				NestingLevel ++ ;
				nd	=  nd. ParentNode ;
			    }

			NestingLevel -- ;	// Count one less, since the top level node is the XmlDocument itself
		    }


		/// <summary>
		/// Gets an attribute value, catching all exceptions.
		/// </summary>
		/// <param name="name">Attribute name.</param>
		/// <param name="default_value">Default value to use if the attribute does not exist.</param>
		/// <returns>The attribute value.</returns>
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


		/// <summary>
		/// Returns a node's attributes as a string.
		/// </summary>
		public string  GetAttributesAsString ( )
		   {
			List<string>	attributes	=  new List<string> ( ) ;

			foreach  ( XmlAttribute  attr  in  Node. Attributes )
				attributes. Add ( GetAttributeAsString ( attr ) ) ;
				
			string		result		=  String. Join ( " ", attributes ) ;

			if  ( string. IsNullOrWhiteSpace ( result ) )
				return ( "" ) ;
			else
				return ( " " + result ) ;
		    }


		/// <summary>
		/// Returns an attribute as a string : attr="value"
		/// </summary>
		public string	GetAttributeAsString ( XmlAttribute  attr )
		   {
			string		name	=  attr. Name ;
			string		value	=  attr. Value ;
			string		quote	=  "\"" ;

			return ( name + "=" + quote + value + quote ) ;
		    }


		/// <summary>
		/// Returns the starting xml node tag as a string, including its attributes.
		/// </summary>
		public string  GetOpeningTag ( bool  compound )
		   {
			string		end	=  ( compound ) ?  ">" : "/>" ;

			return ( "<" + Node. Name + GetAttributesAsString ( ) + end ) ;
		    }


		/// <summary>
		/// Returns the closing xml node tag.
		/// </summary>
		/// <returns></returns>
		public string  GetClosingTag ( )
		   {
			return ( "</" + Node. Name + ">" ) ;
		    }


		/// <summary>
		/// Gets the text contained in an xml node.
		/// </summary>
		/// <returns>The xml node text.</returns>
		public string  GetNodeText ( bool  trim = false )
		   {
			string		text		=  Node. InnerText ;
			int		start		=  0,
					end		=  text. Length - 1 ;

			if  ( String. IsNullOrEmpty ( text ) )
				return ( "" ) ;

			// Skip the potential cr+lf after the opening tag
			if  ( text [ start ]  ==  '\n'  ||  text [ start ]  ==  '\r' )
				start ++ ;

			if  ( text [ start ]  ==  '\n'  ||  text [ start ]  ==  '\r' )
				start ++ ;

			// Remove trailing whitespaces
			if  ( text [ end ]  ==  ' '  ||  text [ end ]  ==  '\t' )
			   {
				while  ( end  >  start  &&  ( text [ end ]  ==  ' '  ||  text [ end ]  ==  '\t' ) ) 
					end -- ;
			    }

			// Remove the very last crlf (make sure the last line doesn't end with spaces because
			// we will split the node text on newlines)
			if  ( text [ end ]  ==  '\n'  ||  text [ end ]  ==  '\r' )
				end -- ;

			if  ( text [ end ]  ==  '\n'  ||  text [ end ]  ==  '\r' )
				end -- ;

			if  ( start  >=  end )
				return ( String. Empty ) ;
			else
				return ( text. Substring ( start, end - start + 1 ) ) ;
		    }


		public override string ToString ( )
		   {
			if  ( Compound  ||  ! String. IsNullOrEmpty ( Text ) )
				return ( GetOpeningTag ( true ) + Text + GetClosingTag ( ) ) ;
			else 
				return ( GetOpeningTag ( false ) ) ;
		    }


		public virtual string  ToXmlString ( )
		   {
			string		padding		=  "". PadLeft ( NestingLevel, '\t' ) ;

			return ( padding + ToString ( ). Replace ( "\n", "\n" + padding ) ) ;
		    }
	    }


	/// <summary>
	/// In the comment definition xsd, it happens that every node that represents a list holds
	/// child nodes having the same tag name. For example, the "categories" node contains only
	/// child nodes of type "category".
	/// This class takes advantage of this situation and automatically parses child nodes when
	/// instanciated with a parent node.
	/// Note also that whatever the parent node type is, child nodes always have a "name"
	/// attribute.
	/// </summary>
	/// <typeparam name="T">Class type of the child nodes.</typeparam>
	public class	XmlCommentListNode<T> 		:  XmlCommentNode
				where T : XmlCommentNode, new ()
	   {
		public Dictionary<string, T>		Items	{ get ; private set ; }
		protected string			SubtagName ;

		public	XmlCommentListNode ( )
		   { Compound = true ; }


		public XmlCommentListNode ( Comments  parent, XmlNode  nd, string  subtag )
		   {
			Compound	=  true ;
			Initialize ( parent, nd, subtag ) ;
		    }


		/// <summary>
		/// Initialize this instance and instanciates every child node.
		/// </summary>
		public virtual void	Initialize ( Comments  parent, XmlNode  nd, string  subtag )
		   {
			base. Initialize ( parent, nd ) ;

			Items		=  new Dictionary<string,T> ( StringComparer. CurrentCultureIgnoreCase ) ;
			SubtagName	=  subtag ;

			foreach  ( XmlNode  child  in  nd. ChildNodes )
			   {
				T	item		=  new T ( ) ;

				// Only retain nodes having the specified tag
				if  ( String. Compare ( child. Name, subtag, true )  ==  0 )
				   {
					item. Initialize ( parent, child ) ;
					Items [ item. Name ]	=  item ;
				    }
			    }
		    }


		/// <summary>
		/// Access this list as an array, using the value of the "name" attribute to retrieve
		/// or set a child node.
		/// </summary>
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


		/// <summary>
		/// Returns the xml contents of this node.
		/// </summary>
		public override string ToString ( )
		   {
			StringBuilder	result		=  new StringBuilder ( GetOpeningTag ( true ) + "\n" ) ;

			foreach  ( KeyValuePair<string, T>  item  in  Items )
			   {
				string		xml	=  item. Value. ToString ( ) ;

				result. Append ( "\t" ) ;
				result. Append ( xml. Replace ( "\n", "\n\t" ) + "\n" ) ;
			    }

			result. Append ( GetClosingTag ( ) ) ;

			return ( result. ToString ( ) ) ;
		    }
	   }
    }
