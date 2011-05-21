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
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Picaser.Helpers
{
    public class StorageHelper
    {

        public static List<T> GetList<T>()
        {
            var filePath = String.Format("{0}List.xml", typeof(T));
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (storage.FileExists(filePath))
                {
                    using (var fileStream = storage.OpenFile(filePath, FileMode.Open))
                    {
                        return (List<T>)serializer.Deserialize(fileStream);
                    }
                }
            }

            return new List<T>();
        }


        public static void SaveList<T>(List<T> list)
        {
            var filePath = String.Format("{0}List.xml", typeof(T));
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var fileStream = storage.OpenFile(filePath,FileMode.OpenOrCreate))
                {
                    serializer.Serialize(fileStream, list);
                }                
            }
        }


    }
}
