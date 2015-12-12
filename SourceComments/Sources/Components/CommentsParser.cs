/**************************************************************************************************************

    NAME
	XmlComments.cs

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

using  Utilities ;
using  Thrak. Xml ;


namespace Wuthering. WutheringComments
   {
	public class CommentsParser	: XmlValidatedDocument
	   {
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


		/// <summary>
		/// Loads and validates the specified xml data, which holds a <wuthering-comments> definition.
		/// </summary>
		public CommentsParser ( string  xml_data  =  null ) :
				base  ( ( xml_data  ==  null ) ?  StockDefinitions : xml_data, StockSchema )
		   {
		    }


		/// <summary>
		/// Validates the contents of the comments file.
		/// </summary>
		protected override void ValidateStructure ( )
		   {
		    }
	    }
    }
