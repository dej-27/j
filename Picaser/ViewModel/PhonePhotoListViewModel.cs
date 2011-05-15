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

namespace Picaser.ViewModel
{
    public class PhonePhotoListViewModel : Screen
    {
        readonly IPhoneService<PhoneAlbum> _phoneService;
        public List<PhoneAlbum> AlbumList { get; set; }

        public PhonePhotoListViewModel(IPhoneService<PhoneAlbum> phoneService)
        {
            _phoneService = phoneService;
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
    }
}
