/**************************************************************************************************************

    NAME
	CommentsParser.cs

    DESCRIPTION
	A class to load a <wuthering-comments> definition from string/resource/file and save it to a file.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/012/10]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using  System;
using  System. Collections. Generic ;
using  System. IO ;
using  System. Linq ; 
using  System. Reflection ;
using  System. Text ;
using  System. Threading. Tasks ;
using  System. Xml ;


namespace Wuthering. WutheringComments
   {
	/// <summary>
	/// Class used to parse comment definitions from a string. This is also the base class for
	/// the XmlFileComments and XmlResourceComments classes.
	/// </summary>
	public class CommentsParser
	   {
		// The whole definitions tree stored as an object hierarchy
		public Comments		Contents		{ get ; private set ; }
		// XmlDocument
		public XmlDocument	Document		{ get ; private set ; }
		// Text contents after loading
		public string		TextContents		{ get ; private set ; }
		// Contents of embedded definitions and schema
		public static string	StockDefinitions	{ get ; private set ; }
		public static string	StockSchema		{ get ; private set ; }


		/// <summary>
		/// Static constructor. Retrieves the contents of the xml definitions and xsd files embedded in
		/// the resources.
		/// </summary>
		static  CommentsParser ( )
		   {
			StockDefinitions	=  WutheringCommentsPackage. Resources. WutheringCommentsXml ;
			StockSchema		=  WutheringCommentsPackage. Resources. WutheringCommentsXsd ;
		    }

		public  CommentsParser ( )
		   {
		    }

		/// <summary>
		/// Parses &lt;wuthering-comments&gt; definitions from a string.
		/// </summary>
		/// <param name="data">String containing xml data.</param>
		public void  Load ( string  data )
		   {
			Document	=  new XmlDocument ( ) ;
			Document. LoadXml ( data ) ;

			Contents	=  new Comments ( Document. DocumentElement ) ;
			TextContents	=  data ;
		    }


		/// <summary>
		/// Saves current definitions to the specified file.
		/// </summary>
		/// <param name="output">Output file.</param>
		public void   Save ( string  output )
		   {
			File. WriteAllText ( output, ToXmlString ( ) ) ;
		    }

		
		public override string	ToString ( )
		   {
			return ( Contents. ToString ( ) ) ;
		    }


		public string	ToXmlString ( )
		   {
			return ( Contents. ToXmlString ( ) ) ;
		    }
	    }


	/// <summary>
	/// Loads &lt;wuthering-comments&gt; definitions from a file.
	/// </summary>
	public class   XmlFileComments		:  CommentsParser
	   {
		public string	Filename	{ get ; private set ; }

		public  XmlFileComments ( )
		   { }


		public new void  Load ( string  file )
		   {
			StreamReader	reader		=  new StreamReader ( file ) ;
			string		content		=  reader. ReadToEnd ( ) ;

			Filename	=  file ;

			reader. Close ( ) ;
			base. Load  ( content ) ;
		    }
	    }
    }
