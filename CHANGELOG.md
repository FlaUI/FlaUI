# Changelog

## vNext (xxxx-xx-xx)

### Breaking changes
  * [Core] Merged Table into Grid

### Enhancements
  * [Inspect] Added Table Patterns support
  * [Code] Various code cleanups

### Bug fixes
  * None yet

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
