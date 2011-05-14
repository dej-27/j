using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PhotoSharing.Model;
using System.Linq;
using System.Windows.Media.Imaging;

namespace PhotoSharing.ViewModel
{
    public class PhoneViewModel
    {
        public ImageSource Picture {
            get
            {
                PhoneModel model = new PhoneModel();

                var image = new BitmapImage();
                image.SetSource(model.GetAllPictures().First().GetImage());
                return image;
            }
        }
    }
}
