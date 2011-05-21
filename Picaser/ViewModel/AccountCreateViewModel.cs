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
using Caliburn.Micro;
using Picaser.Common;

namespace Picaser.ViewModel
{
    public class AccountCreateViewModel : Screen
    {
        readonly IAccountRepository _accountRepository;
        readonly INavigationService _navigationService;
        public PicasaAccount Account { get; set; }

        public AccountCreateViewModel(IAccountRepository accountRepository,
                                      INavigationService navigationService)
        {
            _accountRepository = accountRepository;
            _navigationService = navigationService;

            Account = new PicasaAccount();
        }

        public void SaveAccount(AccountCreateViewModel model)
        {
            //TODO: add validation fields and picasa account on server
            if (model.Account != null)
            {
                _accountRepository.Add(model.Account);
                _navigationService.GoBack();
            }
        }
    }
}