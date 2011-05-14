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
using System.Collections.ObjectModel;
using PhotoSharing.Model;

namespace PhotoSharing.ViewModel
{
    public class PhotosListViewModel : ObservableCollection<PhotoModel>
    {
        public PhotosListViewModel()
        {
            for (int i = 0; i < 100; i++)
            {
                Add(new PhotoModel()
                {
                    Title = "aWQ1pMWIQEfx.jpg",
                    ContentUrl = "https://lh3.googleusercontent.com/_HdMVbhUrjSk/TalN2YRgnFI/AAAAAAAACrI/HvVu3rnYt3U/aWQ1pMWIQEfx.jpg"
                });

                Add(new PhotoModel()
                {
                    Title = "aWQ1pMWIQEfx.jpg",
                    ContentUrl = "https://lh5.googleusercontent.com/_HdMVbhUrjSk/TalN-_lAcfI/AAAAAAAACrM/J5rWSQm4fN4/c4FpJvVMpU0k.jpg"
                });

                Add(new PhotoModel()
                {
                    Title = "aWQ1pMWIQEfx.jpg",
                    ContentUrl = "https://lh6.googleusercontent.com/_HdMVbhUrjSk/TalOHjQK-2I/AAAAAAAACrU/vZk2mpP155g/Fi4mEjg1vbRX.jpg"
                });

                Add(new PhotoModel()
                {
                    Title = "aWQ1pMWIQEfx.jpg",
                    ContentUrl = "https://lh3.googleusercontent.com/_HdMVbhUrjSk/TalOMvJjOPI/AAAAAAAACrY/lns2Iki8pUU/0BQpS54DDzjb.jpg"
                });

                Add(new PhotoModel()
                {
                    Title = "aWQ1pMWIQEfx.jpg",
                    ContentUrl = "https://lh5.googleusercontent.com/_HdMVbhUrjSk/TalOS9YIBhI/AAAAAAAACrk/Fj-0Z5a1eCs/wQub4GgJqNa6.jpg"
                });

                Add(new PhotoModel()
                {
                    Title = "aWQ1pMWIQEfx.jpg",
                    ContentUrl = "https://lh3.googleusercontent.com/_HdMVbhUrjSk/TalOqeIEwiI/AAAAAAAACr0/lzVl6Un8jsc/F5aSVEs1gWdO.jpg"
                });

                Add(new PhotoModel()
                {
                    Title = "aWQ1pMWIQEfx.jpg",
                    ContentUrl = "https://lh5.googleusercontent.com/_HdMVbhUrjSk/TalOaYZe6aI/AAAAAAAACro/d-bR7226jw0/cGvJ4sNlJ74z.jpg"
                });

                Add(new PhotoModel()
                {
                    Title = "aWQ1pMWIQEfx.jpg",
                    ContentUrl = "https://lh3.googleusercontent.com/_HdMVbhUrjSk/TalOwcEEqaI/AAAAAAAACr4/m6wCKeNtOiw/qqcjqFM92Psj.jpg"
                });


            }

        }

        public string AlbumName
        {
            get
            {
                return "Berlin, Charlottenburg Palace";
            }
        }
    }
}
