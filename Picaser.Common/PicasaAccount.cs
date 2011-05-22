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
using System.Xml.Serialization;

namespace Picaser.Common
{
    public class PicasaAccount
    {
        [XmlAttribute]
        public string User { get; set; }

        [XmlAttribute]
        public string Password { get; set; }

        [XmlAttribute]
        public bool IsAuthenticated { get; set; }

        [XmlAttribute]
        public string AuthToken { get; set; }

        [XmlAttribute]
        public DateTime LastAuthDate { get; set; }      
    }
}
