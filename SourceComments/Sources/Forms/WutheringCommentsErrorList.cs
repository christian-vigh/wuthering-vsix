/**************************************************************************************************************

    NAME
	WutheringCommentsErrorList.cs

    DESCRIPTION
	Displays a validation error list.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/12/19]     [Author : CV]
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
using  System. Xml ;

using  Thrak. Xml ;


namespace Wuthering. WutheringComments
   {
	public partial class WutheringCommentsErrorList : Form
	   {
		public  WutheringCommentsErrorList ( )
		   {
			InitializeComponent ( ) ;
		    }


		/// <summary>
		/// Closes this form.
		/// </summary>
		private void  Close_Click ( object  sender, EventArgs  e )
		   {
			Close ( ) ;
		    }


		/// <summary>
		/// Shows the dialog form with the specified list of xml parse errors.
		/// </summary>
		public void  ShowDialog ( List<XmlParseError>  list )
		   {
			ErrorList. Items. Clear ( ) ;

			foreach  ( XmlParseError e  in  list )
			   {
				String	line	=  ( e. Line    ==  0 ) ?  "-" : e. Line. ToString ( ),
					column	=  ( e. Column  ==  0 ) ?  "-" : e. Column. ToString ( ) ;

				ErrorList. Items. Add
				  (
					new ListViewItem 
					   (
						new string [] 
						   {
							 e. Step. ToString ( ),
							 e. Severity. ToString ( ),
							 line, column,
							 ( String. IsNullOrEmpty ( e. SourceUri ) ) ?
								e. Source : e. SourceUri,
							 e. Message
						    }
					    )
				   ) ;
			    }

			base. ShowDialog ( ) ;
			StartPosition	=  FormStartPosition. Manual ;
		    }
	    }
    }
