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

        private IsolatedStorageFile _storageFile;
        public IsolatedStorageFile StorageFile
        {
            get
            {
                if (_storageFile == null)
                {
                    _storageFile = IsolatedStorageFile.GetUserStoreForApplication();
                }
                return _storageFile;
            }
        }



        public List<T> GetList<T>()
        {
            var filePath = String.Format("{0}List.xml", typeof(T));
            var serializer = new XmlSerializer(typeof(List<T>));

            //using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            //{
            //    if (storage.FileExists(filePath))
            //    {
            //        using (var fileStream = storage.OpenFile(filePath, FileMode.Open))
            //        {
            //            using (var xmlReader = XmlReader.Create(fileStream))
            //            {
            //                return (List<T>)serializer.Deserialize(xmlReader);
            //            }
            //        }
            //    }
            //}


            
            

            if (StorageFile.FileExists(filePath))
            {
                using (var fileStream = new IsolatedStorageFileStream(filePath, FileMode.Open, this.StorageFile))
                {
                    return (List<T>)serializer.Deserialize(fileStream);
                }
            }

            //using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            //{
            //    if (storage.FileExists(filePath))
            //    {
            //        using (var fileStream = storage.OpenFile(filePath, FileMode.Open))
            //        {
            //            using (var xmlReader = XmlReader.Create(fileStream))
            //            {
            //                return (List<T>)serializer.Deserialize(xmlReader);
            //            }
            //        }
            //    }
            //}



            return new List<T>();
        }


        public void SaveList<T>(List<T> list)
        {
            var filePath = String.Format("{0}List.xml", typeof(T));
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));


            //using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            //{
            //    using (var fileStream = storage.OpenFile(filePath, FileMode.OpenOrCreate))
            //    {
            //        using (var xmlWriter = XmlWriter.Create(fileStream))
            //        {
            //            serializer.Serialize(xmlWriter, list);
            //        }
            //    }
            //}


            if (StorageFile.FileExists(filePath))
            {
                using (var fileStream = new IsolatedStorageFileStream(filePath, FileMode.OpenOrCreate, this.StorageFile))
                {
                    serializer.Serialize(fileStream, list);
                }
            }




        }


    }
}
