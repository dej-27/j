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

namespace PhotoSharing.ViewModel
{
    public class PhotoPreviewViewModel : PhotosListViewModel
    {
        Random rnd = new Random();

        public string ContentUrl
        {
            get
            {                
                return Items[rnd.Next(0, Items.Count - 1)].ContentUrl;
            }
        }
    }
}
