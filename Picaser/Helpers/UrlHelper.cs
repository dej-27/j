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

namespace Picaser.Helpers
{
    public class UrlHelper
    {


        public static Uri AccountList()
        {
            return new Uri("/View/AccountListView.xaml", UriKind.Relative);
        }

        public static Uri AccountCreate()
        {
            return new Uri("/View/AccountCreateView.xaml", UriKind.Relative);
        }

        public static Uri PicasaAlbumList()
        {
            return new Uri("/View/PicasaAlbumListView.xaml", UriKind.Relative);
        }

        public static Uri PicasaAlbumCreate()
        {
            return new Uri("/View/PicasaAlbumCreateView.xaml", UriKind.Relative);
        }

        public static Uri PicasaAlbumUpdate()
        {
            return new Uri("/View/PicasaAlbumUpdateView.xaml", UriKind.Relative);            
        }


        public static Uri PicasaPhotoList(string albumId, string albumTitle)
        {
            string url = String.Format("/View/PicasaPhotoListView.xaml?AlbumId={0}&AlbumTitle={1}", albumId, albumTitle);
            return new Uri(url, UriKind.Relative);
        }


        public static Uri PhonePhotoList()
        {
            return new Uri("/View/PhonePhotoListView.xaml", UriKind.Relative);   
        }
    }
}
