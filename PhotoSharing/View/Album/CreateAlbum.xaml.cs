using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Picasa.Api;
using PhotoSharing.ViewModel;

namespace PhotoSharing.View.Album
{
    public partial class CreateAlbum : PhoneApplicationPage
    {
        public CreateAlbum()
        {
            InitializeComponent();            
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.DataContext = new AlbumViewModel();

            
        }
    }
}