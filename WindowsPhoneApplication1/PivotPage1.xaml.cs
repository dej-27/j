using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;

namespace WindowsPhoneApplication1
{
    public partial class PivotPage1 : PhoneApplicationPage
    {
        public PivotPage1()
        {
            InitializeComponent();

            MediaLibrary lib = new MediaLibrary();

            var groups = (from p in lib.Pictures
                          group p by p.Album into album
                          orderby album.Key.Name
                          select new PhoneAlbum
                          {
                              Name = album.Key.Name,
                              Pictures = album.Key.Pictures.ToList()
                          });
            pivot.ItemsSource = groups.First().Pictures;
            

        }
    }
}