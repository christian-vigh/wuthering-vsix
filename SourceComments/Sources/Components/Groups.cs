/**************************************************************************************************************

    NAME
	Groups.cs

    DESCRIPTION
	Encapsulates the <groups>, <group> and <comment> tree.

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
	/// Encapsulates a &lt;groups&gt; node. 
	/// </summary>
	public class	Groups	:  WrappedGroupList<Group,GroupComment>
	   {
		public  Groups ( XmlValidatedDocument  document, XmlNode  base_node ) :
				base ( document, base_node, "group", "language" )
		   { }

		protected override  Group  CreateObject ( XmlValidatedDocument  document, XmlNode  base_node )
		   { return ( new Group ( document, base_node ) ) ; }
	    }


	/// <summary>
	/// Encapsulates &lt;group&gt; nodes within a &lt;group&gt; node. 
	/// </summary>
	public class	Group	:  WrappedGroupItem<GroupComment>
	   {
		private string []		__Extensions	=  null ;

		public Group ( XmlValidatedDocument  document, XmlNode  base_node ) :
				base ( document, base_node, "comment", "category" )
		   { }


		protected override  GroupComment  CreateObject ( XmlValidatedDocument  document, XmlNode  base_node )
		   { return ( new GroupComment ( document, base_node ) ) ; }


		/// <summary>
		/// Gets/sets the extension list as a string.
		/// </summary>
		public string  ExtensionsAsString
		   {
			get 
			   { 
				if  ( __Extensions  ==  null ) 
					__Extensions	=  StringToExtensionList ( Node. GetAttributeValue ( "extensions", "" ) ) ;

				return ( ExtensionListToString ( __Extensions ) ) ;
			    }

			set
			   {
				__Extensions	=  StringToExtensionList ( value ) ;

				Node. SetAttributeValue ( "extensions", ExtensionListToString ( __Extensions ) ) ;
			    }
		    }


		/// <summary>
		/// Gets/sets the extension list as an array of strings, one for each extension.
		/// </summary>
		public string []  Extensions
		   {
			get 
			   { 
				if  ( __Extensions  ==  null ) 
					__Extensions	=  StringToExtensionList ( Node. GetAttributeValue ( "extensions", "" ) ) ;

				return ( __Extensions ) ;
			    }

			set
			   {
				__Extensions	=  value ;

				Node. SetAttributeValue ( "extensions", ExtensionListToString ( __Extensions ) ) ;
			    }
		    }


		/// <summary>
		/// Converts an extension list to a string.
		/// </summary>
		private string  ExtensionListToString ( string []  list )
		   { return ( String. Join ( " ", list ) ) ; }


		/// <summary>
		/// Converts a string to an extension list.
		/// </summary>
		private string []  StringToExtensionList ( string  value )
		   {
			string []	parts		=  value.Split ( new char [] { ' ', '\t' } ) ;
			List<string>	elements	=  new List<string> ( ) ;

			foreach  ( string  part  in  parts )
			   {
				string	newpart		=  part. Trim ( ) ;

				if  ( newpart. Length  >   0  &&  newpart [0]  ==  '.' )
					newpart	=  newpart. Substring ( 1 ) ;	

				if  ( ! String. IsNullOrEmpty ( newpart ) )
					elements. Add ( newpart. ToLower ( ) ) ;
			    }

			return ( elements. ToArray ( ) ) ;
		    }
	    }


	/// <summary>
	/// Encapsulates a &lt;comment&gt; node within a &lt;Group&gt; node. 
	/// </summary>
	public class  GroupComment	:  Comment
	   {
		public	GroupComment ( XmlValidatedDocument  document, XmlNode  node ) : base ( document, node )
		   { }


		/// <summary>
		/// Returns true if this group comment does not have any content, but just references a template.
		/// </summary>
		public bool  IsTemplateReference
		   {
			get 
			   {
				return ( ! String. IsNullOrEmpty ( Template ) )  ;
			    }
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


		/// <summary>
		/// Returns a shortened version if the comment only references a template.
		/// </summary>
		public override string  ToString  ( )
		   {
			if  ( IsTemplateReference )
				return ( Node.GetOpeningTag ( true ) ) ;
			else
				return ( base. ToString ( ) ) ;
		    }
	    }
    }
