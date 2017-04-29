# Font Sizer

<!-- Replace this badge with your own-->
[![Build status](https://ci.appveyor.com/api/projects/status/tnus4nu8x9f65vbd?svg=true)](https://ci.appveyor.com/project/kdawg1406/fontsizer)

<!-- Update the VS Gallery link after you upload the VSIX-->
Download this extension from the [VS Gallery](https://visualstudiogallery.msdn.microsoft.com/[GuidFromGallery])
or get the [CI build](http://vsixgallery.com/extension/a7f3c8a0-dc70-429d-8ca5-7ccc9b09e013/).

---------------------------------------

Visual Studio 2017 Extension for easily change the font sizes in the editors or environment.

See the [change log](CHANGELOG.md) for changes and road map.

### Credits
I learned a lot from this oustanding extension.  Essentially, I updated for VS 2017 and added environment font size changing.  Sam Harwell gets all the credit for the hard work.
https://github.com/tunnelvisionlabs/PresentationMode

## Features
Quickly change the editor's font sizes or the environment's font size.

Recommend assigning shortcut keys to each of the 4 commands. These are the commands I use:

- CTRL + Num Pad Arrow Up = Increase editor font sizes
- CTRL + Num Pad Arrow Down = Decrease editor font sizes
- CTRL + Num Pad Arrow Right = Increase environment font size
- CTRL + Num Pad Arrow Left = Increase environment font size


### Change Editor Font Size
Each time the respective Editor increase font size or decrese font size command is invoked the following changes are made:

- TextEditor changes by 2
- StatementCompletion changes by 1
- TextOutputToolWindows changes by 1
- Tooltip changes by 1
- CodeLensCategory changes by 1

### Change Environment Font Size
Each time the respective Editor increase font size or decrese font size command is invoked the environment font size is changed by 2.

For cloning and building this project yourself, make sure
to install the
[Extensibility Tools 2015](https://visualstudiogallery.msdn.microsoft.com/ab39a092-1343-46e2-b0f1-6a3f91155aa6)
extension for Visual Studio which enables some features
used by this project.

## License
[Apache 2.0](LICENSE)