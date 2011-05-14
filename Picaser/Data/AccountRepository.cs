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
using Picaser.Common;

namespace Picaser.Data
{
    public class AccountRepository : IAccountRepository
    {
        private List<PicasaAccount> _accounts;

        public AccountRepository()
        {
            _accounts = new List<PicasaAccount>();            
            _accounts.Add(new PicasaAccount() { User = "vasya.pupkin82xs12@googlemail.com", Password = "vasya.pupkin123" });
            _accounts.Add(new PicasaAccount() { User = "vasya.pupkin11mx98@googlemail.com", Password = "vasya.pupkin123" });
            _accounts.Add(new PicasaAccount() { User = "vasya.pupkin42n11@googlemail.com", Password = "vasya.pupkin123" });
        }

        public List<PicasaAccount> GetAllAccounts()
        {
            return _accounts;
        }

        public void Add(PicasaAccount account)
        {
            MessageBox.Show("AccountRepository Add");
        }

        public void Delete(PicasaAccount account)
        {
            MessageBox.Show("AccountRepository Delete");            
        }

        public void Update(PicasaAccount account)
        {
            MessageBox.Show("AccountRepository Update");            
        }
    }
}
