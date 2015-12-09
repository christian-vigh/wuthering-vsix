/**************************************************************************************************************

    NAME
	Symbols.cs

    DESCRIPTION
	Gathers the GUID and command ids that are defined in the .vcst file.
	Note that both the documentation and the comments in the auto-generated files can introduce some
	misunderstanding : there is absolutely NO correlation between identifiers in the .vcst file and the
	identifiers you define here. The only requirement is that you put here the correct values whatever
	names you give to the constants.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/09/12]     [Author : CV]
	Initial version.

 **************************************************************************************************************/
using	System ;

namespace  Wuthering. WutheringCommentsPackage. Symbols
   {
	static class Guids
	   {
		public const string	PackageGuid			=  "bad8076a-b8e4-4f03-ae47-f797221ad2d6";
		public const string	SourceCommentsMenuGuid		=  "c2b54412-76ed-48c0-aa3c-16ddfef28b63";
	    }


	static class  Commands 
	   {
		public const int	SourceCommentsMenuGroup		=  0x1020 ;
		public const int	SourceCommentsSubMenu		=  0x1030 ;
		public const int	SourceCommentsSubMenuGroup	=  0x1040 ;

		public const uint	InsertFileHeaderComment		=  0x100 ;
		public const uint	InsertBlockHeaderComment	=  0x101 ;
		public const uint	InsertFunctionHeaderComment	=  0x102 ;
		public const uint	InsertClassHeaderComment	=  0x103 ;
		public const uint	InsertStandardComment		=  0x104 ;
	    } ;
    }