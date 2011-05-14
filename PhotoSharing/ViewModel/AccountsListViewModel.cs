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
using System.Collections.ObjectModel;
using PhotoSharing.Model;
using Microsoft.Phone.Controls;
using Microsoft.Expression.Interactivity.Core;
using PhotoSharing.Communications;
using Phone.Api;
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;
using System.Linq;

namespace PhotoSharing.ViewModel
{

    public class AccountsListViewModel : ObservableCollection<AccountModel>
    {
        public AccountsListViewModel()
        {
           
            //Microsoft.Phone.Shell.ApplicationBarMenuItem s;
            //s.Click += new EventHandler(s_Click);

            //NewAccount2 = new ActionCommand(() => {
            //    (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/View/Account/AddAccount.xaml", UriKind.Relative));
            //});

            NewAccount2 = new DelegateCommand((o) =>
            {

            }, (o) => { return true; });
        }

        public string MyProperty2 { get { return "HELLO!"; } }

        public BitmapImage MyProperty
        {
            get
            {
                //var phoneService = new PhoneService();
                //var ppp = phoneService.GetAllPictures();

                //var image = new BitmapImage();
               
                //image.SetSource(ppp.First().GetImage());
                //var img = new BitmapImage();
                //img.SetSource(ppp[0].GetImage());

                BitmapImage bi3 = new BitmapImage();
                //bi3.SetSource(ppp.First().GetImage());
                return bi3;
            }
        }


        public void NewAccount(object sender, EventArgs e)
        {
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/View/Account/AddAccount.xaml", UriKind.Relative));
        }


        public ICommand NewAccount2 { get; set; }


        //public void NewAccount(object sender, EventArgs e)
        //{
        //    (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/View/Account/AddAccount.xaml", UriKind.Relative));
        //}
    }

}
