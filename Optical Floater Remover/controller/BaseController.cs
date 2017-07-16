using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Optical_Floater_Remover.Properties;
using WpfAnimatedGif;

namespace Optical_Floater_Remover.controller
{
    public class BaseController
    {
        private string ImageName = Settings.Default["ImageName"].ToString();
        private double ImageOpacity = Convert.ToDouble(Settings.Default["Opacity"].ToString());

        public string GenerateImageSourceUri()
        {
            return "pack://application:,,,/img/" + ImageName;
        }

        public string GenerateImageSourceUri(string imgName)
        {
            return "pack://application:,,,/img/" + imgName;
        }

        public Image LoadAnimationImageWithOpacity(string imageName, double opacityValue)
        {
            Image imageToReturn = new Image();
            imageToReturn.Opacity = opacityValue;
            imageToReturn.Stretch = Stretch.UniformToFill;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(GenerateImageSourceUri(imageName));
            image.EndInit();
            ImageBehavior.SetAnimatedSource(imageToReturn, image);
            return imageToReturn;
        }
        
        public Image LoadAnimationImageFromMain()
        {
            Image imageToReturn = new Image();
            imageToReturn.Opacity = ImageOpacity;
            imageToReturn.Stretch = Stretch.UniformToFill;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(GenerateImageSourceUri());
            image.EndInit();
            ImageBehavior.SetAnimatedSource(imageToReturn, image);

            return imageToReturn;
        }
        
    }
    
}
