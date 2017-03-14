# Changelog

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
