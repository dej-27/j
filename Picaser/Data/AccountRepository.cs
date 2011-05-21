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
using Picaser.Helpers;

namespace Picaser.Data
{
    public class AccountRepository : IAccountRepository
    {


        public void GetAllAccounts(Action<List<PicasaAccount>> callback)
        {
            var list = StorageHelper.GetList<PicasaAccount>();

            //TODO: Remove later
            if (list.Count == 0)
            {
                list.Add(new PicasaAccount() { User = "vasya.pupkin82xs12@googlemail.com", Password = "vasya.pupkin123" });
                list.Add(new PicasaAccount() { User = "vasya.pupkin11mx98@googlemail.com", Password = "vasya.pupkin123" });
                list.Add(new PicasaAccount() { User = "vasya.pupkin42n11@googlemail.com", Password = "vasya.pupkin123" });  //for ui test */
            }
            callback(list);         
        }

        public void Add(PicasaAccount account)
        {
            var list = StorageHelper.GetList<PicasaAccount>();
            list.Add(account);
            StorageHelper.SaveList<PicasaAccount>(list);
        }

        public void Delete(PicasaAccount account)
        {
            var list = StorageHelper.GetList<PicasaAccount>();
            list.Remove(account);
            StorageHelper.SaveList<PicasaAccount>(list);
        }
    }
}
