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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Picaser.Common
{
    public interface IPhotoService<ALBUM,PHOTO>
    {
        void GetAlbums(Action<List<ALBUM>> callback);
        void GetAlbumPhotos(string albumId, Action<List<PHOTO>> callback);

        void DeleteAlbum(string albumId, Action<string> callback);
        void CreateAlbum(ALBUM album, Action<string> callback);
        void UpdateAlbum(ALBUM album, Action<string> callback);

        void Login(string user, string password, Action<string> callback);
    }
}