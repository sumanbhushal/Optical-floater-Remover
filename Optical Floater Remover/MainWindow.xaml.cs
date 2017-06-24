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
        readonly BaseController _floaterImagerController = new BaseController();
        public MainWindow()
        {
            InitializeComponent();
            LoadImageToGrid();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Get this window's handle
            IntPtr hwnd = new WindowInteropHelper(this).Handle;

            SystemTransparent.makeTransparent(hwnd);
        }

        public void LoadImageToGrid()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    var floaterImage = _floaterImagerController.LoadAnimationImageWithOpacity();
                    //floaterImagerController.CombineRotationWithSkewAnimation(floaterImage);
                    _floaterImagerController.RotationAnimation(floaterImage);
                    Grid.SetColumn(floaterImage, i);
                    Grid.SetRow(floaterImage, j);
                    mainGrid.Children.Add(floaterImage);
                }
            }
        }
    }
}
