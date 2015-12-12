/**************************************************************************************************************

    NAME
	Xml.cs

    DESCRIPTION
	Extensions for Xml objects.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/012/11]     [Author : CV]
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
using  System. Xml. Schema ;
using  System. Xml. XPath ;


namespace Utilities. Xml
   {
# region	Base types and enumerations
	// Just an alias...
	using	XmlParseErrors	=  List<XmlParseError> ;


	/// <summary>
	/// Identifies the parsing step
	/// </summary>
	public enum  XmlParseStep
	   {
		XmlParsing,			// Basic parsing of xml data (using LoadXml)
		XsdValidation,			// Xsd document syntax validation
		XmlValidation,			// Xml validation using the specified xsd data
		UserValidation			// Errors or informational messages can later be added by a derived class,
						// using the AddUserError() method
	    }


	/// <summary>
	/// Error severities. Warning and Error match the XmlSeverityType constants ; the other ones 
	/// can be specified when performing user validation ("user validation" means "validation by a derived class").
	/// </summary>
	public enum  XmlParseErrorSeverity
	   {
		Warning			=  XmlSeverityType. Warning,
		Error			=  XmlSeverityType. Error,
		Informational,
		Notice,
		Fatal
	    }


	/// <summary>
	/// A structure that unifies xml/xsd parsing/validation errors.
	/// </summary>
	public class	XmlParseError	
	   {
		public XmlParseStep		Step		{ get ; internal set ; }
		public XmlParseErrorSeverity	Severity	{ get ; internal set ; }
		public string			Message		{ get ; internal set ; }
		public int			Line		{ get ; internal set ; }
		public int			Character	{ get ; internal set ; }
		public string			Source		{ get ; internal set ; }
		public string			SourceUri	{ get ; internal set ; }
	    }
# endregion


# region	XmlValidatedDocument
	/// <summary>
	/// The XmlValidatedDocument class serves the purpose of loading an Xml document, knowing that all
	/// validation steps have been performed.
	/// Once loaded, the boolean IsValid flag will reflect whether errors have been encountered or node.
	/// The ValidationMessages list will contain the list of information, warning, error... messages.
	/// </summary>
	public class XmlValidatedDocument	:  XmlDocument
	    {
		// Xml and Xsd data specified to the constructor
		public string	XmlData ;
		public string	XsdData ;

		// Message list
		public XmlParseErrors	ValidationMessages	{ get ; protected set ; }
		// Indicates if errors were encountered
		public bool		IsValid			{ get ; protected set ; }


# region	Constructor
		/// <summary>
		/// Builds and validates an Xml document.
		/// </summary>
		/// <param name="xml_data">Xml contents, specified as a string</param>
		/// <param name="xsd_data">Xsd specifications, specified as a string</param>
		public XmlValidatedDocument ( string		xml_data, 
					      string		xsd_data	=  null ) : base ( )
		    {
			// Initilizations
			IsValid			=  true ;			// Consider that by default the document is valid until some crap is found
			ValidationMessages	=  new XmlParseErrors ( ) ;
			XmlData			=  xml_data ;			// Remember supplied parameters
			XsdData			=  xsd_data ;
			
			// Step 1 : load xml data
			try
			   {
				LoadXml ( xml_data ) ;
			    }
			// Catch parsing errors such as opening/closing tag mismatch, or attribute with no value
			catch ( XmlException  e )
			   {
				XmlParseError	pe	=  new XmlParseError ( ) ;

				IsValid			=  false ;
				pe. Step		=  XmlParseStep. XmlParsing ;
				pe. Severity		=  XmlParseErrorSeverity. Error ;
				pe. Message		=  e. Message ;
				pe. Line		=  e. LineNumber ;
				pe. Character		=  e. LinePosition ;
				pe. Source		=  e. Source ;
				pe. SourceUri		=  e. SourceUri ;

				ValidationMessages. Add ( pe ) ;
			    }

			// Stop here if step 1 failed : validation cannot be performed on syntactically incorrect xml data
			if  ( ! IsValid ) 
				return ;

			// Perform steps 2 (Xsd validation) and 3 (Xml validation using Xsd) only if xsd data has been specified
			if  ( xsd_data  !=  null )
			   { 
				// Step 2 : Validate the xsd itself before using it for validating the xml...
				XmlSchema		schema		=  XmlSchema. Read
				   (
					new StringReader ( xsd_data ),
					( object  sender, ValidationEventArgs  e ) =>
					   {
						XmlParseError	pe	=  new XmlParseError ( ) ;

						pe. Step		=  XmlParseStep. XsdValidation ;
						pe. Severity		=  ( XmlParseErrorSeverity ) e. Severity ;
						pe. Message		=  e. Message ;
						pe. Line		=  e. Exception. LineNumber ;
						pe. Character		=  e. Exception. LinePosition ;
						pe. Source		=  e. Exception. Source ;
						pe. SourceUri		=  e. Exception. SourceUri ;

						ValidationMessages. Add ( pe ) ;
						SetValidState ( pe. Severity ) ;
					     }
				    ) ;

				// Stop here if xsd contain errors : we will not be able to use it for xml validation anyway
				if  ( ! IsValid )
					return ;

				// Step 3 : validate the xml document using the xsd schema
				Schemas. Add ( schema ) ;
		
				Validate
				   ( 
					( object  sender, ValidationEventArgs  e ) =>
					   {
						XmlParseError	pe	=  new XmlParseError ( ) ;

						pe. Step		=  XmlParseStep. XmlValidation ;
						pe. Severity		=  XmlParseErrorSeverity. Error ;
						pe. Message		=  e. Message ;
						pe. Line		=  e. Exception. LineNumber ;
						pe. Character		=  e. Exception. LinePosition ;
						pe. Source		=  e. Exception. Source ;
						pe. SourceUri		=  e. Exception. SourceUri ;

						ValidationMessages. Add ( pe ) ;				   
						SetValidState ( pe. Severity ) ;
					    }
				    ) ;

				// Stop here if validation failed ; there is no need to perform user processing at that stage
				if  ( ! IsValid )
					return ;
			    }

			// Step 4 : everything went smooth (perhaps we had some informational or warning messages), so
			//          we can perform user processing.
			ValidateStructure ( ) ;
		     }
# endregion


# region	Protected stuff
		/// <summary>
		/// Derived classes can call AddUserError() to add errors or warnings or else to the existing list
		/// of parsing/validation errors.
		/// The IsValid flag will be set to false if error severity is Error or Fatal.
		/// </summary>
		/// <param name="severity">Error severity</param>
		/// <param name="message">Message</param>
		/// <param name="line">Source line</param>
		protected void  AddValidationMessage ( XmlParseErrorSeverity  severity, string  message, int  line = 0 )
		   {
			XmlParseError	pe	=  new XmlParseError ( ) ;

			pe. Step		=  XmlParseStep. UserValidation ;
			pe. Severity		=  severity ;
			pe. Message		=  message ;
			pe. Line		=  line ;
			pe. Character		=  0 ;
			pe. Source		=  "xml document" ;
			pe. SourceUri		=  "xml document" ;

			ValidationMessages. Add ( pe ) ;				   
			SetValidState ( pe. Severity ) ;
		    }


		/// <summary>
		/// Called to validate xml contents after all the validation steps have been performed.
		/// Override this to perform all the checkings that cannot be enforced by xml parsing and 
		/// schema validation.
		/// This method is not abstract, so you are free NOT to implement it.
		/// Should you implement it, feel free to call the AddValidationMessage() method each time
		/// you have an information, warning or error to add to the validation message list.
		/// </summary>
		protected virtual void  ValidateStructure ( )
		   { }
# endregion


# region	Private methods
		/// <summary>
		/// Sets the IsValid flag to false if the specified error severity is either Error or Fatal.
		/// </summary>
		private void  SetValidState ( XmlParseErrorSeverity  severity )
		   {
			if  ( IsValid  &&  
			      ( severity  ==  XmlParseErrorSeverity. Error  ||  severity  ==  XmlParseErrorSeverity. Fatal ) )
				IsValid		=  false ;
		    }
# endregion
	     }
# endregion


# region	XmlNode extensions
	/// <summary>
	/// Provides extension functions for the XmlNode class.
	/// </summary>
	static class	XmlNodeExtensions
	   {
# region	Methods for partial conversions to string
		/// <summary>
		/// Returns the specified attribute as a string (ie, attr="value").
		/// </summary>
		/// <param name="attr">XmlAttribute item to be converted.</param>
		public static string  GetAttributeAsString ( this XmlNode  node, XmlAttribute  attr )
		   { return ( GetAttributeAsString ( node, attr. Name, attr. Value ) ) ; }


		/// <summary>
		/// Returns the specified attribute as a string (ie, attr="value").
		/// </summary>
		/// <param name="attr">Name of the attribute to be converted.</param>
		/// <returns>
		///	The specified attribute definition, or null if <paramref name="attr"/> does not exist.
		/// </returns>
		public static string  GetAttributeAsString ( this XmlNode  node, string  name )
		   {
			if  ( node. Attributes. Count  ==  0 )	
				return ( null ) ;
			else
			   {
				XmlAttribute	attr	=  node. Attributes [ name ] ;

				if  ( attr  ==  null )
					return ( null ) ;
				else
					return ( GetAttributeAsString ( node, attr. Name, attr. Value ) ) ;
			    }
		    }

		
		/// <summary>
		/// Returns the specified attribute name and value, as an xml definition.
		/// <para>
		/// Concerning value quoting, the following rules apply :
		/// <list type="-">
		///	<item>
		///		<paramref name="value"/> contains single quotes, or not quotes at all : 
		///		double quotes will be used to quote the value.
		///	</item>
		///	<item>
		///		<paramref name="value"/> contains double quotes : 
		///		single quotes will be used to quote the value.
		///	</item>
		///	<item>
		///		<paramref name="value"/> contains both single and double quotes : 
		///		double quotes will be replaced by the &amp;lquot; html entity and the
		///		value will be quoted using double quotes.
		///	</item>
		/// </list>
		/// </para>
		/// </summary>
		/// <param name="node"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string  GetAttributeAsString ( this XmlNode  node, string  name, string  value )
		   {
			int	has_quotes		=  value. IndexOf ( '\'' )  ;
			int	has_doublequotes	=  value. IndexOf ( '"' ) ;
			char	quote			=  '"' ;


			// If the value has both quotes and doublequotes, sacrify the doublequotes and replace them
			// with the &quot; html entity 
			if  ( has_quotes  >=  0  &&  has_doublequotes  >=  0 )
				value		=  value. Replace ( "\"", "&quot;" ) ;
			// Otherwise, change the quoting character to "'" if doublequotes are present
			else if  ( has_doublequotes  >=  0 )
				quote		=  '\'' ;

			return ( name + '=' + quote + value + quote ) ;
		    }

		/// <summary>
		/// Returns a node's attributes as a string.
		/// </summary>
		public static string  GetAttributesAsString ( this XmlNode  node )
		   {
			List<string>	attributes	=  new List<string> ( ) ;

			foreach  ( XmlAttribute  attr  in  node. Attributes )
				attributes. Add ( GetAttributeAsString ( node, attr ) ) ;
				
			string		result		=  String. Join ( " ", attributes ) ;

			if  ( string. IsNullOrWhiteSpace ( result ) )
				return ( String. Empty ) ;
			else
				return ( result ) ;
		    }


		/// <summary>
		/// Gets an attribute value, catching all exceptions.
		/// </summary>
		/// <param name="name">Attribute name.</param>
		/// <param name="default_value">Default value to use if the attribute does not exist.</param>
		/// <returns>The attribute value.</returns>
		public static string  GetAttributeValue ( this XmlNode  node, string  name, string  default_value = "" )
		   {
			if  ( node. Attributes. Count  !=  0 )
		 	   {
				if  ( node. Attributes  [ name ]. Value  !=  null )
					return ( node. Attributes  [ name ]. Value. Trim ( ) ) ;
				else
					return ( default_value ) ;
			    }
			else
				return ( default_value ) ;
		    }


		/// <summary>
		/// Returns the starting xml node tag as a string, including its attributes.
		/// </summary>
		/// <param name="closed">When true</param>
		public static string  GetOpeningTag ( this XmlNode  node, bool  closed = false )
		   {
			string		end	=  ( closed ) ?  "/>" : ">" ;

			return ( "<" + node. Name + GetAttributesAsString ( node ) + end ) ;
		    }


		/// <summary>
		/// Returns the closing xml node tag.
		/// </summary>
		public static string  GetClosingTag ( this XmlNode  node )
		   {
			return ( "</" + node. Name + ">" ) ;
		    }
# endregion

# region	Node text-retrieval methods
		/// <summary>
		/// Gets the text contained in an xml node. This method is intended to retrieve the contents
		/// of multiline data such as :
		/// 
		///	&lt;mytag&gt;
		///		my tag contents.
		///	&lt;/mytag&gt;
		///	
		/// Normally, the Text method will extra spaces and newlines after the opening tag, as
		/// well as the extra spaces and newline before the closing tag. This method ensures that
		/// only the enclosed contents are returned (ie, the line containing "my tag contents").
		/// </summary>
		/// <returns>The xml node text.</returns>
		public static string  GetNodeText ( this XmlNode  node )
		   {
			string		text		=  node. InnerText ;
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
# endregion

# region		Misc methods
		/// <summary>
		/// Returns the nesting level of the current node.
		/// </summary>
		/// <returns>Nesting level of the current node. The root node nesting level is 0.</returns>
		public static int	GetNestingLevel ( this XmlNode  node )
		   {
			int		nesting_level	=  0 ;
			XmlNode		nd		=  node. ParentNode ;
			
			while  ( nd  !=  null )
			   {
				nesting_level ++ ;
				nd	=  nd. ParentNode ;
			    }

			nesting_level -- ;	// Count one less, since the top level node is the XmlDocument itself

			return ( nesting_level ) ;
		    }
# endregion

	     }
# endregion
    }
