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
using Picasa.Api;
using Caliburn.Micro;
using Picaser.Common;
using System.Linq;
using System.Collections.ObjectModel;
using Picaser.Helpers;


namespace Picaser.ViewModel
{
    public class PicasaAlbumListViewModel : PropertyChangedBase, IHandle<AppEvents.PicasaAlbumCreated>
    {
        readonly IPhotoService<PicasaAlbum, PicasaMediaGroup> _photoService;
        readonly INavigationService _navigationService;
        readonly IEventAggregator _eventAggregaror;

        public PicasaAlbumListViewModel(IPhotoService<PicasaAlbum, PicasaMediaGroup> photoService,
                                        INavigationService navigationService,
                                        IEventAggregator eventAggregaror)
        {
            _photoService = photoService;
            _navigationService = navigationService;
            _eventAggregaror = eventAggregaror;


            _eventAggregaror.Subscribe(this);

            UpdateViewModel();            
        }

        public void UpdateViewModel()
        {
            _photoService.GetAlbums((albums) =>
            {
                AlbumList = albums;
                NotifyOfPropertyChange(() => AlbumList);
            });
        }

        public PicasaAlbum SelectedAlbum { get; set; }
        public List<PicasaAlbum> AlbumList { get; set; }

        public void DeleteAlbum(PicasaAlbum album)
        {
            var message = String.Format("Are you sure want to delete \"{0}\"?", album.Title);
            var confirm = MessageBox.Show(message, "Confirmation", MessageBoxButton.OKCancel);


            if (confirm == MessageBoxResult.OK)
            {
                //TODO: handle error
                _photoService.DeleteAlbum(album.Id, (result) =>
                {
                    AlbumList = new List<PicasaAlbum>(AlbumList);
                    AlbumList.Remove(album);                   
                    NotifyOfPropertyChange(() => AlbumList);
                });
            }
        }

        public void OnSelectAlbum(PicasaAlbumListViewModel model)
        {
            PicasaAlbum album = model.SelectedAlbum;
            _navigationService.Navigate(UrlHelper.PicasaPhotoList(album.Id, album.Title));
        }
        
        /// <summary>
        /// Navigate to "Create New Album" View
        /// </summary>
        public void Navigation_PicasaAlbumCreateView()
        {
            _navigationService.Navigate( UrlHelper.PicasaAlbumCreate() );
        }

        /// <summary>
        /// New album event listener 
        /// </summary>
        /// <param name="message">New album event object</param>
        public void Handle(AppEvents.PicasaAlbumCreated message)
        {
            UpdateViewModel(); 
        }
    }
}
