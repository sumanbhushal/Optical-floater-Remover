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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Optical_Floater_Remover.controller;
using Optical_Floater_Remover.model;

namespace Optical_Floater_Remover
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        private readonly List<FloaterImage> fImages = new List<FloaterImage>();
        private string setImageName;
        private double setNewOpacityValue;
        private readonly BaseController _floaterImagerController = new BaseController();
        public Setting()
        {
            InitializeComponent();
            PopulateListViewWithImage();
        }

        private void PopulateListViewWithImage()
        {
            fImages.Add(new FloaterImage() { ImageName = "Turbulence-GIF.gif", ImageSourceLocation = "pack://application:,,,/img/Turbulence-GIF-small.gif" });
            fImages.Add(new FloaterImage() { ImageName = "Turbulence-GIF.gif", ImageSourceLocation = "pack://application:,,,/img/Turbulence-GIF-small.gif" });
            fImages.Add(new FloaterImage() { ImageName = "Turbulence-GIF.gif", ImageSourceLocation = "pack://application:,,,/img/Turbulence-GIF-small.gif" });
            fImages.Add(new FloaterImage() { ImageName = "Turbulence-GIF.gif", ImageSourceLocation = "pack://application:,,,/img/Turbulence-GIF-small.gif" });
            //fImages.Add(new FloaterImage() { ImageName = "black_dots.png", ImageSourceLocation = "pack://application:,,,/Include/black_dots.png" });
            LboxItem.ItemsSource = fImages;
        }
        private void LboxItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
