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
using Phone.Api;
using System.Linq;
using System.Windows.Media.Imaging;

namespace PhotoSharing.Model
{
    public class PhoneModel
    {
        public List<Picture> GetAllPictures()
        {
            PhoneService service = new PhoneService();
            return null;
        }
    }
}
