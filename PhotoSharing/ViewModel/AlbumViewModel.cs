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
using Picasa.Api;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Collections.Generic;
using PhotoSharing.Helpers;
using Picaser.Common;

namespace PhotoSharing.ViewModel
{
    public class AlbumViewModel : INotifyPropertyChanged
    {
        AlbumModel model = new AlbumModel();

        public AlbumViewModel()
        {
            Album = new PicasaAlbum() { Access = "Public" };
            model.GetAllPicasaAlbums((result) =>
            {
                PicasaAlbums = result;
                OnPropertyChanged("PicasaAlbums");
            });
        }     

        public List<PicasaAlbum> PicasaAlbums { get; set; }
        public PicasaAlbum Album { get; set; }

        public ICommand NewAlbumCommand
        {
            get
            {
                return new RelayCommand<PicasaAlbum>((album) =>
                {
                    //TODO: add validation
                    model.CreatePicasaAlbum(album, (result) =>
                    {
                        if (result == "200")
                        {
                            Album = new PicasaAlbum(); //TODO  Is it required ?
                            ViewHelper.Navigate(new Uri("/View/Album/AlbumsList.xaml", UriKind.Relative));
                        }
                        else
                        {
                            //TODO: handle error
                        }
                    });
                    //model.AddAccount(a.User, a.Password);
                    //Account = new Account();                    
                });
            }
        }

        public ICommand AccessSelectionChangedCommand
        {
            get
            {
                return new RelayCommand<string>((access) =>
                {
                    Album.Access = access;
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
