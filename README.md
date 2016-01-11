# WHAT IS THIS ? #
This repository contains a Visual Studio Package extension (vsix) whose sole purpose is to provide the developer (well, mainly me) with a means to easily insert comments adapted to the language of the source file you are currently editing.

## WHY ? ##
Because I have my own style of commenting.

Not php/java doc fragments neither C# xml-like comments, no, no... Just plain-text good old comments with sections that mimic the Unix manual pages. This is the commenting style I use ; I know that this is not the best style in the world but this is the one I chosed over all the commenting standards that can take the comments from your source code and generate a documentation from them.

And I do that for one reason : you can read my comments (such as those introducing a file's contents or a function goal) without being affected by the formatting imposed by automatic-help generators. My comments are divided into sections, and each section contents are free-form. 

I focused on providing comments that users can read, not on providing comments that satisfy the automatic help generator and relieve the developer from providing quality commenting (have you ever had a look at Zend Framework source code ?).

Since my comments have some kind of presentation, it would have been tedious to replay them each time I needed them. This is why I initially developed macros in VBA for VS2010. This was a quick but no-so-dirty development that gave me satisfaction for years.

## WHY A VSIX PACKAGE ? ##
One of my big personal development projects in PHP started to face some issues with VS2010 : launching the environment took 5 minutes on my configuration, followed by an additional 30-minutes where Visual Studio ate up to 50% of my dual-core CPU. I never found the reason why, and even the Visual Studio logs did not seem to give any information on what it was doing during all that time.

So I decided to go to VS2013 because I read somewhere that it was better optimized than VS2010. Surprise ! the VBA environment disappeared starting from VS2012.

Ok, I will develop an add-in. After a few hours spent in consulting walkthroughs and tech forums, I discovered that add-ins were superseded and will be replaced in the future by VS Packages.

Ok, I will develop a VS package. Hence this repository.

# HOW TO BUILD ? #
To build this package, you will need :

- My *(humble)* C# utility library : https://github.com/christian-vigh/sharpthrak
- The Scintilla.Net component : https://github.com/jacobslusser/ScintillaNET

You will probably need to remove them from the WutheringComments solution file, then add them again, because their relative path should differ from my computer.

Once successfully built, just launch the **WutheringComments.vsix** package installation file in the bin\Debug directory. Restart Visual Studio and the extension should be loaded.

# WHAT DOES THIS PACKAGE PROVIDE ? #
You will find two additional sub-menus in the **EDIT** menu :

- Comments : Allows you to insert specific comments
- Formatting : Some code-formatting shortcuts

You will also have a "Wuthering tools" page in the Tools/Options menu.

More documentation and a kinda walkthrough into developing VS Packages will be documented in a future release of this file...