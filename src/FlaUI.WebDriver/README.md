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

## Getting Started

This driver currenlty is only available by building from source.
Then after it has started, it can be used via WebDriver clients such as for example:

- [Selenium.WebDriver](https://www.nuget.org/packages/Selenium.WebDriver)
- [WebdriverIO](https://www.npmjs.com/package/webdriverio)

Using the [Selenium.WebDriver](https://www.nuget.org/packages/Selenium.WebDriver) C# client:

```C#
using OpenQA.Selenium;

public class FlaUIDriverOptions : DriverOptions
{
    public static FlaUIDriverOptions App(string path)
    {
        var options = new FlaUIDriverOptions()
        {
            PlatformName = "windows"
        };
        options.AddAdditionalOption("appium:app", path);
        return options;
    }

    public override ICapabilities ToCapabilities()
    {
        return GenerateDesiredCapabilities(true);
    }
}

var driver = new RemoteWebDriver(new Uri("http://localhost:4723"), FlaUIDriverOptions.App("C:\\YourApp.exe"))
```

Using the [WebdriverIO](https://www.npmjs.com/package/webdriverio) JavaScript client:

```JavaScript
import { remote } from 'webdriverio'

const driver = await remote({
    capabilities: {
        platformName: 'windows',
        'appium:app': 'C:\\YourApp.exe'
    }
});
```

## Selectors

On Windows, the recommended selectors, in order of reliability are:

| Selector                   | Locator strategy keyword | Supported?         |
| -------------------------- | ------------------------ | ------------------ |
| Automation ID              | `"accessibility id"`     | :white_check_mark: |
| Name                       | `"name"`                 | :white_check_mark: |
| Class name                 | `"class name"`           | :white_check_mark: |
| Link text selector         | `"link text"`            | :white_check_mark: |
| Partial link text selector | `"partial link text"`    | :white_check_mark: |
| Tag name                   | `"tag name"`             | :white_check_mark: |
| XPath selector             | `"xpath"`                |                    |
| CSS selector               | `"css selector"`         | Only class names   |

Using the Selenium C# client requires extending the `OpenQA.Selenium.By` class:

```C#
using OpenQA.Selenium;

public class ExtendedBy : By
{
    public ExtendedBy(string mechanism, string criteria) : base(mechanism, criteria)
    {
    }

    public static ExtendedBy AccessibilityId(string accessibilityId) => new ExtendedBy("accessibility id", accessibilityId);
    public static ExtendedBy NativeName(string name) => new ExtendedBy("name", name);
}

driver.FindElement(ExtendedBy.AccessibilityId("TextBox")).Click();
driver.FindElement(ExtendedBy.NativeName("TextBox")).Click();
driver.FindElement(By.ClassName("TextBox")).Click();
driver.FindElement(By.LinkText("Button")).Click();
driver.FindElement(By.PartialLinkText("Button")).Click();
driver.FindElement(By.TagName("RadioButton")).Click();

```

Using the WebdriverIO JavaScript client (see [WebdriverIO Selectors guide](https://webdriver.io/docs/selectors):

```JavaScript
await driver.$('~automationId').click();
await driver.$('[name="Name"]').click();
await driver.$('.TextBox').click();
await driver.$('=Button').click();
await driver.$('*=Button').click();
await driver.$('<RadioButton />').click();
```

## Windows

The driver supports switching windows. The behavior of windows is as following (identical to behavior of e.g. the Chrome driver):

- By default, the window is the window that the application was started with.
- The window does not change if the app/user opens another window, also not if that window happens to be on the foreground.
- ~~All open window handles from the same app process (same process ID in Windows) can be retrieved.~~ Currently only the main window and modal windows are returned when getting window handles. See issue below.
- Other processes spawned by the app that open windows are not visible as window handles.
  Those can be automated by starting a new driver session with e.g. the `appium:appTopLevelWindow` capability.
- Closing a window does not automatically switch the window handle.
  That means that after closing a window, most commands will return an error "no such window" until the window is switched.
- Switching to a window will set that window in the foreground.

> [!IMPORTANT]
> Currently only the main window and modal windows are returned when getting window handles. See <https://github.com/FlaUI/FlaUI/issues/596>

## Running scripts

The driver supports PowerShell commands.

Using the Selenium C# client:

```C#
var result = driver.ExecuteScript("powerShell", new Dictionary<string,string> { ["command"] = "1+1" });
```

Using the WebdriverIO JavaScript client:

```JavaScript
const result = driver.executeScript("powerShell", [{ command: `1+1` }]);
```

## Supported WebDriver Commands

| Method | URI Template                                                   | Command                        | Implemented        |
| ------ | -------------------------------------------------------------- | ------------------------------ | ------------------ |
| POST   | /session                                                       | New Session                    | :white_check_mark: |
| DELETE | /session/{session id}                                          | Delete Session                 | :white_check_mark: |
| GET    | /status                                                        | Status                         | :white_check_mark: |
| GET    | /session/{session id}/timeouts                                 | Get Timeouts                   | :white_check_mark: |
| POST   | /session/{session id}/timeouts                                 | Set Timeouts                   | :white_check_mark: |
| POST   | /session/{session id}/url                                      | Navigate To                    | N/A                |
| GET    | /session/{session id}/url                                      | Get Current URL                | N/A                |
| POST   | /session/{session id}/back                                     | Back                           | N/A                |
| POST   | /session/{session id}/forward                                  | Forward                        | N/A                |
| POST   | /session/{session id}/refresh                                  | Refresh                        | N/A                |
| GET    | /session/{session id}/title                                    | Get Title                      | :white_check_mark: |
| GET    | /session/{session id}/window                                   | Get Window Handle              | :white_check_mark: |
| DELETE | /session/{session id}/window                                   | Close Window                   | :white_check_mark: |
| POST   | /session/{session id}/window                                   | Switch To Window               | :white_check_mark: |
| GET    | /session/{session id}/window/handles                           | Get Window Handles             | :white_check_mark: |
| POST   | /session/{session id}/window/new                               | New Window                     |                    |
| POST   | /session/{session id}/frame                                    | Switch To Frame                | N/A                |
| POST   | /session/{session id}/frame/parent                             | Switch To Parent Frame         | N/A                |
| GET    | /session/{session id}/window/rect                              | Get Window Rect                | :white_check_mark: |
| POST   | /session/{session id}/window/rect                              | Set Window Rect                | :white_check_mark: |
| POST   | /session/{session id}/window/maximize                          | Maximize Window                |                    |
| POST   | /session/{session id}/window/minimize                          | Minimize Window                |                    |
| POST   | /session/{session id}/window/fullscreen                        | Fullscreen Window              |                    |
| GET    | /session/{session id}/element/active                           | Get Active Element             | :white_check_mark: |
| GET    | /session/{session id}/element/{element id}/shadow              | Get Element Shadow Root        | N/A                |
| POST   | /session/{session id}/element                                  | Find Element                   | :white_check_mark: |
| POST   | /session/{session id}/elements                                 | Find Elements                  | :white_check_mark: |
| POST   | /session/{session id}/element/{element id}/element             | Find Element From Element      | :white_check_mark: |
| POST   | /session/{session id}/element/{element id}/elements            | Find Elements From Element     | :white_check_mark: |
| POST   | /session/{session id}/shadow/{shadow id}/element               | Find Element From Shadow Root  | N/A                |
| POST   | /session/{session id}/shadow/{shadow id}/elements              | Find Elements From Shadow Root | N/A                |
| GET    | /session/{session id}/element/{element id}/selected            | Is Element Selected            | :white_check_mark: |
| GET    | /session/{session id}/element/{element id}/attribute/{name}    | Get Element Attribute          |                    |
| GET    | /session/{session id}/element/{element id}/property/{name}     | Get Element Property           |                    |
| GET    | /session/{session id}/element/{element id}/css/{property name} | Get Element CSS Value          |                    |
| GET    | /session/{session id}/element/{element id}/text                | Get Element Text               | :white_check_mark: |
| GET    | /session/{session id}/element/{element id}/name                | Get Element Tag Name           |                    |
| GET    | /session/{session id}/element/{element id}/rect                | Get Element Rect               | :white_check_mark: |
| GET    | /session/{session id}/element/{element id}/enabled             | Is Element Enabled             |                    |
| GET    | /session/{session id}/element/{element id}/computedrole        | Get Computed Role              |                    |
| GET    | /session/{session id}/element/{element id}/computedlabel       | Get Computed Label             |                    |
| POST   | /session/{session id}/element/{element id}/click               | Element Click                  | :white_check_mark: |
| POST   | /session/{session id}/element/{element id}/clear               | Element Clear                  | :white_check_mark: |
| POST   | /session/{session id}/element/{element id}/value               | Element Send Keys              | :white_check_mark: |
| GET    | /session/{session id}/source                                   | Get Page Source                | N/A                |
| POST   | /session/{session id}/execute/sync                             | Execute Script                 | :white_check_mark: |
| POST   | /session/{session id}/execute/async                            | Execute Async Script           |                    |
| GET    | /session/{session id}/cookie                                   | Get All Cookies                | N/A                |
| GET    | /session/{session id}/cookie/{name}                            | Get Named Cookie               | N/A                |
| POST   | /session/{session id}/cookie                                   | Add Cookie                     | N/A                |
| DELETE | /session/{session id}/cookie/{name}                            | Delete Cookie                  | N/A                |
| DELETE | /session/{session id}/cookie                                   | Delete All Cookies             | N/A                |
| POST   | /session/{session id}/actions                                  | Perform Actions                | :white_check_mark: |
| DELETE | /session/{session id}/actions                                  | Release Actions                | :white_check_mark: |
| POST   | /session/{session id}/alert/dismiss                            | Dismiss Alert                  |                    |
| POST   | /session/{session id}/alert/accept                             | Accept Alert                   |                    |
| GET    | /session/{session id}/alert/text                               | Get Alert Text                 |                    |
| POST   | /session/{session id}/alert/text                               | Send Alert Text                |                    |
| GET    | /session/{session id}/screenshot                               | Take Screenshot                | :white_check_mark: |
| GET    | /session/{session id}/element/{element id}/screenshot          | Take Element Screenshot        | :white_check_mark: |
| POST   | /session/{session id}/print                                    | Print Page                     |                    |

### WebDriver Interpretation

There is an interpretation to use the WebDriver specification to drive native automation. Appium does not seem to describe that interpretation and leaves it up to the implementer as well. Therefore we describe it here:

| WebDriver term                     | Interpretation                                                                                              |
| ---------------------------------- | ----------------------------------------------------------------------------------------------------------- |
| browser                            | The Windows OS on which the FlaUI.WebDriver instance is running                                             |
| top-level browsing contexts        | Any window of the app under test (modal windows too)                                                        |
| current top-level browsing context | The current selected window of the app under test                                                           |
| browsing contexts                  | Any window of the app under test (No difference with "top-level browsing contexts")                         |
| current browsing context           | The current selected window of the app under test (No difference with "current top-level browsing context") |
| window                             | Any window of the app under test (modal windows too)                                                        |
| frame                              | Not implemented - frames are only relevant for web drivers                                                  |
| shadow root                        | Not implemented - shadow roots are only relevant for web drivers                                            |
| cookie                             | Not implemented - cookies are only relevant for web drivers                                                 |

## Next Steps

Possible next steps for this project:

- Distribute as [Appium driver](http://appium.io/docs/en/2.1/ecosystem/build-drivers/)
