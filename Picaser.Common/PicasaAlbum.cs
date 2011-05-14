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
using System.ServiceModel.Syndication;
using System.Collections.Generic;

namespace Picaser.Common
{
    [XmlRoot(ElementName = "entry", Namespace = "http://www.w3.org/2005/Atom")]

    public class PicasaAlbum : PicasaMediaGroup
    {
        public PicasaAlbum()
        {
            Category = new PicasaCategory()
            {
                Scheme = "http://schemas.google.com/g/2005#kind",
                Term = "http://schemas.google.com/photos/2007#album"
            };
        }

        public string Id { get; set; }
        public string AlbumUrl { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }

        [XmlElement(ElementName = "access", Namespace = "http://schemas.google.com/photos/2007")]
        public string Access { get; set; }

        //[XmlElement(ElementName = "timestamp", Namespace = "http://schemas.google.com/photos/2007")]
        [XmlIgnore]
        public long Timestamp { get; set; }

        [XmlIgnore]
        public long NumPhotos { get; set; }

        [XmlIgnore]
        public string User { get; set; }

        [XmlIgnore]
        public string Nickname { get; set; }

        [XmlIgnore]
        public bool CommentingEnabled { get; set; }

        [XmlIgnore]
        public long CommentCount { get; set; }

        [XmlIgnore]
        public DateTime PublishDate { get; set; }


        [XmlElement("category")]
        public PicasaCategory Category { get; set; }

        //[XmlElement("link")]
        //public Atom.AtomLink[] Links { get; set; }

    }
}
