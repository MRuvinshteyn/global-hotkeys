namespace GlobalHotkeys
{
    internal class HotkeyMessageFilter : IMessageFilter
    {
        private readonly Action _onHotkeyPressed;
        public HotkeyMessageFilter(Action onHotkeyPressed) => _onHotkeyPressed = onHotkeyPressed;

        public bool PreFilterMessage(ref Message m)
        {
            int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == Globals.HOTKEY_ID)
            {
                _onHotkeyPressed?.Invoke();
                return true;
            }
            return false;
        }
    }
}
