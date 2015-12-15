/**************************************************************************************************************

    NAME
	WutheringCommentsEditor.cs

    DESCRIPTION
	A small editor to modify comment definitions.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/012/10]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using  System ;
using  System. Collections. Generic ;
using  System. ComponentModel ;
using  System. Data ;
using  System. Drawing ;
using  System. Linq ;
using  System. Text ;
using  System. Threading. Tasks ;
using  System. Windows. Forms ;


namespace Wuthering. WutheringComments
   {
	public partial class WutheringCommentsEditor : Form
	   {
		private	string		_Text ;

		public WutheringCommentsEditor ( string  text )
		   {
			InitializeComponent ( ) ;
			_Text	=  text ;
		    }


		private void WutheringCommentsEditor_Load ( object sender, EventArgs e )
		   {
			TextContents. Text		=  _Text ;
		    }
		

		private void WutheringCommentsEditor_Shown ( object sender, EventArgs e )
		   {
			TextContents. Focus ( ) ;
			TextContents. SelectionLength	=  0 ;
			TextContents. SelectionStart	=  0 ;
			TextContents_SelectionChanged ( null, null ) ;
		    }

		private void SaveButton_Click ( object sender, EventArgs e )
		   {

		    }

		private void TextContents_SelectionChanged ( object sender, EventArgs e )
		   {
			SBLineCount. Text	=  "Lines: " + TextContents. Lines. Length. ToString ( ) ;
			SBSize. Text		=  "Chars: " + TextContents. Text. Length. ToString ( ) ;

			int		index		=  TextContents. SelectionStart + TextContents. SelectionLength ;
			int		line		=  TextContents. GetLineFromCharIndex ( index ) ;
			int		firstchar	=  TextContents. GetFirstCharIndexFromLine ( line ) ;
			int		column		=  index - firstchar ;

			SBPosition. Text	=  "L" + ( line + 1 ) + " C" + ( column + 1 ) ;
		    }


		private void WutheringCommentsEditor_FormClosing ( object sender, FormClosingEventArgs e )
		   {
			if  ( TextContents. Modified )
			   {
				
			    }
		    }
	    }
    }
