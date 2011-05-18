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
using System.Collections.Generic;
using Caliburn.Micro;
using Microsoft.Xna.Framework.Media;

namespace Picaser.ViewModel
{
    public class PhonePhotoListViewModel : Screen
    {
        readonly IPhoneService<PhoneAlbum> _phoneService;
        readonly IPhotoService<PicasaAlbum, PicasaMediaGroup> _photoService;

        public List<PhoneAlbum> AlbumList { get; set; }
        public Picture SelectedPicture { get; set; }
        public string AlbumId { get; set; }

        public PhonePhotoListViewModel(IPhoneService<PhoneAlbum> phoneService,
                                       IPhotoService<PicasaAlbum, PicasaMediaGroup> photoService)
        {
            _phoneService = phoneService;
            _photoService = photoService;
        }
        
        protected override void OnActivate()
        {
            base.OnActivate();

            //get phone photos
            _phoneService.GetAlbums((albums) =>
            {
                AlbumList = albums;
                NotifyOfPropertyChange(() => AlbumList);
            });
        }

        public void OnSelectPhoto(Picture picture)
        {
            if (picture != null)
            {
                _photoService.UploadPhoto(picture.Name, picture.GetImage(), AlbumId, (result) =>
                {
                    MessageBox.Show(result == 200 ? "Upload completed!" : "Upload Error");
                });
            }
        }
    }
}
