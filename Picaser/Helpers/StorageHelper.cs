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
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml;

namespace Picaser.Helpers
{
    public class StorageHelper
    {
        public StorageHelper()
        {
            using (var appStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (appStorage.FileExists("test.xml"))
                {

                    using (var file = appStorage.OpenFile("test.xml", FileMode.OpenOrCreate))
                    {
                        var reader = XmlReader.Create(file);
                    }
                }
            }
        }




    }
}
