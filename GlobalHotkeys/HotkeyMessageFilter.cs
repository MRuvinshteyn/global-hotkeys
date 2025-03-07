namespace GlobalHotkeys
{
    public class HotkeyMessageFilter(Action onUsernameHotkeyPressed, Action onPasswordHotkeyPressed,
        Action onSimpleHotkeyPressed, Action onComplexHotkeyPressed) : IMessageFilter
    {
        private readonly Action _onUsernameHotkeyPressed = onUsernameHotkeyPressed;
        private readonly Action _onPasswordHotkeyPressed = onPasswordHotkeyPressed;
        private readonly Action _onSimpleHotkeyPressed = onSimpleHotkeyPressed;
        private readonly Action _onComplexHotkeyPressed = onComplexHotkeyPressed;

        public bool PreFilterMessage(ref Message m)
        {
            int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                if (m.WParam.ToInt32() == HotkeyGlobals.HOTKEY_ID_1)
                {
                    _onUsernameHotkeyPressed?.Invoke();
                    return true;
                }
                else if (m.WParam.ToInt32() == HotkeyGlobals.HOTKEY_ID_2)
                {
                    _onPasswordHotkeyPressed?.Invoke();
                    return true;
                }
                else if (m.WParam.ToInt32() == HotkeyGlobals.HOTKEY_ID_3)
                {
                    _onSimpleHotkeyPressed?.Invoke();
                    return true;
                }
                else if (m.WParam.ToInt32() == HotkeyGlobals.HOTKEY_ID_4)
                {
                    _onComplexHotkeyPressed?.Invoke();
                    return true;
                }
            }
            return false;
        }
    }
}
