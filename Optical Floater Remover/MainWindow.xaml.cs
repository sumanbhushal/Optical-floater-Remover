using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Optical_Floater_Remover.controller;

namespace Optical_Floater_Remover
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
        readonly BaseController _floaterImagerController = new BaseController();
        public MainWindow()
        {
            InitializeComponent();
            ClearGirdData();
            notifyIcon.Icon = new System.Drawing.Icon("eyeland_logo.ico");
            notifyIcon.Visible = true;

            System.Windows.Forms.ContextMenu notifyContextMenu = new System.Windows.Forms.ContextMenu();
            notifyContextMenu.MenuItems.Add("Settings", new EventHandler(OpenSettings));
            notifyContextMenu.MenuItems.Add("Exit", new EventHandler(Exit));
            notifyIcon.ContextMenu = notifyContextMenu;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Get this window's handle
            IntPtr hwnd = new WindowInteropHelper(this).Handle;

            SystemTransparent.makeTransparent(hwnd);
        }

        private void ClearGirdData()
        {
            //MessageBox.Show(imgName + opacityValue); used
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    foreach (UIElement control in mainGrid.Children)
                    {
                        if (Grid.GetRow(control) == j && Grid.GetColumn(control) == i)
                        {
                            mainGrid.Children.Remove(control);
                            break;
                        }
                    }
                }
            }
            LoadDataInGrid();
        }

        private void LoadDataInGrid()
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    var floaterImage = _floaterImagerController.LoadAnimationImageFromMain();
                    //floaterImagerController.CombineRotationWithSkewAnimation(floaterImage);
                    //_floaterImagerController.RotationAnimation(floaterImage);
                    Grid.SetColumn(floaterImage, i);
                    Grid.SetRow(floaterImage, j);
                    mainGrid.Children.Add(floaterImage);
                }
            }
        }

        public void DisableNotificationIcon()
        {
            notifyIcon.Visible = false;
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenSettings(object sender, EventArgs e)
        {
            Setting openSetting = new Setting();
            openSetting.Show();
        }
    }
}
