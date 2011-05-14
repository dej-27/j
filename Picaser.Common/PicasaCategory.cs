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
using System.Xml.Serialization;

namespace Picaser.Common
{
    public class PicasaCategory
    {
        [XmlAttribute("scheme")]
        public string Scheme { get; set; }

        [XmlAttribute("term")]
        public string Term { get; set; }
    }
}
