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

		public void Initialize()  
		   {      
			textBox1.Text = OptionsPage.ExampleString;   
		    }

		private void textBox1_Leave ( object sender, EventArgs e )
		{
			OptionsPage.ExampleString	=  textBox1.Text ;
		}
	}
}
