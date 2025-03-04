namespace GlobalHotkeys
{
    internal class TrayApplication : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public TrayApplication()
        {
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                ContextMenuStrip = new ContextMenuStrip()
            };
            trayIcon.ContextMenuStrip.Items.Add("Exit", null, Exit);
        }

        private void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                trayIcon.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
