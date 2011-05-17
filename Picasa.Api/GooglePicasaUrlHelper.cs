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

namespace Picasa.Api
{
    public class GooglePicasaUrlHelper
    {
        public static Uri UploadPhoto(string account, string albumId)
        {
            return new Uri(String.Format("https://picasaweb.google.com/data/feed/api/user/{0}/albumid/{1}", account, albumId));
        }
    }
}
