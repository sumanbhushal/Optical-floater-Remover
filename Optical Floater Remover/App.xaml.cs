using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Optical_Floater_Remover
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();

        public App()
        {
            notifyIcon.Icon = new System.Drawing.Icon("eyeland_logo.ico");
            notifyIcon.Visible = true;

            System.Windows.Forms.ContextMenu notifyContextMenu = new System.Windows.Forms.ContextMenu();
            notifyContextMenu.MenuItems.Add("Settings", new EventHandler(OpenSettings));
            notifyContextMenu.MenuItems.Add("Exit", new EventHandler(Exit));
            notifyIcon.ContextMenu = notifyContextMenu;
        }
        private void Exit(object sender, EventArgs e)
        {
            Shutdown();
        }

        private void OpenSettings(object sender, EventArgs e)
        {
            Setting openSetting = new Setting();
            openSetting.Show();
        }
    }
}
