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
using Optical_Floater_Remover.Properties;

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
            var ImgName = "";

            foreach (object obj in LboxItem.SelectedItems)
            {

                ImgName = (obj as FloaterImage).ImageName;
            }
            
            setImageName = ImgName;
            ClearGirdDataWithOpacity(setImageName, setNewOpacityValue);
        }

        private void ClearGirdDataWithOpacity(string imgName, double opacityValue)
        {
            //MessageBox.Show(imgName + opacityValue); used
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    foreach (UIElement control in Gride1X1.Children)
                    {
                        if (Grid.GetRow(control) == j && Grid.GetColumn(control) == i)
                        {
                            Gride1X1.Children.Remove(control);
                            break;
                        }
                    }
                }
            }
            LoadSelectedAnimatedImageWithImageNameAndOpacityValue(imgName, opacityValue);
        }

        private void LoadSelectedAnimatedImageWithImageNameAndOpacityValue(string imgName, double opacityValue)
        {
            // MessageBox.Show(imgName + " " + opacityValue); Used
            
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {

                    var floaterImage = _floaterImagerController.LoadAnimationImageWithOpacity(imgName, opacityValue);
                    //_floaterImagerController.RotationAnimation(floaterImage);
                    Grid.SetColumn(floaterImage, i);
                    Grid.SetRow(floaterImage, j);
                    Gride1X1.Children.Add(floaterImage);

                }
            }
        }
        
        private void opacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // ... Get Slider reference.
            var slider = sender as Slider;
            // ... Get Value.
            if (slider != null)
            {
                double OpacityValue = slider.Value;
                string new_opacity_value = OpacityValue.ToString("0.00");
                setNewOpacityValue = OpacityValue;
                if (setImageName == null)
                {
                    //setImageName = "blackdots.gif";
                    setImageName = Settings.Default["ImageName"].ToString();
                    slider.Value = Convert.ToDouble(Settings.Default["Opacity"].ToString());
                    ClearGirdDataWithOpacity(setImageName, setNewOpacityValue);
                }
                else
                {
                    ClearGirdDataWithOpacity(setImageName, setNewOpacityValue);
                }
            }
        }

        private void SetImageAndOpacityToScreen(object sender, RoutedEventArgs e)
        {
            Settings.Default["ImageName"] = setImageName;
            Settings.Default["Opacity"] = setNewOpacityValue;
            Settings.Default.Save();

            //GifAnimation ani = new GifAnimation();
            //ani.Show();
            bool isWindowOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is MainWindow)
                {
                    isWindowOpen = true;
                    w.Close();
                    MainWindow newwindow = new MainWindow();
                    newwindow.Show();
                    //w.Activate();
                }
            }

            if (!isWindowOpen)
            {
                MainWindow newwindow = new MainWindow();
                newwindow.Show();
            }
        }
    }
}
