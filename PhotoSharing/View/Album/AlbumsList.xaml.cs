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
using PhotoSharing.ViewModel;
using PhotoSharing.Helpers;

namespace PhotoSharing.View.Album
{
    public partial class AlbumsList : PhoneApplicationPage
    {
        public AlbumsList()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //string account = NavigationContext.QueryString["account"];
            AlbumViewModel viewModel = new AlbumViewModel();
            this.DataContext = viewModel;
        }

        private void NewAlbum(object sender, EventArgs e)
        {
            ViewHelper.Navigate(new Uri("/View/Album/CreateAlbum.xaml", UriKind.Relative));
        }

    }
}