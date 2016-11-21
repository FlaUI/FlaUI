using System;

// ReSharper disable InconsistentNaming

namespace FlaUI.Core.WindowsAPI
{
    public static class CommonHresultValues
    {
        public const long S_OK = 0x00000000; // Operation successful
        public const long E_ABORT = 0x80004004; // Operation aborted
        public const long E_ACCESSDENIED = 0x80070005; // General access denied error
        public const long E_FAIL = 0x80004005; // Unspecified failure
        public const long E_HANDLE = 0x80070006; // Handle that is not valid
        public const long E_INVALIDARG = 0x80070057; // One or more arguments are not valid
        public const long E_NOINTERFACE = 0x80004002; // No such interface supported
        public const long E_NOTIMPL = 0x80004001; // Not implemented
        public const long E_OUTOFMEMORY = 0x8007000E; // Failed to allocate necessary memory
        public const long E_POINTER = 0x80004003; // Pointer that is not valid
        public const long E_UNEXPECTED = 0x8000FFFF; // Unexpected failure
    }

    public static class WindowsMessages
    {
        public const uint WM_ACTIVATE = 0x0006;
        public const uint WM_ACTIVATEAPP = 0x001C;
        public const uint WM_AFXFIRST = 0x0360;
        public const uint WM_AFXLAST = 0x037F;
        public const uint WM_APP = 0x8000;
        public const uint WM_APPCOMMAND = 0x0319;
        public const uint WM_ASKCBFORMATNAME = 0x030C;
        public const uint WM_CANCELJOURNAL = 0x004B;
        public const uint WM_CANCELMODE = 0x001F;
        public const uint WM_CAPTURECHANGED = 0x0215;
        public const uint WM_CHANGECBCHAIN = 0x030D;
        public const uint WM_CHANGEUISTATE = 0x0127;
        public const uint WM_CHAR = 0x0102;
        public const uint WM_CHARTOITEM = 0x002F;
        public const uint WM_CHILDACTIVATE = 0x0022;
        public const uint WM_CLEAR = 0x0303;
        public const uint WM_CLOSE = 0x0010;
        public const uint WM_COMMAND = 0x0111;
        public const uint WM_COMMNOTIFY = 0x0044;
        public const uint WM_COMPACTING = 0x0041;
        public const uint WM_COMPAREITEM = 0x0039;
        public const uint WM_CONTEXTMENU = 0x007B;
        public const uint WM_COPY = 0x0301;
        public const uint WM_COPYDATA = 0x004A;
        public const uint WM_CREATE = 0x0001;
        public const uint WM_CTLCOLORBTN = 0x0135;
        public const uint WM_CTLCOLORDLG = 0x0136;
        public const uint WM_CTLCOLOREDIT = 0x0133;
        public const uint WM_CTLCOLORLISTBOX = 0x0134;
        public const uint WM_CTLCOLORMSGBOX = 0x0132;
        public const uint WM_CTLCOLORSCROLLBAR = 0x0137;
        public const uint WM_CTLCOLORSTATIC = 0x0138;
        public const uint WM_CUT = 0x0300;
        public const uint WM_DEADCHAR = 0x0103;
        public const uint WM_DELETEITEM = 0x002D;
        public const uint WM_DESTROY = 0x0002;
        public const uint WM_DESTROYCLIPBOARD = 0x0307;
        public const uint WM_DEVICECHANGE = 0x0219;
        public const uint WM_DEVMODECHANGE = 0x001B;
        public const uint WM_DISPLAYCHANGE = 0x007E;
        public const uint WM_DRAWCLIPBOARD = 0x0308;
        public const uint WM_DRAWITEM = 0x002B;
        public const uint WM_DROPFILES = 0x0233;
        public const uint WM_ENABLE = 0x000A;
        public const uint WM_ENDSESSION = 0x0016;
        public const uint WM_ENTERIDLE = 0x0121;
        public const uint WM_ENTERMENULOOP = 0x0211;
        public const uint WM_ENTERSIZEMOVE = 0x0231;
        public const uint WM_ERASEBKGND = 0x0014;
        public const uint WM_EXITMENULOOP = 0x0212;
        public const uint WM_EXITSIZEMOVE = 0x0232;
        public const uint WM_FONTCHANGE = 0x001D;
        public const uint WM_GETDLGCODE = 0x0087;
        public const uint WM_GETFONT = 0x0031;
        public const uint WM_GETHOTKEY = 0x0033;
        public const uint WM_GETICON = 0x007F;
        public const uint WM_GETMINMAXINFO = 0x0024;
        public const uint WM_GETOBJECT = 0x003D;
        public const uint WM_GETTEXT = 0x000D;
        public const uint WM_GETTEXTLENGTH = 0x000E;
        public const uint WM_HANDHELDFIRST = 0x0358;
        public const uint WM_HANDHELDLAST = 0x035F;
        public const uint WM_HELP = 0x0053;
        public const uint WM_HOTKEY = 0x0312;
        public const uint WM_HSCROLL = 0x0114;
        public const uint WM_HSCROLLCLIPBOARD = 0x030E;
        public const uint WM_ICONERASEBKGND = 0x0027;
        public const uint WM_IME_CHAR = 0x0286;
        public const uint WM_IME_COMPOSITION = 0x010F;
        public const uint WM_IME_COMPOSITIONFULL = 0x0284;
        public const uint WM_IME_CONTROL = 0x0283;
        public const uint WM_IME_ENDCOMPOSITION = 0x010E;
        public const uint WM_IME_KEYDOWN = 0x0290;
        public const uint WM_IME_KEYLAST = 0x010F;
        public const uint WM_IME_KEYUP = 0x0291;
        public const uint WM_IME_NOTIFY = 0x0282;
        public const uint WM_IME_REQUEST = 0x0288;
        public const uint WM_IME_SELECT = 0x0285;
        public const uint WM_IME_SETCONTEXT = 0x0281;
        public const uint WM_IME_STARTCOMPOSITION = 0x010D;
        public const uint WM_INITDIALOG = 0x0110;
        public const uint WM_INITMENU = 0x0116;
        public const uint WM_INITMENUPOPUP = 0x0117;
        public const uint WM_INPUT = 0x00FF;
        public const uint WM_INPUTLANGCHANGE = 0x0051;
        public const uint WM_INPUTLANGCHANGEREQUEST = 0x0050;
        public const uint WM_KEYDOWN = 0x0100;
        public const uint WM_KEYFIRST = 0x0100;
        public const uint WM_KEYLAST = 0x0109;
        public const uint WM_KEYUP = 0x0101;
        public const uint WM_KILLFOCUS = 0x0008;
        public const uint WM_LBUTTONDBLCLK = 0x0203;
        public const uint WM_LBUTTONDOWN = 0x0201;
        public const uint WM_LBUTTONUP = 0x0202;
        public const uint WM_MBUTTONDBLCLK = 0x0209;
        public const uint WM_MBUTTONDOWN = 0x0207;
        public const uint WM_MBUTTONUP = 0x0208;
        public const uint WM_MDIACTIVATE = 0x0222;
        public const uint WM_MDICASCADE = 0x0227;
        public const uint WM_MDICREATE = 0x0220;
        public const uint WM_MDIDESTROY = 0x0221;
        public const uint WM_MDIGETACTIVE = 0x0229;
        public const uint WM_MDIICONARRANGE = 0x0228;
        public const uint WM_MDIMAXIMIZE = 0x0225;
        public const uint WM_MDINEXT = 0x0224;
        public const uint WM_MDIREFRESHMENU = 0x0234;
        public const uint WM_MDIRESTORE = 0x0223;
        public const uint WM_MDISETMENU = 0x0230;
        public const uint WM_MDITILE = 0x0226;
        public const uint WM_MEASUREITEM = 0x002C;
        public const uint WM_MENUCHAR = 0x0120;
        public const uint WM_MENUCOMMAND = 0x0126;
        public const uint WM_MENUDRAG = 0x0123;
        public const uint WM_MENUGETOBJECT = 0x0124;
        public const uint WM_MENURBUTTONUP = 0x0122;
        public const uint WM_MENUSELECT = 0x011F;
        public const uint WM_MOUSEACTIVATE = 0x0021;
        public const uint WM_MOUSEFIRST = 0x0200;
        public const uint WM_MOUSEHOVER = 0x02A1;
        public const uint WM_MOUSELAST = 0x020D; // Win95: 0x0209, WinNT4,98: 0x020A
        public const uint WM_MOUSELEAVE = 0x02A3;
        public const uint WM_MOUSEMOVE = 0x0200;
        public const uint WM_MOUSEWHEEL = 0x020A;
        public const uint WM_MOVE = 0x0003;
        public const uint WM_MOVING = 0x0216;
        public const uint WM_NCACTIVATE = 0x0086;
        public const uint WM_NCCALCSIZE = 0x0083;
        public const uint WM_NCCREATE = 0x0081;
        public const uint WM_NCDESTROY = 0x0082;
        public const uint WM_NCHITTEST = 0x0084;
        public const uint WM_NCLBUTTONDBLCLK = 0x00A3;
        public const uint WM_NCLBUTTONDOWN = 0x00A1;
        public const uint WM_NCLBUTTONUP = 0x00A2;
        public const uint WM_NCMBUTTONDBLCLK = 0x00A9;
        public const uint WM_NCMBUTTONDOWN = 0x00A7;
        public const uint WM_NCMBUTTONUP = 0x00A8;
        public const uint WM_NCMOUSEHOVER = 0x02A0;
        public const uint WM_NCMOUSELEAVE = 0x02A2;
        public const uint WM_NCMOUSEMOVE = 0x00A0;
        public const uint WM_NCPAINT = 0x0085;
        public const uint WM_NCRBUTTONDBLCLK = 0x00A6;
        public const uint WM_NCRBUTTONDOWN = 0x00A4;
        public const uint WM_NCRBUTTONUP = 0x00A5;
        public const uint WM_NCXBUTTONDBLCLK = 0x00AD;
        public const uint WM_NCXBUTTONDOWN = 0x00AB;
        public const uint WM_NCXBUTTONUP = 0x00AC;
        public const uint WM_NEXTDLGCTL = 0x0028;
        public const uint WM_NEXTMENU = 0x0213;
        public const uint WM_NOTIFY = 0x004E;
        public const uint WM_NOTIFYFORMAT = 0x0055;
        public const uint WM_NULL = 0x0000;
        public const uint WM_PAINT = 0x000F;
        public const uint WM_PAINTCLIPBOARD = 0x0309;
        public const uint WM_PAINTICON = 0x0026;
        public const uint WM_PALETTECHANGED = 0x0311;
        public const uint WM_PALETTEISCHANGING = 0x0310;
        public const uint WM_PARENTNOTIFY = 0x0210;
        public const uint WM_PASTE = 0x0302;
        public const uint WM_PENWINFIRST = 0x0380;
        public const uint WM_PENWINLAST = 0x038F;
        public const uint WM_POWER = 0x0048;
        public const uint WM_POWERBROADCAST = 0x0218;
        public const uint WM_PRINT = 0x0317;
        public const uint WM_PRINTCLIENT = 0x0318;
        public const uint WM_QUERYDRAGICON = 0x0037;
        public const uint WM_QUERYENDSESSION = 0x0011;
        public const uint WM_QUERYNEWPALETTE = 0x030F;
        public const uint WM_QUERYOPEN = 0x0013;
        public const uint WM_QUERYUISTATE = 0x0129;
        public const uint WM_QUEUESYNC = 0x0023;
        public const uint WM_QUIT = 0x0012;
        public const uint WM_RBUTTONDBLCLK = 0x0206;
        public const uint WM_RBUTTONDOWN = 0x0204;
        public const uint WM_RBUTTONUP = 0x0205;
        public const uint WM_RENDERALLFORMATS = 0x0306;
        public const uint WM_RENDERFORMAT = 0x0305;
        public const uint WM_SETCURSOR = 0x0020;
        public const uint WM_SETFOCUS = 0x0007;
        public const uint WM_SETFONT = 0x0030;
        public const uint WM_SETHOTKEY = 0x0032;
        public const uint WM_SETICON = 0x0080;
        public const uint WM_SETREDRAW = 0x000B;
        public const uint WM_SETTEXT = 0x000C;
        public const uint WM_SETTINGCHANGE = 0x001A;
        public const uint WM_SHOWWINDOW = 0x0018;
        public const uint WM_SIZE = 0x0005;
        public const uint WM_SIZECLIPBOARD = 0x030B;
        public const uint WM_SIZING = 0x0214;
        public const uint WM_SPOOLERSTATUS = 0x002A;
        public const uint WM_STYLECHANGED = 0x007D;
        public const uint WM_STYLECHANGING = 0x007C;
        public const uint WM_SYNCPAINT = 0x0088;
        public const uint WM_SYSCHAR = 0x0106;
        public const uint WM_SYSCOLORCHANGE = 0x0015;
        public const uint WM_SYSCOMMAND = 0x0112;
        public const uint WM_SYSDEADCHAR = 0x0107;
        public const uint WM_SYSKEYDOWN = 0x0104;
        public const uint WM_SYSKEYUP = 0x0105;
        public const uint WM_TABLET_FIRST = 0x02C0;
        public const uint WM_TABLET_LAST = 0x02DF;
        public const uint WM_TCARD = 0x0052;
        public const uint WM_THEMECHANGED = 0x031A;
        public const uint WM_TIMECHANGE = 0x001E;
        public const uint WM_TIMER = 0x0113;
        public const uint WM_UNDO = 0x0304;
        public const uint WM_UNICHAR = 0x0109;
        public const uint WM_UNINITMENUPOPUP = 0x0125;
        public const uint WM_UPDATEUISTATE = 0x0128;
        public const uint WM_USER = 0x0400;
        public const uint WM_USERCHANGED = 0x0054;
        public const uint WM_VKEYTOITEM = 0x002E;
        public const uint WM_VSCROLL = 0x0115;
        public const uint WM_VSCROLLCLIPBOARD = 0x030A;
        public const uint WM_WINDOWPOSCHANGED = 0x0047;
        public const uint WM_WINDOWPOSCHANGING = 0x0046;
        public const uint WM_WININICHANGE = 0x001A;
        public const uint WM_WTSSESSION_CHANGE = 0x02B1;
        public const uint WM_XBUTTONDBLCLK = 0x020D;
        public const uint WM_XBUTTONDOWN = 0x020B;
        public const uint WM_XBUTTONUP = 0x020C;
    }

    public static class WindowLongParam
    {
        public const int GWL_WNDPROC = -4;
        public const int GWL_HINSTANCE = -6;
        public const int GWL_HWNDPARENT = -8;
        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;
        public const int GWL_USERDATA = -21;
        public const int GWL_ID = -12;
    }

    public static class WindowStyles
    {
        public const uint WS_OVERLAPPED = 0x00000000;
        public const uint WS_POPUP = 0x80000000;
        public const uint WS_CHILD = 0x40000000;
        public const uint WS_MINIMIZE = 0x20000000;
        public const uint WS_VISIBLE = 0x10000000;
        public const uint WS_DISABLED = 0x08000000;
        public const uint WS_CLIPSIBLINGS = 0x04000000;
        public const uint WS_CLIPCHILDREN = 0x02000000;
        public const uint WS_MAXIMIZE = 0x01000000;
        public const uint WS_CAPTION = 0x00C00000; /* WS_BORDER | WS_DLGFRAME */
        public const uint WS_BORDER = 0x00800000;
        public const uint WS_DLGFRAME = 0x00400000;
        public const uint WS_VSCROLL = 0x00200000;
        public const uint WS_HSCROLL = 0x00100000;
        public const uint WS_SYSMENU = 0x00080000;
        public const uint WS_THICKFRAME = 0x00040000;
        public const uint WS_GROUP = 0x00020000;
        public const uint WS_TABSTOP = 0x00010000;

        public const uint WS_MINIMIZEBOX = 0x00020000;
        public const uint WS_MAXIMIZEBOX = 0x00010000;

        public const uint WS_TILED = WS_OVERLAPPED;
        public const uint WS_ICONIC = WS_MINIMIZE;
        public const uint WS_SIZEBOX = WS_THICKFRAME;
        public const uint WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;

        // Common Window Styles
        public const uint WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;
        public const uint WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU;
        public const uint WS_CHILDWINDOW = WS_CHILD;

        //Extended Window Styles
        public const uint WS_EX_DLGMODALFRAME = 0x00000001;
        public const uint WS_EX_NOPARENTNOTIFY = 0x00000004;
        public const uint WS_EX_TOPMOST = 0x00000008;
        public const uint WS_EX_ACCEPTFILES = 0x00000010;
        public const uint WS_EX_TRANSPARENT = 0x00000020;

        //#if(WINVER >= 0x0400)
        public const uint WS_EX_MDICHILD = 0x00000040;
        public const uint WS_EX_TOOLWINDOW = 0x00000080;
        public const uint WS_EX_WINDOWEDGE = 0x00000100;
        public const uint WS_EX_CLIENTEDGE = 0x00000200;
        public const uint WS_EX_CONTEXTHELP = 0x00000400;

        public const uint WS_EX_RIGHT = 0x00001000;
        public const uint WS_EX_LEFT = 0x00000000;
        public const uint WS_EX_RTLREADING = 0x00002000;
        public const uint WS_EX_LTRREADING = 0x00000000;
        public const uint WS_EX_LEFTSCROLLBAR = 0x00004000;
        public const uint WS_EX_RIGHTSCROLLBAR = 0x00000000;

        public const uint WS_EX_CONTROLPARENT = 0x00010000;
        public const uint WS_EX_STATICEDGE = 0x00020000;
        public const uint WS_EX_APPWINDOW = 0x00040000;

        public const uint WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE;
        public const uint WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST;
        //#endif /* WINVER >= 0x0400 */

        //#if(_WIN32_WINNT >= 0x0500)
        public const uint WS_EX_LAYERED = 0x00080000;
        //#endif /* _WIN32_WINNT >= 0x0500 */

        //#if(WINVER >= 0x0500)
        public const uint WS_EX_NOINHERITLAYOUT = 0x00100000; // Disable inheritence of mirroring by children
        public const uint WS_EX_LAYOUTRTL = 0x00400000; // Right to left mirroring
        //#endif /* WINVER >= 0x0500 */

        //#if(_WIN32_WINNT >= 0x0500)
        public const uint WS_EX_COMPOSITED = 0x02000000;
        public const uint WS_EX_NOACTIVATE = 0x08000000;
        //#endif /* _WIN32_WINNT >= 0x0500 */
    }

    public static class SetWindowPosFlags
    {
        public const int SWP_NOSIZE = 0x0001;
        public const int SWP_NOMOVE = 0x0002;
        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_NOREDRAW = 0x0008;
        public const int SWP_NOACTIVATE = 0x0010;
        public const int SWP_FRAMECHANGED = 0x0020;
        public const int SWP_SHOWWINDOW = 0x0040;
        public const int SWP_HIDEWINDOW = 0x0080;
        public const int SWP_NOCOPYBITS = 0x0100;
        public const int SWP_NOOWNERZORDER = 0x0200;
        public const int SWP_DRAWFRAME = SWP_FRAMECHANGED;
        public const int SWP_NOREPOSITION = SWP_NOOWNERZORDER;
        public const int SWP_NOSENDCHANGING = 0x0400;
        public const int SWP_DEFERERASE = 0x2000;
        public const int SWP_ASYNCWINDOWPOS = 0x4000;
    }

    public static class ShowWindowTypes
    {
        public const int SW_HIDE = 0;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_NORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_MAXIMIZE = 3;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOW = 5;
        public const int SW_MINIMIZE = 6;
        public const int SW_SHOWMINNOACTIVE = 7;
        public const int SW_SHOWNA = 8;
        public const int SW_RESTORE = 9;
        public const int SW_SHOWDEFAULT = 10;
        public const int SW_FORCEMINIMIZE = 11;
        public const int SW_MAX = 11;
    }

    public static class LayeredWindowAttributes
    {
        public const uint LWA_COLORKEY = 0x1;
        public const uint LWA_ALPHA = 0x2;
    }

    public enum SystemMetric
    {
        /// <summary>
        /// Nonzero if the meanings of the left and right mouse buttons are swapped; otherwise, 0.
        /// </summary>
        SM_SWAPBUTTON = 23,
        SM_XVIRTUALSCREEN = 76,
        SM_YVIRTUALSCREEN = 77,
        SM_CXVIRTUALSCREEN = 78,
        SM_CYVIRTUALSCREEN = 79
    }

    public enum InputType : uint
    {
        INPUT_MOUSE = 0,
        INPUT_KEYBOARD = 1,
        INPUT_HARDWARE = 2
    }

    [Flags]
    public enum MouseEventFlags : uint
    {
        MOUSEEVENTF_MOVE = 0x0001,
        MOUSEEVENTF_LEFTDOWN = 0x0002,
        MOUSEEVENTF_LEFTUP = 0x0004,
        MOUSEEVENTF_RIGHTDOWN = 0x0008,
        MOUSEEVENTF_RIGHTUP = 0x0010,
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,
        MOUSEEVENTF_MIDDLEUP = 0x0040,
        MOUSEEVENTF_XDOWN = 0x0080,
        MOUSEEVENTF_XUP = 0x0100,
        MOUSEEVENTF_WHEEL = 0x0800,
        MOUSEEVENTF_HWHEEL = 0x1000, // >= Win Vista only
        MOUSEEVENTF_MOVE_NOCOALESCE = 0x2000,
        MOUSEEVENTF_VIRTUALDESK = 0x4000,
        MOUSEEVENTF_ABSOLUTE = 0x8000
    }

    [Flags]
    public enum MouseEventDataXButtons : uint
    {
        NOTHING = 0x00000000,
        XBUTTON1 = 0x00000001,
        XBUTTON2 = 0x00000002
    }

    [Flags]
    public enum VkKeyScanModifiers : byte
    {
        NONE = 0,
        SHIFT = 0x01,
        CONTROL = 0x02,
        ALT = 0x04,
        Hankaku = 0x08,
        Reserved1 = 0x10,
        Reserved2 = 0x20
    }

    public enum VirtualKeyShort : ushort
    {
        /// <summary>
        /// Left mouse button
        /// </summary>
        LBUTTON = 0x01,

        /// <summary>
        /// Right mouse button
        /// </summary>
        RBUTTON = 0x02,

        /// <summary>
        /// Control-break processing
        /// </summary>
        CANCEL = 0x03,

        /// <summary>
        /// Middle mouse button (three-button mouse)
        /// </summary>
        MBUTTON = 0x04,

        /// <summary>
        /// Windows 2000/XP: X1 mouse button
        /// </summary>
        XBUTTON1 = 0x05,

        /// <summary>
        /// Windows 2000/XP: X2 mouse button
        /// </summary>
        XBUTTON2 = 0x06,

        /// <summary>
        /// BACKSPACE key
        /// </summary>
        BACK = 0x08,

        /// <summary>
        /// TAB key
        /// </summary>
        TAB = 0x09,

        /// <summary>
        /// CLEAR key
        /// </summary>
        CLEAR = 0x0C,

        /// <summary>
        /// ENTER key
        /// </summary>
        RETURN = 0x0D,

        /// <summary>
        /// SHIFT key
        /// </summary>
        SHIFT = 0x10,

        /// <summary>
        /// CTRL key
        /// </summary>
        CONTROL = 0x11,

        /// <summary>
        /// ALT key
        /// </summary>
        ALT = 0x12,

        /// <summary>
        /// PAUSE key
        /// </summary>
        PAUSE = 0x13,

        /// <summary>
        /// CAPS LOCK key
        /// </summary>
        CAPITAL = 0x14,

        /// <summary>
        /// Input Method Editor (IME) Kana mode
        /// </summary>
        KANA = 0x15,

        /// <summary>
        /// IME Hangul mode
        /// </summary>
        HANGUL = 0x15,

        /// <summary>
        /// IME Junja mode
        /// </summary>
        JUNJA = 0x17,

        /// <summary>
        /// IME final mode
        /// </summary>
        FINAL = 0x18,

        /// <summary>
        /// IME Hanja mode
        /// </summary>
        HANJA = 0x19,

        /// <summary>
        /// IME Kanji mode
        /// </summary>
        KANJI = 0x19,

        /// <summary>
        /// ESC key
        /// </summary>
        ESCAPE = 0x1B,

        /// <summary>
        /// IME convert
        /// </summary>
        CONVERT = 0x1C,

        /// <summary>
        /// IME nonconvert
        /// </summary>
        NONCONVERT = 0x1D,

        /// <summary>
        /// IME accept
        /// </summary>
        ACCEPT = 0x1E,

        /// <summary>
        /// IME mode change request
        /// </summary>
        MODECHANGE = 0x1F,

        /// <summary>
        /// SPACEBAR
        /// </summary>
        SPACE = 0x20,

        /// <summary>
        /// PAGE UP key
        /// </summary>
        PRIOR = 0x21,

        /// <summary>
        /// PAGE DOWN key
        /// </summary>
        NEXT = 0x22,

        /// <summary>
        /// END key
        /// </summary>
        END = 0x23,

        /// <summary>
        /// HOME key
        /// </summary>
        HOME = 0x24,

        /// <summary>
        /// LEFT ARROW key
        /// </summary>
        LEFT = 0x25,

        /// <summary>
        /// UP ARROW key
        /// </summary>
        UP = 0x26,

        /// <summary>
        /// RIGHT ARROW key
        /// </summary>
        RIGHT = 0x27,

        /// <summary>
        /// DOWN ARROW key
        /// </summary>
        DOWN = 0x28,

        /// <summary>
        /// SELECT key
        /// </summary>
        SELECT = 0x29,

        /// <summary>
        /// PRINT key
        /// </summary>
        PRINT = 0x2A,

        /// <summary>
        /// EXECUTE key
        /// </summary>
        EXECUTE = 0x2B,

        /// <summary>
        /// PRINT SCREEN key
        /// </summary>
        SNAPSHOT = 0x2C,

        /// <summary>
        /// INS key
        /// </summary>
        INSERT = 0x2D,

        /// <summary>
        /// DEL key
        /// </summary>
        DELETE = 0x2E,

        /// <summary>
        /// HELP key
        /// </summary>
        HELP = 0x2F,

        /// <summary>
        /// 0 key
        /// </summary>
        KEY_0 = 0x30,

        /// <summary>
        /// 1 key
        /// </summary>
        KEY_1 = 0x31,

        /// <summary>
        /// 2 key
        /// </summary>
        KEY_2 = 0x32,

        /// <summary>
        /// 3 key
        /// </summary>
        KEY_3 = 0x33,

        /// <summary>
        /// 4 key
        /// </summary>
        KEY_4 = 0x34,

        /// <summary>
        /// 5 key
        /// </summary>
        KEY_5 = 0x35,

        /// <summary>
        /// 6 key
        /// </summary>
        KEY_6 = 0x36,

        /// <summary>
        /// 7 key
        /// </summary>
        KEY_7 = 0x37,

        /// <summary>
        /// 8 key
        /// </summary>
        KEY_8 = 0x38,

        /// <summary>
        /// 9 key
        /// </summary>
        KEY_9 = 0x39,

        /// <summary>
        /// A key
        /// </summary>
        KEY_A = 0x41,

        /// <summary>
        /// B key
        /// </summary>
        KEY_B = 0x42,

        /// <summary>
        /// C key
        /// </summary>
        KEY_C = 0x43,

        /// <summary>
        /// D key
        /// </summary>
        KEY_D = 0x44,

        /// <summary>
        /// E key
        /// </summary>
        KEY_E = 0x45,

        /// <summary>
        /// F key
        /// </summary>
        KEY_F = 0x46,

        /// <summary>
        /// G key
        /// </summary>
        KEY_G = 0x47,

        /// <summary>
        /// H key
        /// </summary>
        KEY_H = 0x48,

        /// <summary>
        /// I key
        /// </summary>
        KEY_I = 0x49,

        /// <summary>
        /// J key
        /// </summary>
        KEY_J = 0x4A,

        /// <summary>
        /// K key
        /// </summary>
        KEY_K = 0x4B,

        /// <summary>
        /// L key
        /// </summary>
        KEY_L = 0x4C,

        /// <summary>
        /// M key
        /// </summary>
        KEY_M = 0x4D,

        /// <summary>
        /// N key
        /// </summary>
        KEY_N = 0x4E,

        /// <summary>
        /// O key
        /// </summary>
        KEY_O = 0x4F,

        /// <summary>
        /// P key
        /// </summary>
        KEY_P = 0x50,

        /// <summary>
        /// Q key
        /// </summary>
        KEY_Q = 0x51,

        /// <summary>
        /// R key
        /// </summary>
        KEY_R = 0x52,

        /// <summary>
        /// S key
        /// </summary>
        KEY_S = 0x53,

        /// <summary>
        /// T key
        /// </summary>
        KEY_T = 0x54,

        /// <summary>
        /// U key
        /// </summary>
        KEY_U = 0x55,

        /// <summary>
        /// V key
        /// </summary>
        KEY_V = 0x56,

        /// <summary>
        /// W key
        /// </summary>
        KEY_W = 0x57,

        /// <summary>
        /// X key
        /// </summary>
        KEY_X = 0x58,

        /// <summary>
        /// Y key
        /// </summary>
        KEY_Y = 0x59,

        /// <summary>
        /// Z key
        /// </summary>
        KEY_Z = 0x5A,

        /// <summary>
        /// Left Windows key (Microsoft Natural keyboard)
        /// </summary>
        LWIN = 0x5B,

        /// <summary>
        /// Right Windows key (Natural keyboard)
        /// </summary>
        RWIN = 0x5C,

        /// <summary>
        /// Applications key (Natural keyboard)
        /// </summary>
        APPS = 0x5D,

        /// <summary>
        /// Computer Sleep key
        /// </summary>
        SLEEP = 0x5F,

        /// <summary>
        /// Numeric keypad 0 key
        /// </summary>
        NUMPAD0 = 0x60,

        /// <summary>
        /// Numeric keypad 1 key
        /// </summary>
        NUMPAD1 = 0x61,

        /// <summary>
        /// Numeric keypad 2 key
        /// </summary>
        NUMPAD2 = 0x62,

        /// <summary>
        /// Numeric keypad 3 key
        /// </summary>
        NUMPAD3 = 0x63,

        /// <summary>
        /// Numeric keypad 4 key
        /// </summary>
        NUMPAD4 = 0x64,

        /// <summary>
        /// Numeric keypad 5 key
        /// </summary>
        NUMPAD5 = 0x65,

        /// <summary>
        /// Numeric keypad 6 key
        /// </summary>
        NUMPAD6 = 0x66,

        /// <summary>
        /// Numeric keypad 7 key
        /// </summary>
        NUMPAD7 = 0x67,

        /// <summary>
        /// Numeric keypad 8 key
        /// </summary>
        NUMPAD8 = 0x68,

        /// <summary>
        /// Numeric keypad 9 key
        /// </summary>
        NUMPAD9 = 0x69,

        /// <summary>
        /// Multiply key
        /// </summary>
        MULTIPLY = 0x6A,

        /// <summary>
        /// Add key
        /// </summary>
        ADD = 0x6B,

        /// <summary>
        /// Separator key
        /// </summary>
        SEPARATOR = 0x6C,

        /// <summary>
        /// Subtract key
        /// </summary>
        SUBTRACT = 0x6D,

        /// <summary>
        /// Decimal key
        /// </summary>
        DECIMAL = 0x6E,

        /// <summary>
        /// Divide key
        /// </summary>
        DIVIDE = 0x6F,

        /// <summary>
        /// F1 key
        /// </summary>
        F1 = 0x70,

        /// <summary>
        /// F2 key
        /// </summary>
        F2 = 0x71,

        /// <summary>
        /// F3 key
        /// </summary>
        F3 = 0x72,

        /// <summary>
        /// F4 key
        /// </summary>
        F4 = 0x73,

        /// <summary>
        /// F5 key
        /// </summary>
        F5 = 0x74,

        /// <summary>
        /// F6 key
        /// </summary>
        F6 = 0x75,

        /// <summary>
        /// F7 key
        /// </summary>
        F7 = 0x76,

        /// <summary>
        /// F8 key
        /// </summary>
        F8 = 0x77,

        /// <summary>
        /// F9 key
        /// </summary>
        F9 = 0x78,

        /// <summary>
        /// F10 key
        /// </summary>
        F10 = 0x79,

        /// <summary>
        /// F11 key
        /// </summary>
        F11 = 0x7A,

        /// <summary>
        /// F12 key
        /// </summary>
        F12 = 0x7B,

        /// <summary>
        /// F13 key
        /// </summary>
        F13 = 0x7C,

        /// <summary>
        /// F14 key
        /// </summary>
        F14 = 0x7D,

        /// <summary>
        /// F15 key
        /// </summary>
        F15 = 0x7E,

        /// <summary>
        /// F16 key
        /// </summary>
        F16 = 0x7F,

        /// <summary>
        /// F17 key
        /// </summary>
        F17 = 0x80,

        /// <summary>
        /// F18 key
        /// </summary>
        F18 = 0x81,

        /// <summary>
        /// F19 key
        /// </summary>
        F19 = 0x82,

        /// <summary>
        /// F20 key
        /// </summary>
        F20 = 0x83,

        /// <summary>
        /// F21 key
        /// </summary>
        F21 = 0x84,

        /// <summary>
        /// F22 key, (PPC only) Key used to lock device.
        /// </summary>
        F22 = 0x85,

        /// <summary>
        /// F23 key
        /// </summary>
        F23 = 0x86,

        /// <summary>
        /// F24 key
        /// </summary>
        F24 = 0x87,

        /// <summary>
        /// NUM LOCK key
        /// </summary>
        NUMLOCK = 0x90,

        /// <summary>
        /// SCROLL LOCK key
        /// </summary>
        SCROLL = 0x91,

        /// <summary>
        /// Left SHIFT key
        /// </summary>
        LSHIFT = 0xA0,

        /// <summary>
        /// Right SHIFT key
        /// </summary>
        RSHIFT = 0xA1,

        /// <summary>
        /// Left CONTROL key
        /// </summary>
        LCONTROL = 0xA2,

        /// <summary>
        /// Right CONTROL key
        /// </summary>
        RCONTROL = 0xA3,

        /// <summary>
        /// Left MENU key
        /// </summary>
        LMENU = 0xA4,

        /// <summary>
        /// Right MENU key
        /// </summary>
        RMENU = 0xA5,

        /// <summary>
        /// Windows 2000/XP: Browser Back key
        /// </summary>
        BROWSER_BACK = 0xA6,

        /// <summary>
        /// Windows 2000/XP: Browser Forward key
        /// </summary>
        BROWSER_FORWARD = 0xA7,

        /// <summary>
        /// Windows 2000/XP: Browser Refresh key
        /// </summary>
        BROWSER_REFRESH = 0xA8,

        /// <summary>
        /// Windows 2000/XP: Browser Stop key
        /// </summary>
        BROWSER_STOP = 0xA9,

        /// <summary>
        /// Windows 2000/XP: Browser Search key
        /// </summary>
        BROWSER_SEARCH = 0xAA,

        /// <summary>
        /// Windows 2000/XP: Browser Favorites key
        /// </summary>
        BROWSER_FAVORITES = 0xAB,

        /// <summary>
        /// Windows 2000/XP: Browser Start and Home key
        /// </summary>
        BROWSER_HOME = 0xAC,

        /// <summary>
        /// Windows 2000/XP: Volume Mute key
        /// </summary>
        VOLUME_MUTE = 0xAD,

        /// <summary>
        /// Windows 2000/XP: Volume Down key
        /// </summary>
        VOLUME_DOWN = 0xAE,

        /// <summary>
        /// Windows 2000/XP: Volume Up key
        /// </summary>
        VOLUME_UP = 0xAF,

        /// <summary>
        /// Windows 2000/XP: Next Track key
        /// </summary>
        MEDIA_NEXT_TRACK = 0xB0,

        /// <summary>
        /// Windows 2000/XP: Previous Track key
        /// </summary>
        MEDIA_PREV_TRACK = 0xB1,

        /// <summary>
        /// Windows 2000/XP: Stop Media key
        /// </summary>
        MEDIA_STOP = 0xB2,

        /// <summary>
        /// Windows 2000/XP: Play/Pause Media key
        /// </summary>
        MEDIA_PLAY_PAUSE = 0xB3,

        /// <summary>
        /// Windows 2000/XP: Start Mail key
        /// </summary>
        LAUNCH_MAIL = 0xB4,

        /// <summary>
        /// Windows 2000/XP: Select Media key
        /// </summary>
        LAUNCH_MEDIA_SELECT = 0xB5,

        /// <summary>
        /// Windows 2000/XP: Start Application 1 key
        /// </summary>
        LAUNCH_APP1 = 0xB6,

        /// <summary>
        /// Windows 2000/XP: Start Application 2 key
        /// </summary>
        LAUNCH_APP2 = 0xB7,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// </summary>
        OEM_1 = 0xBA,

        /// <summary>
        /// Windows 2000/XP: For any country/region, the '+' key
        /// </summary>
        OEM_PLUS = 0xBB,

        /// <summary>
        /// Windows 2000/XP: For any country/region, the ',' key
        /// </summary>
        OEM_COMMA = 0xBC,

        /// <summary>
        /// Windows 2000/XP: For any country/region, the '-' key
        /// </summary>
        OEM_MINUS = 0xBD,

        /// <summary>
        /// Windows 2000/XP: For any country/region, the '.' key
        /// </summary>
        OEM_PERIOD = 0xBE,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// </summary>
        OEM_2 = 0xBF,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// </summary>
        OEM_3 = 0xC0,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// </summary>
        OEM_4 = 0xDB,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// </summary>
        OEM_5 = 0xDC,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// </summary>
        OEM_6 = 0xDD,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// </summary>
        OEM_7 = 0xDE,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// </summary>
        OEM_8 = 0xDF,

        /// <summary>
        /// Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
        /// </summary>
        OEM_102 = 0xE2,

        /// <summary>
        /// Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
        /// </summary>
        PROCESSKEY = 0xE5,

        /// <summary>
        /// Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes.
        /// The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more
        /// information,
        /// see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
        /// </summary>
        PACKET = 0xE7,

        /// <summary>
        /// Attn key
        /// </summary>
        ATTN = 0xF6,

        /// <summary>
        /// CrSel key
        /// </summary>
        CRSEL = 0xF7,

        /// <summary>
        /// ExSel key
        /// </summary>
        EXSEL = 0xF8,

        /// <summary>
        /// Erase EOF key
        /// </summary>
        EREOF = 0xF9,

        /// <summary>
        /// Play key
        /// </summary>
        PLAY = 0xFA,

        /// <summary>
        /// Zoom key
        /// </summary>
        ZOOM = 0xFB,

        /// <summary>
        /// Reserved
        /// </summary>
        NONAME = 0xFC,

        /// <summary>
        /// PA1 key
        /// </summary>
        PA1 = 0xFD,

        /// <summary>
        /// Clear key
        /// </summary>
        OEM_CLEAR = 0xFE
    }

    /// <summary>
    /// These are the hardware keyboard codes
    /// </summary>
    public enum ScanCodeShort : ushort
    {
        ESCAPE = 0x01,
        KEY_1 = 0x02,
        KEY_2 = 0x03,
        KEY_3 = 0x04,
        KEY_4 = 0x05,
        KEY_5 = 0x06,
        KEY_6 = 0x07,
        KEY_7 = 0x08,
        KEY_8 = 0x09,
        KEY_9 = 0x0A,
        KEY_0 = 0x0B,
        OEM_MINUS = 0x0C,
        OEM_PLUS = 0x0D,
        BACK = 0x0E,
        TAB = 0x0F,
        KEY_Q = 0x10,
        KEY_W = 0x11,
        KEY_E = 0x12,
        KEY_R = 0x13,
        KEY_T = 0x14,
        KEY_Y = 0x15,
        KEY_U = 0x16,
        KEY_I = 0x17,
        KEY_O = 0x18,
        KEY_P = 0x19,
        OPENBRACKET = 0x1A,
        CLOSEBRACKET = 0x1B,
        RETURN = 0x1C,
        CONTROL = 0x1D,
        KEY_A = 0x1E,
        KEY_S = 0x1F,
        KEY_D = 0x20,
        KEY_F = 0x21,
        KEY_G = 0x22,
        KEY_H = 0x23,
        KEY_J = 0x24,
        KEY_K = 0x25,
        KEY_L = 0x26,
        SEMICOLON = 0x27,
        QUOTE = 0x28,
        TILDE = 0x29,
        SHIFT = 0x2A,
        PIPE = 0x2B,
        KEY_Z = 0x2C,
        KEY_X = 0x2D,
        KEY_C = 0x2E,
        KEY_V = 0x2F,
        KEY_B = 0x30,
        KEY_N = 0x31,
        KEY_M = 0x32,
        COMMA = 0x33,
        PERIOD = 0x34,
        DIVIDE = 0x35,
        RSHIFT = 0x36,
        MULTIPLY = 0x37,
        ALT = 0x38,
        SPACE = 0x39,
        CAPSLOCK = 0x3A,
        F1 = 0x3B,
        F2 = 0x3C,
        F3 = 0x3D,
        F4 = 0x3E,
        F5 = 0x3F,
        F6 = 0x40,
        F7 = 0x41,
        F8 = 0x42,
        F9 = 0x43,
        F10 = 0x44,
        NUMLOCK = 0x45,
        PAUSE = 0x46,
        NUMPAD7 = 0x47,
        NUMPAD8 = 0x48,
        NUMPAD9 = 0x49,
        SUBTRACT = 0x4A,
        NUMPAD4 = 0x4B,
        NUMPAD5 = 0x4C,
        NUMPAD6 = 0x4D,
        ADD = 0x4E,
        NUMPAD1 = 0x4F,
        NUMPAD2 = 0x50,
        NUMPAD3 = 0x51,
        NUMPAD0 = 0x52,
        DELETE = 0x53,
        SNAPSHOT = 0x54,
        OEM_102 = 0x56,
        F11 = 0x57,
        F12 = 0x58,
        LWIN = 0x5B,
        RWIN = 0x5C,
        WINMENU = 0x5D,
        POWER = 0x5E,
        SLEEP = 0x5F,
        ZOOM = 0x62,
        HELP = 0x63,
        F13 = 0x64,
        F14 = 0x65,
        F15 = 0x66,
        F16 = 0x67,
        F17 = 0x68,
        F18 = 0x69,
        F19 = 0x6A,
        F20 = 0x6B,
        F21 = 0x6C,
        F22 = 0x6D,
        F23 = 0x6E,
        F24 = 0x76
    }

    [Flags]
    public enum KeyEventFlags : uint
    {
        KEYEVENTF_KEYDOWN = 0x0000,
        KEYEVENTF_EXTENDEDKEY = 0x0001,
        KEYEVENTF_KEYUP = 0x0002,
        KEYEVENTF_UNICODE = 0x0004,
        KEYEVENTF_SCANCODE = 0x0008
    }

    [Flags]
    public enum SendMessageTimeoutFlags : uint
    {
        SMTO_NORMAL = 0x0,
        SMTO_BLOCK = 0x1,
        SMTO_ABORTIFHUNG = 0x2,
        SMTO_NOTIMEOUTIFNOTHUNG = 0x8,
        SMTO_ERRORONEXIT = 0x20
    }
}
