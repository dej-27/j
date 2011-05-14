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
using Microsoft.Phone.Controls;

namespace PhotoSharing.Helpers
{
    public class ViewHelper
    {
        public static PhoneApplicationFrame CurrentFrame
        {
            get
            {
                PhoneApplicationFrame currentFrame = App.Current.RootVisual as PhoneApplicationFrame;
                return currentFrame;
            }
        }


        public static void Navigate(Uri uri)
        {            
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                    PhoneApplicationFrame currentFrame = App.Current.RootVisual as PhoneApplicationFrame;
                    if (currentFrame != null)
                    {
                        currentFrame.Navigate(uri);
                    }
            });

        }
    }
}
