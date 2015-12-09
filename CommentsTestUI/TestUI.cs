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
using  System. Linq ;
using  System. Text ;
using  System. Threading. Tasks ;
using  System. Windows. Forms ;
using  Wuthering. WutheringComments ;


namespace CommentsTestUI
   {
	public partial class TestUI : Form
	   {
		public TestUI ( )
		   {
			InitializeComponent ( ) ;

			XmlFileComments	doc	=  new XmlFileComments ( ) ;

			doc.Load ( @"E:\Visual Studio\Projects\VSIX\Wuthering\CommentsTestUI\Data\WutheringComments.xml" ) ;

		    }
	    }
    }
