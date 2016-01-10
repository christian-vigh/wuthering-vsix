using System;
using System. Collections. Generic;
using System. ComponentModel;
using System. Data;
using System. Drawing;
using System. Linq;
using System. Text;
using System. Threading. Tasks;
using System. Windows. Forms;

using  Thrak. Xml ;
using  Wuthering. WutheringComments ;
using  VsPackage ;


namespace CommentsTestUI
   {
	public partial class  DisplayCommentForm : Form
	   {
		XmlCommentsDocument	Parser ;


		public DisplayCommentForm ( XmlCommentsDocument  parser )
		   {
			InitializeComponent ( ) ;
			Parser	=  parser ;
		    }


		private void RefreshButton_Click ( object sender, EventArgs e )
		   {
			string		filename	=  Filename. Text ;
			string		category	=  Category. Text ;
			string []	text		=  Parser. GetComment ( filename, category ) ;

			CommentText. Text	=  String. Join ( "\r\n", text ) ;
		    }


		private void CloseButton_Click ( object sender, EventArgs e )
		   {
			Close ( ) ;
		    }
	    }
    }
