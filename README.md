![Alt text](/FlaUI.png?raw=true "FlaUI")


### Badges
| What | Badge |
| ---- | ----- |
| *Chat* | [![Join the chat at https://gitter.im/FlaUI/Lobby](https://badges.gitter.im/FlaUI/Lobby.svg)](https://gitter.im/FlaUI/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge) |
| *Build* | [![Build status](https://ci.appveyor.com/api/projects/status/mwd2o329cma50sxe?svg=true)](https://ci.appveyor.com/project/RomanBaeriswyl/flaui) |
| *Tests* | ![AppVeyor tests](https://img.shields.io/appveyor/tests/RomanBaeriswyl/flaui) |
| *Libraries (NuGet)* | [![Nuget](https://img.shields.io/nuget/v/FlaUI.Core?label=FlaUI.Core)](https://www.nuget.org/packages/FlaUI.Core) [![Nuget](https://img.shields.io/nuget/v/FlaUI.UIA3?label=FlaUI.UIA3)](https://www.nuget.org/packages/FlaUI.UIA3) [![Nuget](https://img.shields.io/nuget/v/FlaUI.UIA2?label=FlaUI.UIA2)](https://www.nuget.org/packages/FlaUI.UIA2) |
| *CI Artefacts* | [FlaUI CI](https://ci.appveyor.com/project/RomanBaeriswyl/flaui/build/artifacts) |

### Introduction
FlaUI is a .NET library which helps with automated UI testing of Windows applications (Win32, WinForms, WPF, Store Apps, ...).<br />
It is based on native UI Automation libraries from Microsoft and therefore kind of a wrapper around them.<br />
FlaUI wraps almost everything from the UI Automation libraries but also provides the native objects in case someone has a special need which is not covered (yet) by FlaUI.<br />
Some ideas are copied from the UIAComWrapper project or TestStack.White but rewritten from scratch to have a clean codebase.

### Sponsoring
If you appreciate my work, feel free to support me by [sponsoring on github](https://github.com/sponsors/Roemer) or with a one-time payment [over at PayPal](https://paypal.me/rbaeriswyl).

### Why another library?
There are quite some automation solutions out there. Commercial ones like TestComplete, Ranorex, CodedUI just to name a few. And also free ones which are mainly TestStack.White.<br />
All of them are based on what Microsoft provides. These are the UI Automation libraries. There are three versions of it:
- MSAA
  - MSAA is very obsolete and we'll skip this here (some like CodedUI still use it)
- UIA2: Managed Library for native UI Automation API
  - UIA2 is managed only, which would be good for C# but it does not support newer features (like touch) and it also does not work well with WPF or even worse with Windows Store Apps.
- UIA3: Com Library for native UI Automation API
  - UIA3 is the newest of them all and works great for WPF / Windows Store Apps but unfortunately, it can have some bugs with WinForms applications (see [FAQ](https://github.com/FlaUI/FlaUI/wiki/FAQ)) which are not existent in UIA2.

So, the commercial solutions are mostly based on multiple of those and/or implement a lot of workaround code to fix those issues.
TestStack.White has two versions, one for UIA2 and one for UIA3 but because of the old codebase, it's fairly hard to bring UIA3 to work. For this, it also uses an additional library, the UIAComWrapper which uses the same naming as the managed UIA2 and wraps the UIA3 com interop with them (one more source for errors).
FlaUI now tries to provide an interface for UIA2 and UIA3 where the developer can choose, which version he wants to use. It should also provide a very clean and modern codebase so that collaboration and further development is as easy as possible.

### Usage
##### Installation
To use FlaUI, you need to reference the appropriate assemblies. So you should decide, if you want to use UIA2 or UIA3 and install the appropriate library from NuGet. You can of course always download the source and compile it yourself.
##### Usage in Code
The entry point is usually an application or the desktop so you get an automation element (like a the main window of the application).
On this, you can then search sub-elements and interact with them.
There is a helper class to launch, attach or close applications.
Since the application is not related to any UIA library, you need to create the automation you want and use it to get your first element, which then is your entry point.
```csharp
using FlaUI.UIA3;

var app = FlaUI.Core.Application.Launch("notepad.exe");
using (var automation = new UIA3Automation())
{
	var window = app.GetMainWindow(automation);
	Console.WriteLine(window.Title);
	...
}
```
```csharp
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

// Note: Works only pre-Windows 8 with the legacy calculator
var app = FlaUI.Core.Application.Launch("calc.exe");
using (var automation = new UIA3Automation())
{
	var window = app.GetMainWindow(automation);
	var button1 = window.FindFirstDescendant(cf => cf.ByText("1"))?.AsButton();
	button1?.Invoke();
	...
}
```

### Further Resources
#### YouTube Tutorials
Have a look at [H Y R Tutorials](https://www.youtube.com/playlist?list=PLacgMXFs7kl_fuSSe6lp6YRaeAp6vqra9). This channel provides some videos to get you started with FlaUI.
#### FlaUI UITests
FlaUI itself contains quite some UI tests itself. Browse to the code of them [here](https://github.com/FlaUI/FlaUI/tree/master/src/FlaUI.Core.UITests) and look how they work.
#### Chat
Head over to the [chat](https://gitter.im/FlaUI/Lobby) to ask your specific questions.

### Contribution
Feel free to fork FlaUI and send pull requests of your modifications.<br />
You can also create issues if you find problems or have ideas on how to further improve FlaUI.

### Donors and Sponsors
- Thank you Gehtsoft USA LLC for the generous donation

### Acknowledgements
#### JetBrains
Thanks to [JetBrains](https://www.jetbrains.com) for providing a free license of [ReSharper](https://www.jetbrains.com/resharper/).
#### AppVeyor
Thanks to [AppVeyor](https://www.appveyor.com) for providing a free CI [build system for FlaUI](https://ci.appveyor.com/project/RomanBaeriswyl/flaui).
#### TestStack.White
Thanks to the creators and maintainers (especially to [@JakeGinnivan](https://github.com/JakeGinnivan) and [@petmongrels](https://github.com/petmongrels)) for their work and inspiration for this project.
#### Microsoft
Thanks to Microsoft for providing great tools which made developing this project possible.
