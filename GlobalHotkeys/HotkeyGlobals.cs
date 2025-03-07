namespace GlobalHotkeys
{
    public class HotkeyGlobals
    {
        public static int HOTKEY_ID_1 = 9000;
        public static int HOTKEY_ID_2 = 9001;
        public static int HOTKEY_ID_3 = 9002;
        public static int HOTKEY_ID_4 = 9003;

        public static int MOD_CONTROL_SHIFT = 0x0002 | 0x0004; // Ctrl + Shift
        public static int MOD_CONTROL_ALT = 0x0002 | 0x0001; // Ctrl + Alt
        public static int VK_A = 0x41; // 'A' key
        public static int VK_I = 0x49; // 'I' key
        public static int VK_S = 0x53; // 'S' key
        public static int VK_U = 0x55; // 'U' key

        public const int SW_RESTORE = 9;
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public const uint SWP_NOMOVE = 0x0002;
        public const uint SWP_NOSIZE = 0x0001;
        public const uint SWP_SHOWWINDOW = 0x0040;
    }
}
