/**************************************************************************************************************

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

using  Thrak. Xml ;
using  Wuthering. WutheringComments ;
using  Utilities ;


namespace CommentsTestUI
   {
	public partial class TestUI : Form
	   {
		public TestUI ( )
		   {
			InitializeComponent ( ) ;
		   }


		// Form event handlers
		private void  TestUI_Shown ( object  sender, EventArgs  e )
		   {
			InputXml. Text		=  CommentsParser. StockDefinitions ;
			GenerateXmlOutput ( InputXml. Text ) ;
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
		private void  GenerateXmlOutput ( string  xmldata )
		   {
			CommentsParser		parser	=  new CommentsParser ( xmldata ) ;
			
			if  ( parser. IsValid )
			   {
				CheckOutputButton. Enabled	=  true ;
				OutputXml.Text = "VALID!!!" ;
			    }
			else
				DisplayParseErrors ( parser ) ;
		    }


		/// <summary>
		/// Displays parsing errors in a modal form.
		/// </summary>
		private void  DisplayParseErrors ( CommentsParser  parser )
		   {
			CheckOutputButton. Enabled	=  false ;
				
			DisplayErrorsForm	form	=  new DisplayErrorsForm ( ) ;

			foreach  ( XmlParseError e  in  parser. ValidationMessages )
			   {
				form. ErrorList. Items. Add
				  (
					new ListViewItem 
					   (
						new string [] 
						   {
							 e. Step. ToString ( ),
							 e. Severity. ToString ( ),
							 e. Line. ToString ( ),
							 e. Column. ToString ( ),
							 ( String. IsNullOrEmpty ( e. SourceUri ) ) ?
								e. Source : e. SourceUri,
							 e. Message
						    }
					    )
				   ) ;
			    }

			form. ShowDialog ( ) ;
		    }


		/// <summary>
		/// Checks (validates) the specified xml data.
		/// </summary>
		private void CheckXml ( string  text )
		   {
			CommentsParser		parser	=  new CommentsParser ( text ) ;
			
			if  ( parser. IsValid )
				MessageBox. Show ( "Xml contents are valid" ) ;
			else
				DisplayParseErrors ( parser ) ;

		    }
	    }
    }
