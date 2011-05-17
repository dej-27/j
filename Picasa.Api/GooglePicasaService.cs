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
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml.Linq;
using System.Linq;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Picaser.Common;

namespace Picasa.Api
{
    public class GooglePicasaService : Picaser.Common.IPhotoService<PicasaAlbum, PicasaMediaGroup>
    {
        public static string AUTH_TOKEN { get; set; }
        public static string ACCOUNT { get; set; }

        const string MEDIA_RSS_NAMESPACE = "http://search.yahoo.com/mrss/";
        const string GPHOTO_NAMESPACE = "http://schemas.google.com/photos/2007";

        const string LOGIN_URL = "https://www.google.com/accounts/ClientLogin";
        const string ALBUM_BASED_FEED = "https://picasaweb.google.com/data/feed/api/user/{0}?access=all";
        const string ALBUM_PHOTOS_BASED_FEED = "https://picasaweb.google.com/data/feed/api/user/{0}/albumid/{1}";

        const string ALBUM_CREATE_FEED = "https://picasaweb.google.com/data/feed/api/user/{0}";
        const string ALBUM_DELETE_FEED = "https://picasaweb.google.com/data/entry/api/user/{0}/albumid/{1}";

        #region Authentication

        /// <summary>
        /// Set authentication header to WebClient
        /// </summary>
        /// <param name="client">WebClient object reference</param>
        private void SetAuthHeaders(WebClient client)
        {
            client.Headers["Authorization"] = String.Format("GoogleLogin auth={0}", AUTH_TOKEN);
        }

        public void Login(string account, string password, Action<string> callback)
        {
            //AuthToken = "DQAAAMcAAABtg8ivmzbztgEs3KAWU3yhlUKQsQKkNEA3eOuqdcd6wt-RUtDmV5wy1Ch-JifgCXT1TAQzTQh4YF6EMfFdSVhEnzBcbQsdBwUmae0es6DI_gp-gAx9vUOule_99xaorbGLFeq3Pwc4fSCo3enGiVzcjnUXCubtsCi5MmE5-cYuvb1f5_vSaM_5EU8CW3mw-6O3xReV1VF1wL4PAY4OYOApFbcQOGyZwI5FSB0zWsnwSijX18N6Jwyf_21NR8RCgFULMR_w7GGMpoEmzBO3LRC0";
            //callback(AuthToken);

            WebClient client = new WebClient();
            client.UploadStringCompleted += (o, args) =>
            {
                //TODO: handle errors
                var loginResult = args.Result;
                string token = loginResult.Split(new string[] { "Auth=" }, StringSplitOptions.None).Last();
                AUTH_TOKEN = token;
                ACCOUNT = account;

                callback(AUTH_TOKEN);
            };

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("accountType={0}&", "HOSTED_OR_GOOGLE");
            sb.AppendFormat("service={0}&", "lh2");
            sb.AppendFormat("Email={0}&", account);
            sb.AppendFormat("Passwd={0}&", password);
            sb.AppendFormat("source={0}", "Gulp-CalGulp-1.05"); //TODO: change to my app

            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.UploadStringAsync(new Uri(LOGIN_URL), "POST", sb.ToString());
        }

        #endregion

        #region Helpers

        private object GetGPhotoValue(SyndicationElementExtensionCollection coll, string name)
        {

            var element = coll.SingleOrDefault(e => e.OuterNamespace == GPHOTO_NAMESPACE && e.OuterName == name);
            if (element != null)
            {
                return element.GetObject<XElement>().Value;
            }

            return null;
        }

        private XElement GetMRSSValue(SyndicationElementExtensionCollection coll, string name)
        {

            var element = coll.SingleOrDefault(e => e.OuterNamespace == MEDIA_RSS_NAMESPACE);
            if (element != null)
            {
                return element.GetObject<XElement>().Element(XName.Get(name, MEDIA_RSS_NAMESPACE));
            }

            return new XElement("new", "");
        }

        private SyndicationFeed GetFeed(string str)
        {
            return SyndicationFeed.Load(XmlReader.Create(new StringReader(str)));
        }

        #endregion

        #region IPhotoService

        public void GetAlbums(Action<List<PicasaAlbum>> callback)
        {
            WebClient client = new WebClient();
            string url = String.Format(ALBUM_BASED_FEED, ACCOUNT);

            SetAuthHeaders(client);

            client.DownloadStringCompleted += (o, args) =>
            {
                //TODO: handle errors
                var feed = GetFeed(args.Result);
                var albumList = (from i in feed.Items
                                 select new PicasaAlbum
                                 {
                                     AlbumUrl = i.Id.Replace("/entry/", "/feed/"),
                                     Id = i.Id.Split('/').Last(),
                                     PublishDate = DateTime.Parse(i.PublishDate.ToString()),
                                     Name = GetGPhotoValue(i.ElementExtensions, "name") as string,
                                     Access = GetGPhotoValue(i.ElementExtensions, "access") as string,
                                     Timestamp = long.Parse(GetGPhotoValue(i.ElementExtensions, "timestamp") as string ?? "0"),
                                     NumPhotos = long.Parse(GetGPhotoValue(i.ElementExtensions, "numphotos") as string ?? "0"),
                                     User = GetGPhotoValue(i.ElementExtensions, "user") as string,
                                     Nickname = GetGPhotoValue(i.ElementExtensions, "nickname") as string,
                                     CommentingEnabled = bool.Parse(GetGPhotoValue(i.ElementExtensions, "commentingEnabled") as string ?? "false"),
                                     CommentCount = long.Parse(GetGPhotoValue(i.ElementExtensions, "commentCount") as string ?? "0"),
                                     Title = GetMRSSValue(i.ElementExtensions, "title").Value,
                                     Description = GetMRSSValue(i.ElementExtensions, "description").Value,
                                     ContentUrl = GetMRSSValue(i.ElementExtensions, "content").Attribute("url").Value,
                                     ContentType = GetMRSSValue(i.ElementExtensions, "content").Attribute("type").Value
                                 }).ToList();
                callback(albumList);

            };
            client.DownloadStringAsync(new Uri(url));
        }

        public void GetAlbumPhotos(string albumId, Action<List<PicasaMediaGroup>> callback)
        {
            WebClient client = new WebClient();
            var url = String.Format(ALBUM_PHOTOS_BASED_FEED, ACCOUNT, albumId);

            SetAuthHeaders(client);

            client.DownloadStringCompleted += (o, args) =>
            {
                var feed = GetFeed(args.Result);
                var albumPhotos = (from i in feed.Items
                                   select new PicasaMediaGroup
                                   {
                                       Title = GetMRSSValue(i.ElementExtensions, "title").Value,
                                       Description = GetMRSSValue(i.ElementExtensions, "description").Value,
                                       ContentUrl = GetMRSSValue(i.ElementExtensions, "content").Attribute("url").Value,
                                       ContentType = GetMRSSValue(i.ElementExtensions, "content").Attribute("type").Value

                                   }).ToList();
                callback(albumPhotos);
            };

            client.DownloadStringAsync(new Uri(url));
        }

        public void DeleteAlbum(string albumId, Action<string> callback)
        {
            WebClient client = new WebClient();
            string url = String.Format(ALBUM_DELETE_FEED, ACCOUNT, albumId);

            SetAuthHeaders(client);
            client.Headers[HttpRequestHeader.IfNoneMatch] = Guid.NewGuid().ToString();
            client.Headers["X-HTTP-Method-Override"] = "DELETE";

            //TODO: add error handling
            client.UploadStringCompleted += (o, args) =>
            {
                if (args.Error == null)
                {
                    callback("200");
                }
                else
                {
                    callback("500");
                }
            };
            client.UploadStringAsync(new Uri(url), "POST");
        }

        public void CreateAlbum(PicasaAlbum album, Action<string> callback)
        {
            album.User = ACCOUNT;

            XmlSerializer serializer = new XmlSerializer(typeof(PicasaAlbum));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, album);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            var albumXMLbody = reader.ReadToEnd();

            WebClient client = new WebClient();
            string url = String.Format(ALBUM_CREATE_FEED, ACCOUNT);

            SetAuthHeaders(client);
            client.Headers[HttpRequestHeader.ContentType] = "application/atom+xml";

            client.UploadStringCompleted += (o, args) =>
            {
                if (args.Error == null)
                {
                    callback("200");
                }
                else
                {
                    callback("500");
                }
            };

            client.UploadStringAsync(new Uri(url), albumXMLbody);
        }

        public void UpdateAlbum(PicasaAlbum album, Action<string> callback)
        {
            throw new NotImplementedException();
        }


        public void UploadPhoto(string photoName, Stream photoStream, string albumId, Action<int> callback)
        {
            var url = GooglePicasaUrlHelper.UploadPhoto(ACCOUNT, albumId);
            //var url = String.Format("https://picasaweb.google.com/data/feed/api/user/{0}/albumid/5606723136600202209", account);

            WebClient client = new WebClient();
            SetAuthHeaders(client);

            client.Headers["Content-Type"] = "image/jpeg";
            if (photoName != String.Empty)
            {
                client.Headers["Slug"] = photoName;
            }

            client.OpenWriteCompleted += (sender, args) =>
            {               
                byte[] buffer = new byte[4096];
                int bytesRead;                

                //int total = 0;
                while ((bytesRead = photoStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    args.Result.Write(buffer, 0, bytesRead);
                    //total += 4096 * 100 / (int)input.Length;
                    //Debug.WriteLine(total);
                }

                //if (total < 100) total = 100;
                //Debug.WriteLine(total);                
                args.Result.Close();
                photoStream.Close();
            };

            client.WriteStreamClosed += (o, args) =>
            {
                if (args.Error == null)
                {
                    callback(200);
                    //MessageBox.Show("Upload completed!");
                }
                else
                {
                    callback(500);
                    //MessageBox.Show("Upload Error");
                }
            };
            client.OpenWriteAsync(url);

        }

        #endregion
    }
}
