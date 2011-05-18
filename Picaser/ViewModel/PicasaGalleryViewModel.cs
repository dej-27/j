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
using Caliburn.Micro;
using Picaser.Common;
using System.Collections.Generic;

namespace Picaser.ViewModel
{
    public class PicasaGalleryViewModel : Screen
    {
        readonly IPhotoService<PicasaAlbum, PicasaMediaGroup> _photoService;
        readonly INavigationService _navigationService;
        public int PhotoIndex { get; set; }
        public string AlbumId { get; set; }
        public List<PicasaMediaGroup> PicturesList { get; set; }

        public PicasaGalleryViewModel(IPhotoService<PicasaAlbum, PicasaMediaGroup> photoService,
                                      INavigationService navigationService)
        {
            _photoService = photoService;
            _navigationService = navigationService;
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            _photoService.GetAlbumPhotos(AlbumId, (pictures) =>
            {
                PicturesList = pictures;
                NotifyOfPropertyChange(() => PhotoIndex);
                NotifyOfPropertyChange(() => PicturesList);
            });

        }
    }
}
