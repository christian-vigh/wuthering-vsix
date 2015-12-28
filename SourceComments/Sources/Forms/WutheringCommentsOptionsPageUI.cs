using System;
using System. Collections. Generic;
using System. ComponentModel;
using System. Drawing;
using System. Data;
using System. Linq;
using System. Text;
using System. Threading. Tasks;
using System. Windows. Forms;

namespace Wuthering. WutheringCommentsPackage
{
	public partial class WutheringCommentsOptionsPageUI : UserControl
	{
		public WutheringCommentsOptionsPage	OptionsPage ;


		public WutheringCommentsOptionsPageUI ( WutheringCommentsOptionsPage  page )
		   {
			InitializeComponent ( ) ;
			OptionsPage	=  page ;
		    }


		public void  Initialize()  
		   {      
			
		    }


		private void  FileOpenButton_Click  ( object  sender, EventArgs  e )
		   {
			FileOpenDialog. ShowDialog ( ) ;
		    }


		private void  GenerateButton_Click  ( object  sender, EventArgs  e )
		   {

		    }


		private void  EditButton_Click  ( object  sender, EventArgs  e )
		   {

		    }
	}
}
