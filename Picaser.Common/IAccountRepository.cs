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


namespace Picaser.Common
{
    public interface IAccountRepository
    {
        void GetAllAccounts(Action<List<PicasaAccount>> callback);
        void Add(PicasaAccount account);
        void Delete(PicasaAccount account);
    }
}
