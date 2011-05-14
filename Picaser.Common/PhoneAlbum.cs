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
using Microsoft.Xna.Framework.Media;

namespace Picaser.Common
{
    public class PhoneAlbum
    {
        public string Name { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}
