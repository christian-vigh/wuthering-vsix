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

using  Thrak. Input ;
using  Thrak. Xml ;
using  Wuthering. WutheringComments ;
using  VsPackage ;


namespace CommentsTestUI
   {
	public partial class TestUI : Form
	   {
		private	WutheringCommentsErrorList	ErrorListForm		=  null ;


		public TestUI ( )
		   {
			InitializeComponent ( ) ;
		   }


		// Form event handlers
		private void  TestUI_Shown ( object  sender, EventArgs  e )
		   {
			InputXml. Text		=  XmlCommentsDocument. StockDefinitions ;
			GenerateXmlOutput ( InputXml. Text ) ;
		    }


		// Command event handlers
		private void GenerateButton_Click ( object sender, EventArgs e )
		    {  GenerateXmlOutput ( InputXml. Text ) ; }

		private void CheckOutputButton_Click ( object sender, EventArgs ea )
		   { CheckXml ( OutputXml.Text ) ; }

		private void CheckInputButton_Click ( object sender, EventArgs e )
		   { CheckXml ( InputXml.Text ) ; }

		private void EditButton_Click ( object sender, EventArgs e )
		   { EditXml ( InputXml, OutputXml ) ; }

		private void Comments_Click ( object sender, EventArgs e )
		   { TestComments ( InputXml.Text ) ; }


		/// <summary>
		/// Generate xml output from the specified xml data to the OutputXml textbox.
		/// </summary>
		private void  GenerateXmlOutput ( string  xmldata )
		   {
			XmlCommentsDocument		parser	=  new XmlCommentsDocument ( xmldata ) ;
			
			if  ( parser. IsValid )
			   {
				CheckOutputButton. Enabled	=  true ;
				OutputXml.Text			=  parser. ToString ( ) ;
			    }
			else
				DisplayParseErrors ( parser ) ;
		    }


		/// <summary>
		/// Displays parsing errors in a modal form.
		/// </summary>
		private void  DisplayParseErrors ( XmlCommentsDocument  parser )
		   {
			if  ( ErrorListForm  ==  null )
				ErrorListForm	=  new WutheringCommentsErrorList ( ) ;

			ErrorListForm. ShowDialog ( parser. ValidationMessages ) ;
		    }


		/// <summary>
		/// Checks (validates) the specified xml data.
		/// </summary>
		private void CheckXml ( string  text )
		   {
			XmlCommentsDocument		parser	=  new XmlCommentsDocument ( text ) ;
			
			if  ( parser. IsValid )
				MessageBox. Show ( "Xml contents are valid" ) ;
			else
				DisplayParseErrors ( parser ) ;

		    }


		private void  TestComments ( string  text )
		   {
			XmlCommentsDocument		parser	=  new XmlCommentsDocument ( text ) ;
			DisplayCommentForm		form	=  new DisplayCommentForm ( parser ) ;	
			
			form. ShowDialog ( ) ;		
		    }


		/// <summary>
		/// Allows editing of xml definitions, using the vsix editor form.
		/// </summary>
		private void  EditXml ( TextBox  input, TextBox  output )
		   {
			string				text		=  input. Text ;
			DialogResult			status ;
			WutheringCommentsEditor		editor		=  new WutheringCommentsEditor ( text ) ;

			status	=  editor. ShowDialog ( ) ;
			MessageBox.Show ( status.ToString ( ) ) ;

			editor. Dispose ( ) ;
		    }
	    }
    }
