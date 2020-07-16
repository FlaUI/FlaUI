# Changelog

## 3.2.0 (2020-07-16)
### Breaking changes
  * None

### Enhancements
  * Add params on Process.Start (thanks @brunofmeurer)
  * Added .NET Core 3.1 Target Framework (thanks @torepaulsson)

### Bug fixes
  * Fixed GID Handle leak (thanks @ChrisZhang95)
  * Fixed .NET Core issue were the MainWindowHandle is not refreshed (thanks @torepaulsson)

## 3.1.0 (2020-05-19)
### Breaking changes
  * None

### Enhancements
  * Added ByFrameworkType condition
  * Allow xpath to find unknown types by mapping them to custom
  * Added support for Qt framework type
  * Added support for WinForms spinner (thanks @ddeltasolutions)
  * Added Capture.ScreensWithElement
  * Added customization of InfoOverlay font (thanks @petrsapak)
  * Added calendar support (thanks @ddeltasolutions)
  * Added date time picker support (thanks @ddeltasolutions)
  * Added support for large lists (thanks @ddeltasolutions)
  * Added application CloseTimeout and killIfCloseFails flag
  * Made the mouse movement speeds settable

### Bug fixes
  * Fixed null error in FrameworkId
  * Fix moving the mouse by 0 distance
  * Fixed search by AccessibilityRole

## 3.0.0 (2019-12-09)
### Introduction
This release combines all changes from the 2.x pre-release versions and also new features.
The main feature is the .NET Core/.NET Standard compatibility for FlaUI.Core and FlaUI.UIA3.

### Breaking changes
  * Renamed BasicAutomationElementBase to FrameworkAutomationElementBase
  * Consistent naming for the *Id interfaces/classes (eg. IDockPatternProperties to IDockPatternPropertyIds)
  * Reworked events
  * The `Find...` methods not do not use Retry anymore, the developer himself needs to decide if he wants to use a retry or not.
  * Moved DrawHighlight to extension methods so that they are fluent and can be made null-safe.
  * Reworked Retry
    * New flag: throwOnTimeout - Defines if Retry should throw when the timeout is reached.
    * New flag: ignoreException - Defines if Retry should continue in case of an exception.
    * New flag: lastValueOnTimeout - Defines if Retry should return the last successful value when it gets to a timeout.
    * New flag: defaultOnTimeout - Defines if Retry should return the default value on a timeout.
    * New Property: timeoutMessage - Allows adding a custom message when a timeout occurs when retrying.
    * Renamed Retry.While to Retry.WhileTrue
    * Added new Retry methods: WhileNull, WhileNotNull, WhileEmpty, Retry.WhileFalse
    * Added a `RetryResult` object that is returned on the `Retry` methods which contains information about the execution of the current `Retry`
    * Added tests
  * Moved AutomationElement one up in the namespace tree
  * Made the `As` methods extension methods again
  * Removed custom Point/Rectangle and use the one from System.Drawing
  * Moved `Capture` into the `Capturing` namespace
  * All `FindIndexed` are consistently renamed to `FindAt`
  * Renamed `Retry.Interval` to `Retry.DefaultInterval`
  * Renamed `Retry.Timeout` to `Retry.DefaultTimeout`

### Enhancements
  * .NET Core and Standard compatibility
  * Added capture overlays (mouse and info bar)
  * Added a video recorder (see [Capturing](https://github.com/Roemer/FlaUI/wiki/Capturing))
  * Updated the interop dlls
  * Added missing features from .NET 4.7.1 in UIA2
  * Added missing features from newer interop in UIA3
    * Transaction- and ConnectionTimeout
    * Selection2 pattern
    * New text attributes
    * New automation properties (CenterPoint, FillColor, ... see f2b444ef7d422344b63a187151112b77ca3299f5 for more)
    * FindWithOptions
    * New events
    * UIA3TextRange3
    * ConnectionRecoveryBehaviorOptions and CoalesceEventsOptions
    * MatchSubstring for property searching
  * Code cleanups
  * Added generic `AsType`
  * Use `UtcNow` instead of `Now` for `Retry`
  * `Wait.UntilInputIsProcessed` now has an optional timespan parameter
  * Reworked `OperationSystems` a bit
  * Retry, WaitWhileBusy, WaitWhilemainHandleIsMissing return a bool now to indicate success or failure
  * Capture does not focus the element anymore before capturing as this could have side effects
  * Added missing events
  * Added TextRange3
  * Made log levels configurable, added a logger where you can notify for logging events, added an NUnitProgressLogger which logs in real time to the nunit console
  * Added WaitUntilClickable and WaitUntilEnabled
  * Default value for ControlType (thanks to @lukasvogel)
  * Implemented mouse drag from point to point
  * Added a condition to search by a Framework Id (thanks to @SSHenninger)
  * Added `AnimationDuration` to `ComboBox`
  * Added a timeout message to `Retry`
  * Added `TextAttributeLibrary`
  * Added `Retry.Search` methods
  * Added `IsAvailable` property
  * Added `.As<T>` method
  * Enhanced `DataGrid` support for WPF (thanks @sparerd)
  * More documentation
  * Added various fallbacks to Win32 methods when UIA fails (thanks @ddeltasolutions)
  * Added Touch input support
  * Exposed MovePixelsPerMillisecond and MovePixelsPerStep in Mouse
  * Added IsChecked property for menu item (thanks @ddeltasolutions)

### Bug fixes
  * Added some sleeps to the mouse drag
  * Made xpath searching more robust (thanks to @lukasvogel)
  * Correctly use collapse in the expand pattern
  * Fixed `LabeledBy` property
  * Fixed null exception when getting the mouse cursor
  * Fixed an issue that the mouse cursor was not set correctly on multi-monitor environments

## 1.3.1 (2017-10-19)

### Bug fixes
  * Re-added install.ps1 to UIA3 NuGet package

## 1.3.0 (2017-10-19)

### Breaking changes
  * Renamed Helpers.WaitXXX to Wait.XXX
  * Project now only compiles on VS2017.3 or higher
  * Renamed scrollbars (VScrollBar -> VerticalScrollBar, HScrollBar -> HorizontalScrollBar)
  * Renamed ScreenCapture to Capture
  * Renamed ComCallWrapper to Com
  * Changed child collections from various namings to ".Items" (eg. in Menus)
  * Renamed State to ToggleState

### Enhancements
  * Switched build system to cake build
  * Various code cleanups and documentation improvements
  * Added signed versions (as separate nuget packages)
  * Added some convenience properties to the AutomationElement (IsEnabled, IsOffscreen, ...)
  * Added HasExited and ExitCode to Application.
  * Cleaned SystemProductNameFetcher and added support for Server 2016
  * Added IsSupported to AutomationProperty
  * Added Parent property
  * Added BoundingRectangle,ActualWidth,ActualHeight,ItemStatus and HelpText to AutomationElement
  * Implemented FindAt / FindIndexed
  * Added ByValue condition
  * Added IsReadOnly to ComboBox
  * Implemented ToggleButton
  * Implemented ListBox and ListBoxItem
  *  Added IsToggled to ToggleAutomationElement, added IsChecked to ChechBox
  * Added DataGridView
  * Reworked the Capture class

### Bug fixes
  * Correctly handle manually pressed modifiers when using Keyboard.Type
  * Added missing property in RegisterPropertyChangedEvent
  * Fixed finding the ScrollBars
  * Fixed typo in IPropertyLibrary

## 1.2.0 (2017-05-24)

### Breaking changes
  * Moved FlaUInspect to its own repository (see https://github.com/FlauTech/FlaUInspect)

### Enhancements
  * [Core] Added ENTER synonym for RETURN and ESC for ESCAPE
  * [Core] Made IsWin32Menu property on menu public

## 1.1.0 (2017-04-28)

### Enhancements
  * [Core] Added Select (index and string) for ComboBox
  * [Core] Added SelectedItem(s) and Select by cell value to Grid
  * [Core] Added a FindCellByText to GridRow
  * [Core] Implemented MenuItems with a string indexer
  * [Core] Added AutomationElement constructor which is based on another AutomationElement
  * [Core] Changed loglevel of "Closing application" to debug
  * [Core] Added overload for FindFirstChild and FindFirstDescendant with a string (AutomationId) parameter

### Bug fixes
  * [Core] Fix for WinForms where ComboBox does not support the SelectionPattern
  * [Core]Fix when directly setting the text in the combobox in uia2/winforms

## 1.0.0 (2017-04-13)

### Enhancements
  * [Core] Reworked the keyboard class a bit (e.g. allow simultaneous presses)
  * [All] More code documentation

### Bug fixes
  * [All] Fixed almost all ReSharper warnings

## 1.0.0-rc1 (2017-03-23)

### Breaking changes
  * [UIA3] Used Client interop instead of Core for UIA3

### Enhancements
  * [Core] Various code cleanups
  * [UIA3] Wrapped some more calls in ComCallWrapper

### Bug fixes
  * [Core] Fixed null exception on Window.Close without TitleBar.CloseButton
  * [All] Fixed .net 4.5 libraries in the packages

## 1.0.0-beta3 (2017-03-14)

### Breaking changes
  * [Core] Moved As... methods into the AutomationElement

### Enhancements
  * [Core] Added XMLDoc (also to nuget packages)
  * [Core] Return true/false if the application closed normally / forcefully
  * [Core] Reworked timeouts on Application.Wait methods (default to infinite)
  * [Core] Implemented ComboBoxItem (to correctly get the text for default WPF comboboxes)
  * [Core] Added AsHScrollBar and AsVScrollBar

## 1.0.0-beta2 (2017-03-13)

### Breaking changes
  * [Core] WaitWhileBusy and WaitWhileMainHandleIsMissing are now public and to not block endlessly

### Enhancements
  * [Core] Cleaned the Retry a bit
  * [Core] Refactored logging (thanks to [jmaxxz](https://github.com/jmaxxz))

### Bug fixes
  * [Core] Fallback to property for clickable point if GetClickablePoint fails
  * [Core] Fixed XPath when getting it for an element (eg. in FlaUInspect)

## 1.0.0-beta1 (2017-03-02)

### Breaking changes
  * [Core] Merged Table into Grid
  * [All] Properties are now wrapped in an AutomationProperty object which provides Value, ValorOrDefault and TryGetValue
  * [Al] Patterns are now wrapped in an IAutomationPattern object which provides Pattern, PatternOrDefault, TryGetPattern and IsSupported
  * [Core] Properties in the PropertyLibrary now do not contain the name "Property" anymore
  * [Core] Renamed .Information to .Properties

### Enhancements
  * [Inspect] Added Table Patterns support
  * [Code] Various code cleanups
  * [Core] Added search by XPath
  * [All] Implemented caching

## 0.6.2 (2017-02-10)

### Enhancements
  * [Core] Set move mouse to false by default
  * [Core] Added NoScroll ScrollPatternConstant for SetScrollPercent
  * [Inspect] Made supported patterns bold, added more pattern details
  * [Core] Added GetAllTopLevelWindows to Application
  
### Bug fixes
  * [Core] Fixed AndCondition.ToString

## 0.6.1 (2016-12-15)

### Breaking changes
  * Made ModalWindows a property

### Enhancements
  * Walk the parents to get a FrameworkType if no FrameWorkType was found
  * Added XAML FrameworkType (UWP apps)
  * Implemented WPF Popup
  * Fixed single items added multiple times (FlaUInspect)
  * Added some more pattern information (FlaUInspect)

### Bug fixes
  * Fixed UIA2 tree walker
  * Fixed role and state of LegacyIAccessiblePattern

## 0.6.0 (2016-11-11)

### Enhancements
  * Added .NET 3.5 and 4.0 versions of FlaUI

## 0.5.2 (2016-11-11)

### Enhancements
  * Added more convenience methods to chain the searching
  * Added search methods without conditions
  * Theoretical support for Win32 scrollbars

## 0.5.1 (2016-11-03)

### Enhancements
  * Added more convenience methods to chain the searching

## 0.5.0 (2016-11-03)

### Breaking changes
  * Removed made mouse and keyboard static, removed their interfaces
  * Renamed ListView to Grid
  * Renamed the retry methods

### Enhancements
  * Implemented Table
  * Added caching to TreeWalkers

### Bug fixes
  * Further reduced the amount of classes created

## 0.4.1 (2016-10-31)

### Enhancements
  * Implemented all text patterns
  * Exposed all property, event and textAttrbute ids
  * Implemented ScrollBars
  * Changed the OverlayManager to WinForms (faster and needs less memory than the WPF one)

### Bug fixes
  * Reduced the amount of classes created

## 0.4.0 (2016-10-20)

### Enhancements
  * Exposed AddToSelection and RemoveFromSelection
  * Improved the logic for ContextMenu finding (you can manually pass the desired logic)
  * Implemented ComboBox
  * Implemented TreeWalkers

### Bug fixes
  * Fixed a bug with the retry to speed things up quite a bit

## 0.3.4 (2016-10-18)

### Enhancements
  * Added some convenience methods for searching

### Bug fixes
  * Tests now run on German Windows
  * ControlType is now properly reported for UIA2
  * DoubleClick now does a real double click

## 0.3.3 (2016-10-14)

### Enhancements
  * Added many more patterns
  * Implemented ContextMenu on Window
  * Implemented ListView
  * Added True-/FalseCondition

### Bug fixes
  * Fixed UIA3 package to correctly install the interop assembly

## 0.3.2 (2016-10-07)

### Bug fixes

  * Fixed UIA3 package to correctly install the interop assembly
