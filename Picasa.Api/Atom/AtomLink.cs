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

namespace Picasa.Api.Atom
{    
    public class AtomLink
    {
        [XmlAttribute("rel")]
        public string Rel { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("href")]
        public string Href { get; set; }
    }
}
