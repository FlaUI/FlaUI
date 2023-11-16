# FlaUI.WebDriver

FlaUI.WebDriver is a [W3C WebDriver2](https://www.w3.org/TR/webdriver2/) implementation using FlaUI's automation. It currently only supports UIA3.

> [!IMPORTANT]
> This WebDriver implementation is EXPERIMENTAL. It is not feature complete and may not implement all features correctly.

## Motivation

- [Microsoft's WinAppDriver](https://github.com/microsoft/WinAppDriver) used by [Appium Windows Driver](https://github.com/appium/appium-windows-driver) has many open issues, is [not actively maintained](https://github.com/microsoft/WinAppDriver/issues/1550) and [is not yet open source after many requests](https://github.com/microsoft/WinAppDriver/issues/1371).
  It implements [the obsolete JSON Wire Protocol](https://www.selenium.dev/documentation/legacy/json_wire_protocol/) by Selenium and not the new W3C WebDriver standard.
  When using it I stumbled upon various very basic issues, such as [that click doesn't always work](https://github.com/microsoft/WinAppDriver/issues/654).
- [kfrajtak/WinAppDriver](https://github.com/kfrajtak/WinAppDriver) is an open source alternative, but it's technology stack is outdated (.NET Framework, UIAComWrapper, AutoItX.Dotnet).
- W3C WebDriver is a standard that gives many options of automation frameworks such as [WebdriverIO](https://github.com/webdriverio/webdriverio) and [Selenium](https://github.com/SeleniumHQ/selenium).
  It allows to write test automation in TypeScript, Java or other languages of preference (using FlaUI requires C# knowledge).
- It is open source! Any missing command can be implemented quickly by raising a Pull Request.

## Capabilities

The following capabilities are supported:

| Capability Name          | Description                                                                                                                                                                                                                                 | Example value                     |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------- |
| platformName             | Must be set to `windows` (case-insensitive).                                                                                                                                                                                                | `windows`                         |
| appium:app               | The path to the application. It is also possible to set app to `Root`. In such case the session will be invoked without any explicit target application. Either this capability or `appTopLevelWindow` must be provided on session startup. | `C:\Windows\System32\notepad.exe` |
| appium:appTopLevelWindow | The hexadecimal handle of an existing application top level window to attach to, for example `0x12345` (should be of string type). Either this capability or app must be provided on session startup.                                       | `0xC0B46`                         |

## WebDriver commands

| Method | URI Template                                                   | Command                        | Implemented        | Notes |
| ------ | -------------------------------------------------------------- | ------------------------------ | ------------------ | ----- |
| POST   | /session                                                       | New Session                    | :white_check_mark: |       |
| DELETE | /session/{session id}                                          | Delete Session                 | :white_check_mark: |       |
| GET    | /status                                                        | Status                         | :white_check_mark: |       |
| GET    | /session/{session id}/timeouts                                 | Get Timeouts                   | :white_check_mark: |       |
| POST   | /session/{session id}/timeouts                                 | Set Timeouts                   | :white_check_mark: |       |
| POST   | /session/{session id}/url                                      | Navigate To                    |                    |       |
| GET    | /session/{session id}/url                                      | Get Current URL                |                    |       |
| POST   | /session/{session id}/back                                     | Back                           |                    |       |
| POST   | /session/{session id}/forward                                  | Forward                        |                    |       |
| POST   | /session/{session id}/refresh                                  | Refresh                        |                    |       |
| GET    | /session/{session id}/title                                    | Get Title                      |                    |       |
| GET    | /session/{session id}/window                                   | Get Window Handle              |                    |       |
| DELETE | /session/{session id}/window                                   | Close Window                   | :white_check_mark: |       |
| POST   | /session/{session id}/window                                   | Switch To Window               |                    |       |
| GET    | /session/{session id}/window/handles                           | Get Window Handles             |                    |       |
| POST   | /session/{session id}/window/new                               | New Window                     |                    |       |
| POST   | /session/{session id}/frame                                    | Switch To Frame                |                    |       |
| POST   | /session/{session id}/frame/parent                             | Switch To Parent Frame         |                    |       |
| GET    | /session/{session id}/window/rect                              | Get Window Rect                |                    |       |
| POST   | /session/{session id}/window/rect                              | Set Window Rect                |                    |       |
| POST   | /session/{session id}/window/maximize                          | Maximize Window                |                    |       |
| POST   | /session/{session id}/window/minimize                          | Minimize Window                |                    |       |
| POST   | /session/{session id}/window/fullscreen                        | Fullscreen Window              |                    |       |
| GET    | /session/{session id}/element/active                           | Get Active Element             | :white_check_mark: |       |
| GET    | /session/{session id}/element/{element id}/shadow              | Get Element Shadow Root        |                    |       |
| POST   | /session/{session id}/element                                  | Find Element                   | :white_check_mark: |       |
| POST   | /session/{session id}/elements                                 | Find Elements                  | :white_check_mark: |       |
| POST   | /session/{session id}/element/{element id}/element             | Find Element From Element      |                    |       |
| POST   | /session/{session id}/element/{element id}/elements            | Find Elements From Element     |                    |       |
| POST   | /session/{session id}/shadow/{shadow id}/element               | Find Element From Shadow Root  |                    |       |
| POST   | /session/{session id}/shadow/{shadow id}/elements              | Find Elements From Shadow Root |                    |       |
| GET    | /session/{session id}/element/{element id}/selected            | Is Element Selected            |                    |       |
| GET    | /session/{session id}/element/{element id}/attribute/{name}    | Get Element Attribute          |                    |       |
| GET    | /session/{session id}/element/{element id}/property/{name}     | Get Element Property           |                    |       |
| GET    | /session/{session id}/element/{element id}/css/{property name} | Get Element CSS Value          |                    |       |
| GET    | /session/{session id}/element/{element id}/text                | Get Element Text               | :white_check_mark: |       |
| GET    | /session/{session id}/element/{element id}/name                | Get Element Tag Name           |                    |       |
| GET    | /session/{session id}/element/{element id}/rect                | Get Element Rect               |                    |       |
| GET    | /session/{session id}/element/{element id}/enabled             | Is Element Enabled             |                    |       |
| GET    | /session/{session id}/element/{element id}/computedrole        | Get Computed Role              |                    |       |
| GET    | /session/{session id}/element/{element id}/computedlabel       | Get Computed Label             |                    |       |
| POST   | /session/{session id}/element/{element id}/click               | Element Click                  | :white_check_mark: |       |
| POST   | /session/{session id}/element/{element id}/clear               | Element Clear                  | :white_check_mark: |       |
| POST   | /session/{session id}/element/{element id}/value               | Element Send Keys              | :white_check_mark: |       |
| GET    | /session/{session id}/source                                   | Get Page Source                |                    |       |
| POST   | /session/{session id}/execute/sync                             | Execute Script                 | :white_check_mark: |       |
| POST   | /session/{session id}/execute/async                            | Execute Async Script           |                    |       |
| GET    | /session/{session id}/cookie                                   | Get All Cookies                |                    |       |
| GET    | /session/{session id}/cookie/{name}                            | Get Named Cookie               |                    |       |
| POST   | /session/{session id}/cookie                                   | Add Cookie                     |                    |       |
| DELETE | /session/{session id}/cookie/{name}                            | Delete Cookie                  |                    |       |
| DELETE | /session/{session id}/cookie                                   | Delete All Cookies             |                    |       |
| POST   | /session/{session id}/actions                                  | Perform Actions                | :white_check_mark: |       |
| DELETE | /session/{session id}/actions                                  | Release Actions                | :white_check_mark: |       |
| POST   | /session/{session id}/alert/dismiss                            | Dismiss Alert                  |                    |       |
| POST   | /session/{session id}/alert/accept                             | Accept Alert                   |                    |       |
| GET    | /session/{session id}/alert/text                               | Get Alert Text                 |                    |       |
| POST   | /session/{session id}/alert/text                               | Send Alert Text                |                    |       |
| GET    | /session/{session id}/screenshot                               | Take Screenshot                |                    |       |
| GET    | /session/{session id}/element/{element id}/screenshot          | Take Element Screenshot        |                    |       |
| POST   | /session/{session id}/print                                    | Print Page                     |                    |       |
