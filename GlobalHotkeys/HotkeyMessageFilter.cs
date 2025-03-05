namespace GlobalHotkeys
{
    internal class HotkeyMessageFilter(Action onSimpleHotkeyPressed, Action onComplexHotkeyPressed) : IMessageFilter
    {
        private readonly Action _onSimpleHotkeyPressed = onSimpleHotkeyPressed;
        private readonly Action _onComplexHotkeyPressed = onComplexHotkeyPressed;

        public bool PreFilterMessage(ref Message m)
        {
            int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                if (m.WParam.ToInt32() == Globals.HOTKEY_ID_1)
                {
                    _onSimpleHotkeyPressed?.Invoke();
                    return true;
                }
                else if (m.WParam.ToInt32() == Globals.HOTKEY_ID_2)
                {
                    _onComplexHotkeyPressed?.Invoke();
                    return true;
                }
            }
            return false;
        }
    }
}
