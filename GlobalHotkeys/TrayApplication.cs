using System.Runtime.InteropServices;

namespace GlobalHotkeys
{
    internal class TrayApplication : ApplicationContext
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private NotifyIcon trayIcon;
        private IntPtr handle;
        private Thread messageLoopThread;

        private static IntPtr lastFocusedWindow;

        public TrayApplication()
        {
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                ContextMenuStrip = new ContextMenuStrip()
            };
            trayIcon.ContextMenuStrip.Items.Add("Exit", null, Exit);

            StartMessageLoop();
        }

        private void StartMessageLoop()
        {
            messageLoopThread = new Thread(() =>
            {
                using (Form hiddenForm = new Form())
                {
                    handle = hiddenForm.Handle; // Creates a hidden window to register the hotkey
                    bool registered = RegisterHotKey(handle, Globals.HOTKEY_ID_1, Globals.MOD_CONTROL_SHIFT, Globals.VK_U);
                    if (!registered)
                    {
                        MessageBox.Show("Failed to register simple hotkey. It may be in use by another application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    registered = RegisterHotKey(handle, Globals.HOTKEY_ID_2, Globals.MOD_CONTROL_SHIFT, Globals.VK_I);
                    if (!registered)
                    {
                        MessageBox.Show("Failed to register complex hotkey. It may be in use by another application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Application.AddMessageFilter(new HotkeyMessageFilter(ShowSimpleSelectionWindow, ShowComplexSelectionWindow));
                    Application.Run();
                }
            })
            {
                IsBackground = true
            };
            messageLoopThread.SetApartmentState(ApartmentState.STA);
            messageLoopThread.Start();
        }

        private void ShowSimpleSelectionWindow()
        {
            lastFocusedWindow = GetForegroundWindow(); // Save the currently focused window
            var popup = new SimpleHotkeySelectionForm(lastFocusedWindow);
            popup.Show();

            // Ensure the popup is always in the foreground
            IntPtr popupHandle = popup.Handle;
            ShowWindow(popupHandle, Globals.SW_RESTORE);
            SetForegroundWindow(popupHandle);
            SetWindowPos(popupHandle, Globals.HWND_TOPMOST, 0, 0, 0, 0, Globals.SWP_NOMOVE | Globals.SWP_NOSIZE | Globals.SWP_SHOWWINDOW);
        }

        private void ShowComplexSelectionWindow()
        {
            lastFocusedWindow = GetForegroundWindow(); // Save the currently focused window
            var popup = new ComplexHotkeySelectionForm(lastFocusedWindow);
            popup.Show();

            // Ensure the popup is always in the foreground
            IntPtr popupHandle = popup.Handle;
            ShowWindow(popupHandle, Globals.SW_RESTORE);
            SetForegroundWindow(popupHandle);
            SetWindowPos(popupHandle, Globals.HWND_TOPMOST, 0, 0, 0, 0, Globals.SWP_NOMOVE | Globals.SWP_NOSIZE | Globals.SWP_SHOWWINDOW);
        }

        private void Exit(object sender, EventArgs e)
        {
            UnregisterHotKey(handle, Globals.HOTKEY_ID_1);
            UnregisterHotKey(handle, Globals.HOTKEY_ID_2);
            trayIcon.Visible = false;
            Application.Exit();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnregisterHotKey(handle, Globals.HOTKEY_ID_1);
                UnregisterHotKey(handle, Globals.HOTKEY_ID_2);
                trayIcon.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
