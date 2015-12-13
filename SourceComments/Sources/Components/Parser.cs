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
		internal const string		EOL		=  "\r\n" ;

		// Contents of embedded definitions and schema
		public static string	StockDefinitions	{ get ; private set ; }
		public static string	StockSchema		{ get ; private set ; }

		// Definitions
		public Author		Author			{ get ; private set ; }
		public Categories	Categories		{ get ; private set ; } 
		public Templates	Templates		{ get ; private set ; } 
		public Groups		Groups			{ get ; private set ; } 

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
		   { }


		/// <summary>
		/// Validates the contents of the comments file.
		/// </summary>
		protected override void ValidateStructure ( )
		   {
			foreach  ( XmlNode  node  in  DocumentElement )
			   {
				if  ( node. NodeType  !=  XmlNodeType. Element )
					continue ;

				switch  ( node. Name. ToLower ( ) )
				   {
					case	"author" :
						Author		=  new Author ( this, node ) ;
						break ;

					case	"categories" :
						Categories	=  new Categories ( this, node ) ;
						break ;

					case	"templates" :
						Templates	=  new Templates ( this, node ) ;
						break ;

					case	"groups" :
						Groups		=  new Groups ( this, node ) ;
						break ;

					default :
						AddValidationMessage ( XmlParseErrorSeverity. Error, "Unrecognized tag <" +
									node. Name + ">" ) ;
						break ;
				    }
			    }

			// Check that all required nodes are present (paranoia, since the xsd validation has already been performed)
			if  ( Author  ==  null )
				AddValidationMessage ( XmlParseErrorSeverity. Error, "Missing tag '<author>'" ) ;

			if  ( Categories  ==  null )
				AddValidationMessage ( XmlParseErrorSeverity. Error, "Missing tag '<categories>'" ) ;

			if  ( Templates  ==  null )
				AddValidationMessage ( XmlParseErrorSeverity. Error, "Missing tag '<templates>'" ) ;

			if  ( Groups  ==  null )
				AddValidationMessage ( XmlParseErrorSeverity. Error, "Missing tag '<groups>'" ) ;

			// Checks on <templates> entries
			if  ( Templates  !=  null )
			   {
				// Check that each comment in the <template> nodes reference an existing category
				foreach  ( Template  template  in  Templates )
				   {
					foreach  ( Comment  comment  in  template. Comments )
					   {
						if  ( ! Categories. Exists ( comment. Name ) )
							AddValidationMessage ( XmlParseErrorSeverity. Error, 
								"Comment category \"" + comment. Name + "\" specified in template \"" +
								template. Name  + "\" does not exist" ) ;
					    }
				    }

				// Check that template names are unique
				if  ( Templates. Count  ==  0 )
					AddValidationMessage ( XmlParseErrorSeverity. Warning, "No template defined in the <templates> node" ) ;
				else
				   { 
					for  ( int  i = 1 ; i  <  Templates. Count ; i ++ )
					    {
						for  ( int  j = 0 ; j  <  i ; j ++ )
						   {
							if  ( String. Compare ( Templates [i]. Name, Templates [j]. Name, true )  ==  0 )
							   {
								AddValidationMessage ( XmlParseErrorSeverity. Error, 
									"Template \"" + Templates [i]. Name + "\" is defined more than once" ) ;
								break ;
							    }
						    }
					     }
				    }
			    }

			// Checks on <groups> entries
			if  ( Groups  !=  null )
			   {
				// Check that each comment in the <group> nodes reference an existing category
				foreach  ( Group  group  in  Groups )
				   {
					foreach  ( Comment  comment  in  group. Comments )
					   {
						if  ( ! Categories. Exists ( comment. Name ) )
							AddValidationMessage ( XmlParseErrorSeverity. Error, 
								"Comment category \"" + comment. Name + "\" specified in group \"" +
								group. Name  + "\" does not exist" ) ;
					    }

					if  ( String. IsNullOrWhiteSpace  ( group. ExtensionsAsString ) )
						AddValidationMessage ( XmlParseErrorSeverity. Error, 
							"Group \"" + group. Name  + "\" is not associated with any file extension ('extensions' attribute value is empty)" ) ;
				    }

				// Check that group names are unique
				if  ( Groups. Count  ==  0 )
					AddValidationMessage ( XmlParseErrorSeverity. Warning, "No group defined in the <groups> node" ) ;
				else
				   { 
					for  ( int  i = 1 ; i  <  Groups. Count ; i ++ )
					    {
						for  ( int  j = 0 ; j  <  i ; j ++ )
						   {
							if  ( String. Compare ( Groups [i]. Name, Groups [j]. Name, true )  ==  0 )
							   {
								AddValidationMessage ( XmlParseErrorSeverity. Error, 
									"Group \"" + Groups [i]. Name + "\" is defined more than once" ) ;
								break ;
							    }
						    }
					     }
				    }

			    }
		    }


		/// <summary>
		/// Returns the xml code corresponding to this node.
		/// </summary>
		public override string  ToString ( )
		   {
			StringBuilder		result	=  new StringBuilder ( ) ;
			

			// Opening tag			
			result. Append ( DocumentElement.GetOpeningTag ( ) ) ;
			result. Append ( EOL ) ;
			result. Append ( EOL ) ;

			// Author node
			result. Append ( '\t' ) ;
			result. Append ( Author. Node. GetOpeningTag ( true ) ) ;
			result. Append ( EOL ) ;
			result. Append ( EOL ) ;

			// Categories node
			result. Append ( '\t' ) ;
			result. Append ( Categories. ToString ( ). Replace ( "\n", "\n\t" ) ) ;
			result. Append ( EOL ) ;
			result. Append ( EOL ) ;

			// Templates node
			result. Append ( '\t' ) ;
			result. Append ( Templates. ToString ( ). Replace ( "\n", "\n\t" ) ) ;
			result. Append ( EOL ) ;
			result. Append ( EOL ) ;

			// Groups node
			result. Append ( '\t' ) ;
			result. Append ( Groups. ToString ( ). Replace ( "\n", "\n\t" ) ) ;
			result. Append ( EOL ) ;
			result. Append ( EOL ) ;

			// Closing tag 
			result. Append ( DocumentElement. GetClosingTag ( ) ) ;
			result. Append ( EOL ) ;

			return ( result. ToString ( ) ) ;
		    }
	    }
    }
