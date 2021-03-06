﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;

namespace WindowsPhoneApplication1.Converters
{
    public class TestConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            BitmapImage bitmapImage = new BitmapImage();

            if (value is Picture)
            {
                Picture pic = value as Picture;
                bitmapImage.SetSource(pic.GetThumbnail());
            } 
            return bitmapImage;



        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
