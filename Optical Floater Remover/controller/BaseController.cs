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

namespace Optical_Floater_Remover.controller
{
    public class BaseController
    {
        private string ImageName = "Turbulence_PNG.png";
        private double ImageOpacity = Convert.ToDouble(0.21);

        public string GenerateImageSourceUri()
        {
            return "pack://application:,,,/img/" + ImageName;
        }

        public void RotationAnimation(Image imageForAnimation)
        {
            DoubleAnimation da = new DoubleAnimation
            {
                From = 0,
                To = 5,
                AutoReverse = true,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                RepeatBehavior = RepeatBehavior.Forever
            };
            RotateTransform rt = new RotateTransform();
            imageForAnimation.RenderTransform = rt;
            //imageForAnimation.RenderTransformOrigin = new Point(0.05, 0.05);
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
        }
        public Image LoadAnimationImageWithOpacity()
        {
            Image imageToReturn = new Image();
            imageToReturn.Opacity = ImageOpacity;
            imageToReturn.Stretch = Stretch.UniformToFill;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(GenerateImageSourceUri());
            image.EndInit();
            //ImageBehavior.SetAnimatedSource(imageToReturn, image);
            imageToReturn.Source = image;
            return imageToReturn;
        }
    }


}
