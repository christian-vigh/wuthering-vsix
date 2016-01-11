/**************************************************************************************************************

    NAME
	CommentsDocument.cs

    DESCRIPTION
	A class to load a <wuthering-comments> definition from string and save it to a file.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/012/10]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using	System;
using	System. Collections. Generic ;
using	System. IO ;
using	System. Linq ; 
using	System. Reflection ;
using	System. Text ;
using	System. Threading. Tasks ;
using	System. Xml ;
using	Microsoft. VisualBasic ;
using	EnvDTE ;

using	VsPackage ;
using   Thrak. EnvDTE ;
using   Thrak. Input ;
using	Thrak. Forms ;
using   Thrak. Types ;
using	Thrak. Processors ;
using	Thrak. Xml ;


namespace Wuthering. WutheringComments
   {
	public class XmlCommentsDocument	: XmlValidatedDocument
	   {
		internal const string		EOL		=  "\r\n" ;

		// Contents of embedded definitions and schema
		public static string		StockDefinitions	{ get ; private set ; }
		public static string		StockSchema		{ get ; private set ; }

		// Definitions
		public Author			Author			{ get ; private set ; }
		public Categories		Categories		{ get ; private set ; } 
		public Templates		Templates		{ get ; private set ; } 
		public Groups			Groups			{ get ; private set ; } 

		// Variables used for comment expansion
		public CommentVariables		Variables		{ get ; private set ; }

		/// <summary>
		/// Static constructor. Retrieves the contents of the xml definitions and xsd files embedded in
		/// the resources.
		/// </summary>
		static  XmlCommentsDocument ( )
		   {
			StockDefinitions	=  WutheringCommentsPackage. CommentResources. WutheringCommentsXml ;
			StockSchema		=  WutheringCommentsPackage. CommentResources. WutheringCommentsXsd ;
		    }


		/// <summary>
		/// Loads and validates the specified xml data, which holds a <wuthering-comments> definition.
		/// </summary>
		public XmlCommentsDocument ( string  xml_data  =  null ) :
				base  ( ( xml_data  ==  null ) ?  StockDefinitions : xml_data, StockSchema )
		   { }


		/// <summary>
		/// Retrieves a comment of the specified category for the language identified by the filename's extension.
		/// </summary>
		/// <param name="filename">Filename whose extension will be used to determine comment language.</param>
		/// <param name="category">Comment category (file, block, code, etc.)</param>
		/// <returns>
		/// A array of strings containing the comment lines. An empty array is returned if no comment entry could be found.
		/// </returns>
		public string []	GetComment ( string  filename, string  category )
		   {
			Variables. Define ( "file", Path. GetFileName ( filename ) ) ;
			Variables. Define ( "path", filename ) ;
			Variables. Define ( "directory", Path. GetDirectoryName ( filename ) ) ;

			string []	text	=  Groups. GetComment ( Path. GetExtension ( filename ), category, Variables ) ;


			return ( text ) ;
		    }


		/// <summary>
		/// Inserts a comment at the specified cursor location.
		/// </summary>
		/// <param name="dte">VS development environment object</param>
		/// <param name="document">Document where insertion has to take place</param>
		/// <param name="category">Comment category</param>
		public void  InsertComment ( Document  document, string  category )
		   {
			DTE		dte	=  document. DTE ;

			// Get selection
			TextSelection	selection		=  ( TextSelection ) document. Selection ;

			// "point" is normally where the caret is ; it can be anywhere in a line
			// "line_start_point" is the beginning of the line where the caret is
			EditPoint	point			=  selection. GetTopPoint ( ),
					line_start_point	=  point. CreateBolEditPoint ( ) ;

			// We will perform several insert operations ; it will be nice to be able to undo them in one shot, so
			// create an undo context
			dte. UndoContext. Open ( "Insert \"" + category + "\" comment" ) ;

			// Get leading spaces
			string		prepend_text		=  line_start_point. GetLeadingSpaces ( ) ;

			// Get the comment lines for the current document and category
			string []	comment_lines		=  GetComment ( document. FullName, category ) ;

			// Remember the line before which the comment has to be inserted
			int		start_line		=  line_start_point. Line ;

			// "select_from_line" and "select_from_column" will hold the last position of a "{^}" or "{!}" construct
			// while "select_to_line" and "select_to_column" will hold the last position of a "{$}" construct
			int		select_from_line	=  -1,
					select_from_column	=  -1,
					select_to_line		=  -1,
					select_to_column	=  -1 ;
			StringBuilder	comment_to_insert	=  new StringBuilder ( ) ;
			
			// Loop through comment lines and interpret every "{...}" construct
			for  ( int  i = 0 ; i  <  comment_lines. Length ; i ++ )
			   {
				string	comment_line	=  comment_lines [i] ;
				int	index ;

				// "{^}" construct :
				//	Marks the start of the text to be automatically selected after comment insertion.
				if  ( ( index = comment_line. IndexOf ( "{^}" ) )  >=  0 )
				   {
					select_from_line	=  start_line + i ;
					select_from_column	=  prepend_text. Length + index + 1 ;
					comment_line		=  comment_line. Replace ( "{^}", "" ) ;
				    }

				// "{$}" construct :
				//	Marks the end of the text to be automatically selected after comment insertion.
				if  ( ( index = comment_line. IndexOf ( "{$}" ) )  >=  0 )
				   {
					select_to_line		=  start_line + i ;
					select_to_column	=  prepend_text. Length + index + 1 ;
					comment_line		=  comment_line. Replace ( "{$}", "" ) ;
				    }

				// "{!}" construct :
				//	When no "{^}" or "{$}" constructs are specified in the comment template, indicates where the
				//	cursor is to be positioned.
				if  ( ( index = comment_line. IndexOf ( "{!}" ) )  >=  0 )
				   {
					select_from_line	=  start_line + i ;
					select_from_column	=  prepend_text. Length + index + 1 ;
					select_to_line		=  -1 ;
					select_to_column	=  -1 ;
					comment_line		=  comment_line. Replace ( "{!}", "" ) ;
				    }

				// "{? ...}" construct :
				//	Prompts for user input which will replace the construct's contents.
				//	The prompt parameters are specified as xml attributes, which can be any of :
				//	- prompt :
				//		Prompt string to be displayed when asking for user input.
				//	- default :
				//		Default input string.
				//	- width :
				//		Text width, in characters. This parameter is mandatory.
				//	- align :
				//		Text alignment : "left" (default), "center" or "right".
				if  ( ( index = comment_line. IndexOf ( "{?" ) )  >=  0 )
				   {
					int				end_index	=  comment_line. LastIndexOf ( "}" ) ;

					if  ( end_index  >=  0 )
					   {
						string				attr_string		=  comment_line. Substring ( index + 2, end_index - index - 2 ) ;
						Dictionary<string,string>	attrs			=  Parsing. ParseXmlAttributes ( attr_string ) ;

						if  ( attrs  !=  null )
						   { 
							string				prompt_attribute	=  attrs. GetValue ( "prompt", "Enter comment string :" ),
											default_attribute	=  attrs. GetValue ( "default", "" ),
											width_attribute		=  attrs. GetValue ( "width", "0" ),
											align_attribute		=  attrs. GetValue ( "align", "left" ) ;
							int				line_width ;
							StringAlignmentOption		align_option		=  StringAlignmentOption. Left ;
							string				comment	;

							if  ( int. TryParse ( width_attribute, out line_width ) )
							   {
								switch  ( align_attribute. ToLower ( ) )
								   {
									case	"left"		:  align_option	=  StringAlignmentOption. Left   ; break ;
									case	"right"		:  align_option =  StringAlignmentOption. Right  ; break ;
									case	"center"	:  align_option =  StringAlignmentOption. Center ; break ;
								    }

								comment		=  InputBox. Show ( prompt_attribute, default_attribute, "Input" ) ;
								comment		=  comment. Align ( line_width, align_option ) ;

								comment_line	=  comment_line. Substring ( 0, index ) + comment +
										   comment_line. Substring ( end_index + 1 ) ;
							    }
						    }
					    }
				    }

				// Append the current comment line, after everything has been interpreted.
				comment_to_insert. Append ( prepend_text + comment_line + "\n" ) ;
			    }

			// Insert the comment after special constructs have been interpreted
			line_start_point. Insert ( comment_to_insert. ToString ( ) ) ;

			// Either a "{^}" or "{!}" construct has been found
			if  ( select_from_line  >  0 )
			   {
				// Move to the position of "{^}" or "{!}"
				selection. MoveToLineAndOffset ( select_from_line, select_from_column ) ;

				// If specified, move to then position of "{$}"
				if  ( select_to_line  >  0 )
					selection. MoveToLineAndOffset ( select_to_line, select_to_column, true ) ;
			    }

			// Close the undo context, so that pressing Ctrl+Z will undo the whole comment insertion
			dte. UndoContext. Close ( ) ;
		    }


		/// <summary>
		/// Surrounds a selection with a construct such as opening and closing braces.
		/// </summary>
		/// <param name="dte">VS development environment object</param>
		/// <param name="document">Document where insertion has to take place</param>
		/// <param name="category">Comment category</param>
		/// <param name="start">Opening construct</param>
		/// <param name="stop">Ending construct</param>
		/// <param name="indent_start">Opening construct</param>
		/// <param name="indent_stop">Ending construct</param>
		public void  Enclose ( Document  document, string  start, string  stop, int  indent_start, int  indent_stop )
		   { 
			DTE		dte	=  document. DTE ;

			// Get selection
			TextSelection	selection		=  ( TextSelection ) document. Selection ;

			// "point" is normally where the caret is ; it can be anywhere in a line
			// "line_start_point" is the beginning of the line where the caret is
			EditPoint	point			=  selection. GetTopPoint ( ),
					line_start_point	=  point. CreateBolEditPoint ( ) ;
			VirtualPoint	active_point		=  selection. ActivePoint ;
				
			// Get leading spaces
			string		prepend_text		=  line_start_point. GetLeadingSpaces ( ) ;

			// We will perform several insert operations ; it will be nice to be able to undo them in one shot, so
			// create an undo context
			dte. UndoContext. Open ( "Embrace " + start + stop ) ;

			// Insert an opening brace (or else) before the first line of the selection
			line_start_point. Insert ( prepend_text + " ". Repeat ( indent_start - 1 ) + start + "\n" ) ;

			// Unindent this line so that it appears before the indentation level of the selection
			line_start_point. MoveToLineAndOffset ( line_start_point. Line - 1, 1 ) ;

			EditPoint	brace_eol		=  line_start_point. CreateEolEditPoint ( ) ;

			line_start_point. Unindent ( brace_eol, 1 ) ;

			// Append a closing brace (or else) right after the last line of the selection
			// (the selection does not have to cover the entire line)
			EditPoint	end_of_selection	=  selection. GetBottomPoint ( ). CreateEolEditPoint ( ) ;

			end_of_selection. Insert ( "\n" + prepend_text + " ". Repeat ( indent_stop - 1 ) + stop + "\n" ) ;
			end_of_selection. MoveToLineAndOffset ( end_of_selection. Line - 1, 1 ) ;
			brace_eol	=  end_of_selection. CreateEolEditPoint ( ) ;

			end_of_selection. MoveToLineAndOffset ( end_of_selection. Line, 1 ) ;
			end_of_selection. Unindent ( brace_eol, 1 ) ;

			// Restore the caret to where it was before calling this method
			selection. MoveToPoint ( active_point ) ;

			// Close the undo context, so that pressing Ctrl+Z will undo the whole code selection_start
			dte. UndoContext. Close ( ) ;
		    }


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

			// Create the variable store at the end, since it may reference values that are available only after parsing
			Variables		=  new CommentVariables ( this ) ;
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
