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
    public class PicasaAlbumListViewModel : Screen
    {
        readonly IPhotoService<PicasaAlbum, PicasaMediaGroup> _photoService;
        readonly INavigationService _navigationService;       

        public PicasaAlbum SelectedAlbum { get; set; }
        public List<PicasaAlbum> AlbumList { get; set; }

        public PicasaAlbumListViewModel(IPhotoService<PicasaAlbum, PicasaMediaGroup> photoService,
                                        INavigationService navigationService)
        {
            _photoService = photoService;
            _navigationService = navigationService;                      
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            //Load picasa albums
            _photoService.GetAlbums((albums) =>
            {
                AlbumList = albums;
                NotifyOfPropertyChange(() => AlbumList);
            });
        }        

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
            if (model.SelectedAlbum != null)
            {
                PicasaAlbum album = model.SelectedAlbum;
                _navigationService.Navigate(UrlHelper.PicasaPhotoList(album.Id, album.Title));
            }
        }
        
        /// <summary>
        /// Navigate to "Create New Album" View
        /// </summary>
        public void Navigation_PicasaAlbumCreateView()
        {
            _navigationService.Navigate( UrlHelper.PicasaAlbumCreate() );
        }



        
    }
}
