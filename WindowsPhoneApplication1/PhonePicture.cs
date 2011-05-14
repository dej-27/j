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
using System.Windows.Media.Imaging;

namespace WindowsPhoneApplication1
{
    public class PhonePicture
    {
        public string Title { get; set; }
        public BitmapImage Image { get; set; }
        public BitmapImage Thumbnail { get; set; }
    }
}
