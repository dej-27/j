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
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Net.Browser;
using System.Threading;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using Picaser.Common;

namespace Picasa.Api
{
    public class PicasaService
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

        public delegate void StringResultCallback(string result);
        public delegate void AlbumsResultCallback(List<PicasaAlbum> albumsResult);
        public delegate void AlbumPhotosResultCallback(List<PicasaMediaGroup> albumPhotosResult);
        public delegate void ServerResponseCallback(int status, string description);



        //public void SetAuthToRequest(HttpWebRequest request)
        //{
        //    if (AuthToken != null)
        //    {
        //        //Authorization: GoogleLogin auth=yourAuthValue
        //        request.Headers["Authorization"] = String.Format("GoogleLogin auth={0}", AuthToken);
        //    }
        //}

        private void GetRequest(string uri, string method, object state, StringResultCallback callback)
        {

            //WebClient client = new WebClient();

            //client.DownloadStringCompleted += (o, args) => {
            //    callback(args.Result);
            //};


            //client.DownloadStringAsync(new Uri(uri


            //var httpRequest = WebRequest.CreateHttp(uri);
            //httpRequest.Method = method;

            //SetAuthToRequest(httpRequest);

            //httpRequest.BeginGetResponse((result) =>
            //{
            //    var request = (HttpWebRequest)result.AsyncState;
            //    var response = request.EndGetResponse(result);

            //    var stream = response.GetResponseStream();
            //    var reader = new StreamReader(stream);

            //    if (callback != null)
            //    {
            //        callback(reader.ReadToEnd());
            //    }
            //    stream.Close();
            //    reader.Close();
            //}, httpRequest);

        }

        private SyndicationFeed GetFeed(string str)
        {
            return SyndicationFeed.Load(XmlReader.Create(new StringReader(str)));
        }

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

        private void SetAuthHeaders(WebClient client)
        {
            client.Headers["Authorization"] = String.Format("GoogleLogin auth={0}", AUTH_TOKEN);
        }

        //private Atom.AtomLink[] GetLinks(Collection<SyndicationLink> links)
        //{
        //    return (from l in links
        //            select new Atom.AtomLink()
        //            {
        //                Href = l.Uri.AbsoluteUri,
        //                Type = l.MediaType,
        //                Rel = l.RelationshipType
        //            }).ToArray();
        //}

        public void GetPicasaAlbums(AlbumsResultCallback callback)
        {
            WebClient client = new WebClient();
            string url = String.Format(ALBUM_BASED_FEED, ACCOUNT);

            //client.Headers["Authorization"] = String.Format("GoogleLogin auth={0}", AUTH_TOKEN);
            SetAuthHeaders(client);

            client.DownloadStringCompleted += (o, args) =>
            {

                //TODO: handle errors

                var feed = GetFeed(args.Result);

                var albumList = (from i in feed.Items
                                 select new PicasaAlbum
                                 {
                                     //Links = GetLinks(i.Links),

                                     AlbumUrl = i.Id.Replace("/entry/", "/feed/"),
                                     Id = i.Id.Split('/').Last(),

                                     PublishDate = DateTime.Parse(i.PublishDate.ToString()),

                                     Name = GetGPhotoValue(i.ElementExtensions, "name") as string,
                                     //Access = (PicasaVisibility)Enum.Parse(typeof(PicasaVisibility), (string)GetGPhotoValue(i.ElementExtensions, "access"), true),
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


            //StringRequest(String.Format(ALBUM_BASED_FEED, account), "GET", null, (result) =>
            //{

            //    callback(albumList);

            //});
        }

        public void DeletePicasaAlbum(string albumId, StringResultCallback callback)
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


            /////////////////////////////Works/////////////////////////////////////
            //HttpWebRequest httpWebRequest = HttpWebRequest.CreateHttp(url);         
            //httpWebRequest.Headers[HttpRequestHeader.IfNoneMatch] = HTTP_ETAG;
            //httpWebRequest.Headers[HttpRequestHeader.Authorization] = String.Format("GoogleLogin auth={0}", AUTH_TOKEN);        

            //httpWebRequest.Method = "DELETE";

            //httpWebRequest.BeginGetResponse((aResult) =>
            //{
            //    HttpWebRequest req = (HttpWebRequest)aResult.AsyncState;
            //    HttpWebResponse res = (HttpWebResponse)req.EndGetResponse(aResult);
            //}, httpWebRequest);
        }

        public void GetAlbumPhotos(string account, string albumId, AlbumPhotosResultCallback callback)
        {
            WebClient client = new WebClient();
            var url = String.Format(ALBUM_PHOTOS_BASED_FEED, account, albumId);

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

            //StringRequest(String.Format(ALBUM_PHOTOS_BASED_FEED, account, albumId), "GET", null, (result) =>
            //{

            //});
        }
        
        public void CreateAlbum(PicasaAlbum album, StringResultCallback callback)
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

        //private static ManualResetEvent allDone = new ManualResetEvent(false);

        public void Login(string account, string password, StringResultCallback callback)
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

            //var httpRequest = WebRequest.CreateHttp(LOGIN_URL);
            //httpRequest.Method = "POST";
            //httpRequest.ContentType = "application/x-www-form-urlencoded";

            //httpRequest.BeginGetRequestStream((result) =>
            //{

            //    StringBuilder sb = new StringBuilder();

            //    sb.AppendFormat("accountType={0}&", "HOSTED_OR_GOOGLE");
            //    sb.AppendFormat("service={0}&", "lh2");
            //    sb.AppendFormat("Email={0}&", account);
            //    sb.AppendFormat("Passwd={0}&", password);
            //    sb.AppendFormat("source={0}", "Gulp-CalGulp-1.05");


            //    var request = (HttpWebRequest)result.AsyncState;
            //    Stream postStream = request.EndGetRequestStream(result);
            //    byte[] byteArray = Encoding.UTF8.GetBytes(sb.ToString());

            //    postStream.Write(byteArray, 0, sb.Length);
            //    postStream.Close();


            //    request.BeginGetResponse((authResult) =>
            //    {
            //        var request2 = (HttpWebRequest)authResult.AsyncState;
            //        var response2 = request.EndGetResponse(authResult);

            //        var stream = response2.GetResponseStream();
            //        var reader = new StreamReader(stream);

            //        if (callback != null)
            //        {
            //            string authResponse = reader.ReadToEnd();
            //            string token = authResponse.Split(new string[] { "Auth=" }, StringSplitOptions.None).Last();
            //            AuthToken = token;
            //            callback(token);
            //        }
            //        stream.Close();
            //        reader.Close();
            //    }, request);



            //}, httpRequest);



            ////httpRequest.BeginGetResponse((result) =>
            ////{
            ////    var request = (HttpWebRequest)result.AsyncState;
            ////    var response = request.EndGetResponse(result);

            ////    var stream = response.GetResponseStream();
            ////    var reader = new StreamReader(stream);

            ////    if (callback != null)
            ////    {
            ////        callback(reader.ReadToEnd());
            ////    }
            ////    stream.Close();
            ////    reader.Close();
            ////}, httpRequest);


        }

        private void WriteRequestData(HttpWebRequest httpRequest, string data, AsyncCallback callback)
        {
            httpRequest.BeginGetRequestStream((result) =>
            {
                var request = (HttpWebRequest)result.AsyncState;

                Stream dataStream = request.EndGetRequestStream(result);
                byte[] byteArray = Encoding.UTF8.GetBytes(data);

                dataStream.Write(byteArray, 0, data.Length);
                dataStream.Close();

                callback(result);

            }, httpRequest);
        }

    }
}
