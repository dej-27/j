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


namespace Picaser.ViewModel
{
    public class PicasaAlbumCreateViewModel : Screen
    {
        readonly INavigationService _navigationService;
        readonly IPhotoService<PicasaAlbum, PicasaMediaGroup> _photoService;

        public PicasaAlbum NewAlbum { get; set; }

        public PicasaAlbumCreateViewModel(INavigationService navigationService,
                                          IPhotoService<PicasaAlbum, PicasaMediaGroup> photoService)
        {
            _navigationService = navigationService;
            _photoService = photoService;

            NewAlbum = new PicasaAlbum() { Access = "public" }; //TODO: bind access from UI
        }       

        public void CreateAlbum(PicasaAlbumCreateViewModel model)
        {
            //TODO: add error handler            
            _photoService.CreateAlbum(model.NewAlbum, (result) =>
            {
                if (_navigationService.CanGoBack)
                    _navigationService.GoBack();
            });
        }

    }
}
