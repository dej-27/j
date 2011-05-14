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
using Coding4Fun.Phone.Controls;
using Microsoft.Phone.Shell;
using System.ServiceModel.Syndication;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using Picasa.Api;

namespace PhotoSharing
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            //InputPrompt prompt = new InputPrompt();
            //prompt.Title = "New Account";
            //prompt.Message = "Please, type your picasa account";
            //prompt.Completed += new EventHandler<PopUpEventArgs<string, PopUpResult>>(prompt_Completed);
            //prompt.Show();


            string albumsURL = "https://picasaweb.google.com/data/feed/base/user/{0}?alt=rss&kind=album&hl=ru&access=public";

            

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            //client.DownloadStringAsync(new Uri(String.Format(albumsURL, "asdad")));
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //XmlReader xmlReader = XmlReader.Create(new StringReader(e.Result));
            //SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            //var mrss = "http://search.yahoo.com/mrss/";

            //var mediaColl = (from i in feed.Items
            //                 select new PicasaMediaGroup
            //                 {
            //                     AlbumUrl = i.Id.Replace("/entry/", "/feed/") + "kind=photo",
            //                     Title = i.ElementExtensions[0].GetObject<XElement>().Element(XName.Get("title", mrss)).Value,
            //                     ThumbnailUrl = i.ElementExtensions[0].GetObject<XElement>().Element(XName.Get("thumbnail", mrss)).Attribute("url").Value
            //                 }).ToList();


            //ContentPanel.ItemsSource = mediaColl;
        }



        private void ContentPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           

            //MediaGroup group = (sender as ListBox).SelectedItem as MediaGroup;



            //string uri = String.Format("/AlbumContent.xaml?AlbumUrl={0}", group.AlbumUrl);
            //NavigationService.Navigate(new Uri(uri, UriKind.Relative));

            
        }

        //void prompt_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        //{
        //    ContentPanel.Items.Add(e.Result);            
        //}
    }
}