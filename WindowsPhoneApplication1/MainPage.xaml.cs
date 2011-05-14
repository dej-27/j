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

namespace WindowsPhoneApplication1
{
    public class City
    {
        public string Name
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }

        public string Language
        {
            get;
            set;
        }
    }



    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            MediaLibrary lib = new MediaLibrary();

            //List<PhonePicture> pics = (from p in lib.Pictures
            //                           select new PhonePicture()
            //                           {
            //                               Title = p.Name,
            //                               Image = GetImage(p.GetImage()),
            //                               Thumbnail = GetImage(p.GetThumbnail())
            //                           }).ToList();


            //LongList.ItemsSource = pics;


            List<City> source = new List<City>();
            source.Add(new City() { Name = "Madrid", Country = "ES", Language = "Spanish" });
            source.Add(new City() { Name = "Barcelona", Country = "ES", Language = "Spanish" });
            source.Add(new City() { Name = "Mallorca", Country = "ES", Language = "Spanish" });
            source.Add(new City() { Name = "Las Vegas", Country = "US", Language = "English" });
            source.Add(new City() { Name = "Dalas", Country = "US", Language = "English" });
            source.Add(new City() { Name = "New York", Country = "US", Language = "English" });
            source.Add(new City() { Name = "London", Country = "UK", Language = "English" });
            source.Add(new City() { Name = "Mexico", Country = "MX", Language = "Spanish" });
            source.Add(new City() { Name = "Milan", Country = "IT", Language = "Italian" });
            source.Add(new City() { Name = "Roma", Country = "IT", Language = "Italian" });
            source.Add(new City() { Name = "Paris", Country = "FR", Language = "French" });


            //citiesListGropus.ItemsSource = from city in source
            //                       group city by city.Country into c
            //                       orderby c.Key
            //                       select new Group<City>(c.Key, c);


            var groups = (from p in lib.Pictures
                          group p by p.Album into album
                          orderby album.Key.Name
                          select new PhoneAlbum
                          {
                              Name = album.Key.Name,                              
                              Pictures = album.Key.Pictures.ToList()
                          });

            //List<object> objs = new List<object>();
            //foreach (var item in groups)
            //{
            //    objs.Add(item.Album);                
            //    objs.AddRange(item.Pics.ToArray());
            //}


            //MessageBox.Show(groups[0].Album.Name);
            lstBox1.ItemsSource = groups;

            //citiesListGropus.ItemsSource = from g in groups                                            
            //                               select new Group<Picture>(g.Album, g.Pics);

            //var a = from p in lib.Pictures
            //        from a in p.Album

            //        select new Group<PhonePicture>( pp.Key, pp.






            //citiesListGropus.ItemsSource = from pic in lib.Pictures
            //                               group pic by pic.Album.Name into a
            //                               orderby a.Key
            //                               select new Group<PhonePicture>(a.Key, a);
        }



        public BitmapImage GetImage(Stream stream)
        {
            BitmapImage image = new BitmapImage();
            image.SetSource(stream);
            return image;
        }
    }
}