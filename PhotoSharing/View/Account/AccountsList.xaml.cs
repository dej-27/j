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
using System.IO;
using System.Collections.ObjectModel;
using PhotoSharing.Model;
using PhotoSharing.ViewModel;

namespace PhotoSharing.Views.Account
{
    public partial class AccountsList : PhoneApplicationPage
    {
        public AccountsList()
        {
            InitializeComponent();

           

            //Model.AccountModel account = (App.Current.Resources["AccountViewModel"] as ObservableCollection<AccountModel>).First();

            //service.Login(account.Account, account.Password, (result) => 
            //{


            //    service.GetAlbums(account.Account, (albums) => 
            //    {

            //        Dispatcher.BeginInvoke(() =>
            //        {

            //        });

            //    }); 


            //});



            //service.GetAlbumPhotos("deslocator", "5566205741173550465", (result) =>
            //{
            //    Dispatcher.BeginInvoke(() =>
            //    {
            //        //ContentPanel.ItemsSource = result;
            //    });
            //});
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);


            AccountViewModel viewModel = new AccountViewModel();
            this.DataContext = viewModel;


        }

        public void NewAccount(object sender, EventArgs e)
        {
            //TODO: Use ViewHelper
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/View/Account/AddAccount.xaml", UriKind.Relative));
        }

        //public void GoToAlbums(object sender, RoutedEventArgs e)
        //{
        //    var vm = DataContext as AccountsListViewModel;
        //    if (vm != null)
        //    {
        //        vm.NewAccount(sender, e);
        //    }
        //}

        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{

        //}       
    }
}