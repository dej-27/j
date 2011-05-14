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
using Picaser.Common;

namespace Picaser
{
    public class AppEvents
    {        

        /// <summary>
        /// New picasa album created
        /// </summary>
        public class PicasaAlbumCreated
        {
            public PicasaAlbum NewAlbum;
        }

        /// <summary>
        /// Picasa album selected
        /// </summary>
        public class PicasaAlbumSelected
        {
            public PicasaAlbum SelectedAlbum;
        }

    }
}
