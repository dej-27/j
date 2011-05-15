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
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.Linq;
using Picaser.Common;

namespace Phone.Api
{
    public class PhoneService : IPhoneService<PhoneAlbum>
    {
        public void GetAlbums(Action<List<PhoneAlbum>> result)
        {
            MediaLibrary lib = new MediaLibrary();
            var albums = (from p in lib.Pictures
                          group p by p.Album into album
                          orderby album.Key.Name
                          select new PhoneAlbum
                          {
                              Name = album.Key.Name,
                              Pictures = album.Key.Pictures.ToList()
            
                          });
            result(albums.ToList());            
        }
    }
}
