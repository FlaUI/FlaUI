# FlaUI

### Introduction
FlaUI is a .Net library which helps with automated UI testing of Windows applications (Win32, WinForms, WPF, Store Apps, ...).
It is based on the newest native UI Automation Library from Microsoft to support all cutting-edge technologies.
FlaUI wraps almost everything from the UI Automation Library but also provides the native objects in case someone has a special need which is not covered (yet).
FlaUI implements it's own wrapper around the native UIA Library. Some ideas are copied from the project UIAComWrapper and Teststack.White but rewritten from scratch to have a clean codebase.

### Build Status
|Repo|Build|Tests|
|:---|:------------------|:------------------|
|[FlaUI](https://github.com/Roemer/FlaUI)|[![Build status](https://ci.appveyor.com/api/projects/status/mwd2o329cma50sxe?svg=true)](https://ci.appveyor.com/project/RomanBaeriswyl/flaui)|[![Test status](http://flauschig.ch/batch.php?type=tests&account=RomanBaeriswyl&slug=flaui&branch=master)](https://ci.appveyor.com/project/RomanBaeriswyl/flaui/branch/master)|

### Usage
```csharp
var app =  Application.Launch("notepad.exe");
var window = app.GetMainWindow();
app.Automation.Keyboard.Write("Hello FlaUI!");
```
```csharp
var app = Application.Launch("calc.exe");
var window = app.GetMainWindow();
var button1 = window.FindFirst(TreeScope.Descendants, ConditionFactory.ByText("1")).AsButton();
button1.Invoke();
```

### Contribution
Feel free to fork FlaUI and send pull requests of your modifications.
You can also create issues if you find problems or have ideas on how to further improve FlaUI.
