/**************************************************************************************************************

    NAME
	Text.cs

    DESCRIPTION
	Text utility functions.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/012/10]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using System;
using System. Collections. Generic;
using System. Linq;
using System. Text;
using System. Threading. Tasks;

namespace Utilities
   {
	public static class  Text
	   {
		/// <summary>
		/// Extension to the string object : expands tabs within a string.
		/// </summary>
		/// <param name="text">String object</param>
		/// <param name="tabsize">Number of spaces represented by a tab.</param>
		/// <param name="stop_at_first_nonspace">When true, expansion stops at the first nonspace character.</param>
		/// <returns>The expanded string.</returns>
		public static string  ExpandTabs ( this string		text, 
						   int			tabsize			=  8, 
						   bool			stop_at_first_nonspace	=  false )
		   {
			StringBuilder	result		=  new StringBuilder ( ) ;
			int		column		=  0,
					index		=  0 ;

			foreach  ( Char  ch  in  text )
			   {
				switch ( ch )
				   {
					case	'\t' :
						do
						   {
							result. Append ( ' ' ) ;
							column ++ ;
						    }  while ( ( column & ( tabsize - 1 ) )  !=  0 ) ;
						break ;

					case	'\n' :
					case	'\r' :
						column	=  0 ;
						break ;
					
					case	' ' :
						result. Append ( ' ' ) ;
						column ++ ;
						break ;

					default :
						if  ( stop_at_first_nonspace )
						   {
							result. Append ( text. Substring ( index ) ) ;
							return ( result. ToString ( ) ) ;
						    }
						else
						   {
							result. Append ( ch ) ;
							column ++ ;
						     }
						break ;
				    }

				index ++ ;
			    }

			return ( result. ToString ( ) ) ;
		    }
	    }
    }
