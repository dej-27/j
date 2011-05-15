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
using PhotoSharing.Model;
using System.Collections.ObjectModel;
using PhotoSharing.Data.Entities;
using GalaSoft.MvvmLight.Command;
using Microsoft.Phone.Controls;
using Coding4Fun.Phone.Controls;
using PhotoSharing.Helpers;
using System.Linq;
using System.Windows.Navigation;

namespace PhotoSharing.ViewModel
{
    public class AccountViewModel
    {
        AccountModel model = new AccountModel();

        public AccountViewModel()
        {
            Account = new Account();

            //Picasa.Api.PicasaService s = new Picasa.Api.PicasaService();

            //Data.AccountRepository repo = new Data.AccountRepository();
            //Data.Entities.Account account = repo.GetAllAccounts().First();

        }

        public ObservableCollection<Account> Accounts
        {
            get
            {
                return model.GetAllAccounts();
            }
        }

        public Account Account
        {
            get;
            set;
        }

        public ICommand NewAccountCommand
        {
            get
            {
                return new RelayCommand<Account>((a) =>
                {
                    model.AddAccount(a.User, a.Password);
                    Account = new Account();
                    //ViewHelper.Navigate(new Uri(UriHelper.ACCOUNT_LIST, UriKind.Relative));
                });
            }
        }

        public ICommand AccountSelected
        {
            get
            {
                return new RelayCommand<Account>((account) =>
                {
                    if (account != null)
                    {
                        //TODO: handle LOGIN error
                        Picasa.Api.PicasaService sevice = new Picasa.Api.PicasaService();
                        sevice.Login(account.User, account.Password, (result) =>
                        {
                            string url = String.Format("/View/Album/AlbumsList.xaml?account={0}", account.User);
                            ViewHelper.Navigate(new Uri(url, UriKind.Relative));
                        });
                    }
                });
            }
        }




    }
}
