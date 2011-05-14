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

namespace Picaser.Common
{
    public class PicasaAccount
    {
        public string User { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        
        public string AuthToken { get; set; }
        public DateTime LastAuthDate { get; set; }      
    }
}
