﻿using System;
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
using Caliburn.Micro;
using Picaser.Common;
using Picasa.Api;
using Picaser.Helpers;

namespace Picaser.ViewModel
{
    public class AccountListViewModel : Screen
    {
        readonly IAccountRepository _accountRepository;
        readonly INavigationService _navigationService;
        readonly IPhotoService<PicasaAlbum, PicasaMediaGroup> _photoService;

        public PicasaAccount SelectedAccount { get; set; }
        public List<PicasaAccount> AccountList { get; set; }

        public AccountListViewModel(IAccountRepository accountRepository,
                                    INavigationService navigationService,
                                    IPhotoService<PicasaAlbum, PicasaMediaGroup> photoService)
        {
            _accountRepository = accountRepository;
            _navigationService = navigationService;
            _photoService = photoService;            
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            _accountRepository.GetAllAccounts((accounts) =>
           {
               AccountList = accounts;
               NotifyOfPropertyChange(() => AccountList);
           });

        }
        

        /// <summary>
        /// Called when an account selected
        /// </summary>
        /// <param name="model">AccountListViewModel</param>
        public void OnSelectAccount(AccountListViewModel model)
        {
            this.Navigation_PicasaAlbumListView(model.SelectedAccount);
        }

        /// <summary>
        /// Navigate to create new account page
        /// </summary>
        public void Navigation_AccountCreateView()
        {
            _navigationService.Navigate(UrlHelper.AccountCreate());
        }

        public void UpdateAccount(PicasaAccount account)
        {
            MessageBox.Show("Update: Not implemented");
        }

        public void DeleteAccount(PicasaAccount account)
        {
            var message = String.Format("Are you sure want to delete \"{0}\"?", account.User);
            var result = MessageBox.Show(message, "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                MessageBox.Show("Delete: Not implemented");
            }
        }

        /// <summary>
        /// Navigate to picasa albums list
        /// </summary>
        public void Navigation_PicasaAlbumListView(PicasaAccount account)
        {            
            if (account != null)
            {
                //TODO: error handler. Handle auth error
                _photoService.Login(account.User, account.Password,
                (auth) => _navigationService.Navigate(UrlHelper.PicasaAlbumList()));
            }
        }

    }
}
