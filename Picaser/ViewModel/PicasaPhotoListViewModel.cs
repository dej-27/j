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
using Picaser.Common;
using Caliburn.Micro;
using System.Collections.Generic;
using Picaser.Helpers;

namespace Picaser.ViewModel
{
    public class PicasaPhotoListViewModel : Screen
    {
        readonly IPhotoService<PicasaAlbum, PicasaMediaGroup> _photoService;
        readonly INavigationService _navigationService;

        public PicasaPhotoListViewModel(IPhotoService<PicasaAlbum, PicasaMediaGroup> photoService,
                                        INavigationService navigationService)
        {
            _photoService = photoService;
            _navigationService = navigationService;
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            //set album title
            NotifyOfPropertyChange(() => AlbumTitle);
            
            //load photos by albumId
            _photoService.GetAlbumPhotos(AlbumId, (photos) =>
            {
                PhotoList = photos;
                NotifyOfPropertyChange(() => PhotoList);
            });

        }

        public void UploadPhoto()
        {
            _navigationService.Navigate(UrlHelper.PhonePhotoList(AlbumId));
        }

        public string AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public List<PicasaMediaGroup> PhotoList { get; set; }

    }
}
