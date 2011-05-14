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
using PhotoSharing.Data;
using Picasa.Api;
using Picaser.Common;

namespace PhotoSharing.Model
{
    public class AlbumModel
    {  

        public void GetAllPicasaAlbums(PicasaService.AlbumsResultCallback callback)
        {
            PicasaService service = new PicasaService();
            service.GetPicasaAlbums(callback);
        }



        //TODO add callback status
        public void CreatePicasaAlbum(PicasaAlbum album, PicasaService.StringResultCallback callback)
        {
            PicasaService service = new PicasaService();
            service.CreateAlbum(album, callback);
        }


    }
}
