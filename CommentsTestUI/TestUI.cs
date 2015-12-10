﻿/**************************************************************************************************************

    NAME
	TestUI.cs

    DESCRIPTION
	Allows for testing the components of the WutheringComments package outside the VSIX environment.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/09/12]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using  System;
using  System. Collections. Generic ;
using  System. ComponentModel ;
using  System. Data ;
using  System. Drawing ;
using  System. IO ;
using  System. Linq ;
using  System. Text ;
using  System. Threading. Tasks ;
using  System. Windows. Forms ;
using  System. Xml ;
using  System. Xml. Schema ;
using  System. Xml. XPath ;

using  Wuthering. WutheringComments ;


namespace CommentsTestUI
   {
	public partial class TestUI : Form
	   {
		internal XmlComments	CommentsDocument ;

		public TestUI ( )
		   {
			InitializeComponent ( ) ;

			InputXml. Text		=  XmlComments. StockDefinitions ;
			GenerateXmlOutput ( XmlComments. StockDefinitions ) ;
		   }

		// Command event handlers
		private void GenerateButton_Click ( object sender, EventArgs e )
		    {  GenerateXmlOutput ( InputXml. Text ) ; }

		private void CheckOutputButton_Click ( object sender, EventArgs ea )
		   { CheckXml ( OutputXml.Text ) ; }

		private void CheckInputButton_Click ( object sender, EventArgs e )
		   { CheckXml ( InputXml.Text ) ; }


		/// <summary>
		/// Generate xml output from the specified xml data to the OutputXml textbox.
		/// </summary>
		private void  GenerateXmlOutput ( string  data )
		   {
			try
			   {
				CommentsDocument	=  new XmlComments ( ) ;

				CommentsDocument. Load ( data ) ;
				OutputXml. Text		=  CommentsDocument. ToXmlString ( ). Replace ( "\n", "\r\n" ) ;
				OutputXml. Font		=  new Font ( OutputXml. Font, FontStyle. Regular ) ;
				OutputXml. ForeColor	=  Color. Black ;
				CheckOutputButton. Enabled	=  true ;
			    }
			catch  ( XmlException  e )
			   {
				string		message		=  "Parse error at line #" + e. LineNumber + ", character #" + 
									e. LinePosition + " :\r\n\r\n" +
									e. Message ;

				OutputXml. Text		=  message ;
				OutputXml. Font		=  new Font ( OutputXml. Font, FontStyle. Bold ) ;
				OutputXml. ForeColor	=  Color. Red ;
				CheckOutputButton. Enabled	=  false ;
			    }
		    }


		/// <summary>
		/// Checks (validates) the specified xml data.
		/// FIX: Validation detects nothing.
		/// </summary>
		private void CheckXml ( string  text )
		   {
			XmlReaderSettings	settings		=  new XmlReaderSettings ( ) ;

		
			settings. Schemas. Add ( "http://schemas.wuthering-bytes.com",
					XmlReader. Create ( new StringReader ( XmlComments. StockSchema ) ) ) ;
			settings. ValidationType	=  ValidationType. Schema ;

			XmlDocument	doc		=  new XmlDocument ( ) ;
			List<string>	errors		=  new List<string> ( ) ;

			try
			   {
				doc. Load ( XmlReader. Create ( new StringReader ( text ), settings ) ) ;
			    }
			catch  ( XmlException  e )
			   {
				string		message		=  "Parse error at line #" + e. LineNumber + ", character #" + 
									e. LinePosition + " :\r\n\r\n" +
									e. Message ;

				MessageBox. Show ( message ) ;
			
				return ;
			    }

			doc. Validate ( 
				new ValidationEventHandler 
				   ( 
					( object  sender, ValidationEventArgs  e ) => { ValidationHandler ( sender, e, errors ) ; } 
				    ) ) ;

			if  ( errors. Count  ==  0 )
				MessageBox. Show ( "Document is valid.", "Information" ) ;
			else
				MessageBox. Show
				   (
					"XSD validation detected the following errors :\r\n- " +
					String. Join ( "\r\n- ", errors ),
					"Error"
				    ) ;
		    }


		private void  ValidationHandler ( object  sender, ValidationEventArgs  e, List<string>  errors )
		   {
			errors. Add ( "[" + e. Severity. ToString ( ) + "] " + e. Message ) ;
		    }
	    }
    }
