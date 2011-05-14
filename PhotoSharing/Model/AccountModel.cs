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
using System.ComponentModel;
using System.Collections.Generic;
using PhotoSharing.Data.Entities;
using PhotoSharing.Data;
using System.Collections.ObjectModel;

namespace PhotoSharing.Model
{
    public class AccountModel
    {
        AccountRepository repo = new AccountRepository(); 

        public ObservableCollection<Account> GetAllAccounts()
        {                  
            return repo.GetAllAccounts();
        }

        public void AddAccount(string user, string password)
        {
            repo.AddAccount(user, password);
        }
    }
}
