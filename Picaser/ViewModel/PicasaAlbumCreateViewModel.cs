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
    public class PicasaAlbumCreateViewModel : PropertyChangedBase
    {
        readonly INavigationService _navigationService;
        readonly IPhotoService<PicasaAlbum, PicasaMediaGroup> _photoService;
        readonly IEventAggregator _eventAggregaror;

        public PicasaAlbumCreateViewModel(INavigationService navigationService,
                                          IPhotoService<PicasaAlbum, PicasaMediaGroup> photoService,
                                          IEventAggregator eventAggregaror)
        {
            _navigationService = navigationService;
            _photoService = photoService;
            _eventAggregaror = eventAggregaror;

            NewAlbum = new PicasaAlbum() { Access = "public" }; //TODO: bind access from UI
        }

        private PicasaAlbum _NewAlbum;
        public PicasaAlbum NewAlbum
        {
            get
            {
                return _NewAlbum;
            }
            set
            {
                _NewAlbum = value;
                NotifyOfPropertyChange(() => NewAlbum);
            }
        }

        public void CreateAlbum(PicasaAlbumCreateViewModel model)
        {
            //TODO: add error handler            
            _photoService.CreateAlbum(model.NewAlbum, (result) =>
            {
                if(_navigationService.CanGoBack)
                    _navigationService.GoBack();
            });            
        }

    }
}
