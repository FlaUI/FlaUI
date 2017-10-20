# Changelog

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
