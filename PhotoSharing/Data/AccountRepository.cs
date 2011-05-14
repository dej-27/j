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
using PhotoSharing.Data.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PhotoSharing.Data
{
    public class AccountRepository
    {
        ObservableCollection<Account> accounts;

        public AccountRepository()
        {
            accounts = new ObservableCollection<Account>();

            accounts.Add(new Account() { User = "vasya.pupkin82xs12@googlemail.com", Password = "vasya.pupkin123" });
            accounts.Add(new Account() { User = "vasya.pupkin11mx98@googlemail.com", Password = "vasya.pupkin123" });
            accounts.Add(new Account() { User = "vasya.pupkin42n11@googlemail.com", Password = "vasya.pupkin123" });

            //accounts.Add(new Account() { User = "deslocator" });
            //accounts.Add(new Account() { User = "a.ruzmetov" });
        }

        public ObservableCollection<Account> GetAllAccounts()
        {
            return accounts;
        }


        public void AddAccount(string user, string password)
        {
            accounts.Add(new Account() { User = user, Password = password });
        }
    }
}
