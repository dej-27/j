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


            var account = "";
            var password = "";
            GooglePicasaService service = new GooglePicasaService();
            service.Login(account, password, (authResult) =>
            {
                

                WebClient client = new WebClient();

                client.Headers["Authorization"] = String.Format("GoogleLogin auth={0}", authResult);
                client.Headers["Content-Type"] = "image/jpeg";
                client.Headers["Slug"] = picure.Name;

                //StreamReader sr = new StreamReader(picure.GetImage());


                Stream picStream = picure.GetImage();

                UploadFile(client, picStream);

                //client.OpenWriteCompleted += (sender, e) =>
                //{
                //    PushData(data, e.Result);
                //    e.Result.Close();
                //    data.Close();
                //};
                //client.OpenWriteAsync(ub.Uri);

            



                //StreamReader _data = new StreamReader(picStream);
                //int bytesRead = _data.Read(fileContent, 0, fileContent.Length);

                //BinaryReader binary = new BinaryReader(picStream);
                //Read bytes from the BinaryReader and put them into a byte array.
                //Byte[] imgB = binary.ReadBytes((int)picStream.Length);



                //client.OpenWriteCompleted += new OpenWriteCompletedEventHandler(client_OpenWriteCompleted);
                //client.OpenWriteAsync(new Uri(url), "POST", imgB);

            });
        }

        private void UploadFile(WebClient c, Stream data)
        {
            var url = "https://picasaweb.google.com/data/feed/api/user/ssssssssss/albumid/5606646906678744561";

            //UriBuilder ub = new UriBuilder("YOUR URL HERE");
            ////ub.Query = string.Format("name={0}", fileName);
                        
            c.OpenWriteCompleted += (sender, e) =>
            {
                PushData(data, e.Result);
                e.Result.Close();
                data.Close();
            };
            c.OpenWriteAsync(new Uri(url));
        }


        private void PushData(Stream input, Stream output)
        {
            byte[] buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) != 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }




    



    }
}