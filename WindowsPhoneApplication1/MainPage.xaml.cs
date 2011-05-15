using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;
using System.IO;
using Picasa.Api;
using System.Windows.Resources;
using Microsoft.Phone;
using System.Text;

namespace WindowsPhoneApplication1
{


    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            MediaLibrary lib = new MediaLibrary();

            var groups = (from p in lib.Pictures
                          group p by p.Album into album
                          orderby album.Key.Name
                          select new PhoneAlbum
                          {
                              Name = album.Key.Name,
                              Pictures = album.Key.Pictures.ToList()
                          });
            lstBox1.ItemsSource = groups;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lisbox = sender as ListBox;
            var picure = lisbox.SelectedItem as Picture;

            GooglePicasaService service = new GooglePicasaService();
            service.Login("asdasdadd", "asdasd", (authResult) =>
            {
                var url = "https://picasaweb.google.com/data/feed/api/user/k123y/albumid/5606646906678744561";

                WebClient client = new WebClient();

                client.Headers["Authorization"] = String.Format("GoogleLogin auth={0}", authResult);
                client.Headers["Content-Type"] = "image/jpeg";
                client.Headers["Slug"] = picure.Name;

                //StreamReader sr = new StreamReader(picure.GetImage());


                Stream picStream = picure.GetImage();
                byte[] fileContent = new byte[picStream.Length];
                int bytesRead = picStream.Read(fileContent, 0, fileContent.Length);

                WebClient wc = new WebClient();
                wc.OpenWriteCompleted += new OpenWriteCompletedEventHandler(client_OpenWriteCompleted);
               
                wc.OpenWriteAsync(new Uri(url), null, new object[] { fileContent, bytesRead });
               



                //StreamReader _data = new StreamReader(picStream);
                //int bytesRead = _data.Read(fileContent, 0, fileContent.Length);

                //BinaryReader binary = new BinaryReader(picStream);
                //Read bytes from the BinaryReader and put them into a byte array.
                //Byte[] imgB = binary.ReadBytes((int)picStream.Length);



                //client.OpenWriteCompleted += new OpenWriteCompletedEventHandler(client_OpenWriteCompleted);
                //client.OpenWriteAsync(new Uri(url), "POST", imgB);

            });
        }



        void client_OpenWriteCompleted(object sender, OpenWriteCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                object[] objArr = e.UserState as object[];
                byte[] fileContent = objArr[0] as byte[];
                int bytesRead = Convert.ToInt32(objArr[1]);
                Stream outputStream = e.Result;
                outputStream.Write(fileContent, 0, bytesRead);
                outputStream.Close();
            }
             
        }




        byte[] ConvertToByte(Stream source)
        {

            MemoryStream memStream = new MemoryStream();

            byte[] buffer = new byte[1024];

            int bytes;



            while ((bytes = source.Read(buffer, 0, buffer.Length)) > 0)
            {

                memStream.Write(buffer, 0, buffer.Length);

            }



            return memStream.ToArray();

        }




    }
}