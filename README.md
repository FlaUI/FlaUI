# FlaUI

### Chat
[![Join the chat at https://gitter.im/FlaUI/Lobby](https://badges.gitter.im/FlaUI/Lobby.svg)](https://gitter.im/FlaUI/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
### Build
[![Build status](https://ci.appveyor.com/api/projects/status/mwd2o329cma50sxe?svg=true)](https://ci.appveyor.com/project/RomanBaeriswyl/flaui)
[![Test status](http://flauschig.ch/batch.php?type=tests&account=RomanBaeriswyl&slug=flaui&branch=master)](https://ci.appveyor.com/project/RomanBaeriswyl/flaui/branch/master)
### Download (NuGet)
[![NuGet FlaUI.Core](http://flauschig.ch/nubadge.php?id=FlaUI.Core)](https://www.nuget.org/packages/FlaUI.Core)
[![NuGet FlaUI.UIA2](http://flauschig.ch/nubadge.php?id=FlaUI.UIA2)](https://www.nuget.org/packages/FlaUI.UIA2)
[![NuGet FlaUI.UIA3](http://flauschig.ch/nubadge.php?id=FlaUI.UIA3)](https://www.nuget.org/packages/FlaUI.UIA3)

[![FlaUInspect](https://img.shields.io/badge/FLaUInspect-CI%20build-brightgreen.svg)](https://ci.appveyor.com/api/projects/RomanBaeriswyl/flaui/artifacts/src%2FFlaUInspect%2Fbin%2FFlaUInspect.zip?branch=master)

### Introduction
FlaUI is a .NET library which helps with automated UI testing of Windows applications (Win32, WinForms, WPF, Store Apps, ...).<br />
It is based on native UI Automation libraries from Microsoft and therefore kind of a wrapper around them.<br />
FlaUI wraps almost everything from the UI Automation libraries but also provides the native objects in case someone has a special need which is not covered (yet) by FlaUI.<br />
Some ideas are copied from the UIAComWrapper project or TestStack.White but rewritten from scratch to have a clean codebase.

### Why another library?
There are quite some automation solutions out there. Commercial ones like TestComplete, Ranorex, CodedUI just to name a few. And also free ones which are mainly TestStack.White.<br />
All of them are based on what Microsoft provides. These are the UI Automation libraries. There are three versions of it:
- MSAA
  - MSAA is very obsolete and we'll skip this here (some like CodedUI still use it)
- UIA2: Managed Library for UI Automation
  - UIA2 is managed only, which would be good for C# but it is not maintained anymore and does not support newer features (like touch) and it also does not work well with WPF or even worse with Windows Store Apps.
- UIA3: Com Library for UI Automation
  - UIA3 is the newest of them all which is still the actual version (and should be maintained). This one works great for WPF / Windows Store Apps but unfortunately, it has quite some bugs with WinForm applications which are not existent in UIA2.

So, the commercial solutions are mostly based on multiple of those and/or implement a lot of workaround code to fix those issues.
TestStack.White has two versions, one for UIA2 and one for UIA3 but because of the old codebase, it's fairly hard to bring UIA3 to work. For this, it also uses an additional library, the UIAComWrapper which uses the same naming as the managed UIA2 and wraps the UIA3 com interop with them (one more source for errors).
FlaUI now tries to provide an interface for UIA2 and UIA3 where the developer can choose, which version he wants to use. It should also provide a very clean and modern codebase so that collaboration and further development is as easy as possible.

### Usage
##### Installation
To use FlaUI, you need to reference the appropriate assemblies. So you should decide, if you want to use UIA2 or UIA3 or both and install the appropriate library from NuGet. You can of course always download the source and compile it yourself.
##### Usage in Code
The entry point is usually an application or the desktop so you get an automation element (like a the main window of the application).
On this, you can then search sub-elements and interact with them.
There is a helper class to launch, attach or close applications.
Since the application is not related to any UIA library, you need to create the automation you want and use it to get your first element, which then is your entry point.
```csharp
var app =  Application.Launch("notepad.exe");
using (var automation = new UIA3Automation())
{
	var window = app.GetMainWindow(automation);
	Console.WriteLine(window.Title);
	...
}
```
```csharp
var app = Application.Launch("calc.exe");
using (var automation = new UIA3Automation())
{
	var window = app.GetMainWindow(automation);
	var button1 = window.FindFirst(TreeScope.Descendants, ConditionFactory.ByText("1")).AsButton();
	button1.Invoke();
	...
}
```

### Contribution
Feel free to fork FlaUI and send pull requests of your modifications.<br />
You can also create issues if you find problems or have ideas on how to further improve FlaUI.
