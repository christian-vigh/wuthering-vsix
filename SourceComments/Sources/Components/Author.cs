/**************************************************************************************************************

    NAME
	Author.cs

    DESCRIPTION
	Encapsulates a <author> node.

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
	/// Wraps the &lt;author&gt; tag.
	/// </summary>
	public class Author	:  WrappedNode
	   {
		public  Author ( XmlValidatedDocument  document, XmlNode  node )  : base ( document, node ) 
		   { }


		/// <summary>
		/// Gets/sets the author name.
		/// </summary>
		public string  Name
		   {
			get { return ( Node. GetAttributeValue ( "name" ) ) ; }
			set { Node. SetAttributeValue ( "name", value ) ; }
		    }


		/// <summary>
		/// Gets/sets the author initials.
		/// </summary>
		public string  Initials
		   {
			get { return ( Node. GetAttributeValue ( "initials" ) ) ; }
			set { Node. SetAttributeValue ( "initials", value ) ; }
		    }


		/// <summary>
		/// Gets/sets the author email.
		/// </summary>
		public string  Email
		   {
			get { return ( Node. GetAttributeValue ( "email" ) ) ; }
			set { Node. SetAttributeValue ( "email", value ) ; }
		    }

		/// <summary>
		/// Gets/sets the author website.
		/// </summary>
		public string  WebSite
		   {
			get { return ( Node. GetAttributeValue ( "website" ) ) ; }
			set { Node. SetAttributeValue ( "website", value ) ; }
		    }
	    }
    }
