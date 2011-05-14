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
using System.Windows.Interactivity;
using Microsoft.Phone.Controls;

namespace PhotoSharing.Actions
{
    public class NavigationAction : TriggerAction<FrameworkElement>
    {

        public string Uri { get; set; }
        public UriKind UriKind { get; set; }

        protected override void Invoke(object parameter)
        {
            PhoneApplicationFrame frame = App.Current.RootVisual as PhoneApplicationFrame;
            if (frame != null)
            {
                frame.Navigate(new Uri(this.Uri, this.UriKind));
            }            
        }
    }
}
