namespace GlobalHotkeys
{
    internal class Globals
    {
        public static int HOTKEY_ID = 9000;

        public static int MOD_CONTROL_SHIFT = 0x0002 | 0x0004; // Ctrl + Shift
        public static int VK_U = 0x55; // 'U' key

        public const int SW_RESTORE = 9;
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public const uint SWP_NOMOVE = 0x0002;
        public const uint SWP_NOSIZE = 0x0001;
        public const uint SWP_SHOWWINDOW = 0x0040;
    }
}
