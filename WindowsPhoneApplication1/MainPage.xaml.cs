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
using System.Diagnostics;

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


            var account = "vasya.pupkin82xs12@googlemail.com";
            var password = "vasya.pupkin123";
            GooglePicasaService service = new GooglePicasaService();
            service.Login(account, password, (authResult) =>
            {
                WebClient client = new WebClient();

                client.Headers["Authorization"] = String.Format("GoogleLogin auth={0}", authResult);
                client.Headers["Content-Type"] = "image/jpeg";
                client.Headers["Slug"] = picure.Name;


                Stream picStream = picure.GetImage();

                UploadFile(client, picStream, account);
            });
        }



        private void UploadFile(WebClient c, Stream data, string account)
        {
            

            var url = String.Format("https://picasaweb.google.com/data/feed/api/user/{0}/albumid/5606723136600202209", account);

            c.OpenWriteCompleted += (sender, e) =>
            {
                PushData(data, e.Result);
                e.Result.Close();
                data.Close();                
            };            
          
            c.WriteStreamClosed += (o, args) =>
            {
                if (args.Error == null)
                {
                    MessageBox.Show("Upload completed!");
                }
                else
                {
                    MessageBox.Show("Upload Error");
                }
               
            };
            Console.WriteLine("123");
            c.OpenWriteAsync(new Uri(url));
        }


        private void PushData(Stream input, Stream output)
        {
            byte[] buffer = new byte[4096];
            int bytesRead;

            //int total = 0;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) != 0)
            {
                output.Write(buffer, 0, bytesRead);
                
                //total += 4096 * 100 / (int)input.Length;
                //Debug.WriteLine(total);
            }

            //if (total < 100) total = 100;
            //Debug.WriteLine(total);
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

        }









    }
}