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

using	System ;
using   System. Diagnostics ;
using	System. Globalization ;
using	System. Collections. Generic ;
using	System. Linq ;
using	System. Runtime. CompilerServices ;
using	System. Text ;
using	System. Threading. Tasks ;


namespace	Utilities
   {
	public static class Debug
	   {
		/// <summary>
		/// Logs a trace message in the output window.
		/// </summary>
		public static void  Trace ( string			message,
					    [CallerMemberName] string	caller		=  "",
					    [CallerFilePath  ] string	filename	=  "",
					    [CallerLineNumber] int	fileline	=  0 )
		   {
			System. Diagnostics. Debug. WriteLine ( 
				string. Format ( CultureInfo. CurrentCulture,
							"[Trace] {0}#{1} {2} : {3}",
 							filename, fileline, caller, message ) ) ;
		    }
	    }
    }
