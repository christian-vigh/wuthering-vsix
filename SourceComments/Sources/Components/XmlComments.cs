/**************************************************************************************************************

    NAME
	Debug.cs

    DESCRIPTION
	Some maybe useful debug utility functions.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/09/12]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using  System;
using  System. Collections. Generic ;
using  System. IO ;
using  System. Linq ; 
using  System. Text ;
using  System. Threading. Tasks ;
using  System. Xml ;


namespace Wuthering. WutheringComments
   {
	public class XmlComments
	   {
		public Comments Content {  get ; private  set ; }


		public  XmlComments ( )
		   {
		    }


		public void  Load ( string  data )
		   {
			XmlDocument	document	=  new XmlDocument ( ) ;

			document. LoadXml ( data ) ;

			Content		=  new Comments ( document.DocumentElement ) ;
		    }


		//public abstract void		Save		( string  output ) ;
		//public abstract string		ToString	( ) ;
	    }


	public class   XmlFileComments		:  XmlComments
	   {
		public string	Filename	{ get ; private set ; }

		public  XmlFileComments ( )
		   {
		    }


		public new void  Load ( string  file )
		   {
			StreamReader	reader		=  new StreamReader ( file ) ;
			string		content		=  reader. ReadToEnd ( ) ;

			Filename	=  file ;

			reader. Close ( ) ;
			base. Load  ( content ) ;
		    }
	    }


	/*
	public class   XmlResourceComments	:  XmlComments
	   {
		
	    }
	    */
    }
