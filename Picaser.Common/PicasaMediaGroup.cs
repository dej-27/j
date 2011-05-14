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
    public class PicasaMediaGroup
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("summary")]
        public string Description { get; set; }

        public string ContentUrl { get; set; }
        public string ContentType { get; set; }
    }
}
