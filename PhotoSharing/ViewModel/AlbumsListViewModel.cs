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
using PhotoSharing.Model;
using System.Collections.ObjectModel;

namespace PhotoSharing.ViewModel
{
    public class AlbumsListViewModel : ObservableCollection<AlbumModel>
    {
        public AlbumsListViewModel()
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    Add(new AlbumModel()
            //    {
            //        ContentUrl = "https://lh4.googleusercontent.com/_HdMVbhUrjSk/Tb2uYEiT60E/AAAAAAAADD0/tDT8nSkcwME/Berlin02.jpg",
            //        Title = "Berlin",
            //        NumPhotos = 25,
            //        PublishDate = DateTime.Parse("Sat, 16 Apr 2011 07:00:00 +0000"),
            //    });

            //    Add(new AlbumModel()
            //    {
            //        ContentUrl = "https://lh4.googleusercontent.com/_HdMVbhUrjSk/TalNLzyQ7HE/AAAAAAAACu4/3ejnAzgoFos/BerlinPotsdamerPlatz.jpg",
            //        Title = "Berlin, Potsdamer Platz",
            //        NumPhotos = 1242,
            //        PublishDate = DateTime.Parse("Sat, 16 Apr 2011 07:00:00 +0000"),
            //    });

            //    Add(new AlbumModel()
            //    {
            //        ContentUrl = "https://lh4.googleusercontent.com/_HdMVbhUrjSk/TangfO__D3E/AAAAAAAADD8/itBeISZC5DY/BerlinCharlottenburgPalace.jpg",
            //        Title = "Berlin, Charlottenburg Palace",
            //        NumPhotos = 1,
            //        PublishDate = DateTime.Parse("Sat, 16 Apr 2011 07:00:00 +0000"),
            //    });

            //    Add(new AlbumModel()
            //    {
            //        ContentUrl = "https://lh5.googleusercontent.com/_HdMVbhUrjSk/TTvyn4D371E/AAAAAAAAC5Q/RwWLkn1_e9U/BerlinAlexanderplatz.jpg",
            //        Title = "Berlin, Alexanderplatz",
            //        NumPhotos = 91,
            //        PublishDate = DateTime.Parse("Sat, 16 Apr 2011 07:00:00 +0000"),
            //    });
            //}
            
        }
    }
}
