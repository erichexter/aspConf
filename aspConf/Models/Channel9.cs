namespace aspConf.Models {
    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Security.Cryptography;
    using System.Web;
    using System.Web.Caching;
    using System.Xml;

    /// <summary>
    /// Summary description for ClassName
    /// </summary>
    public static class Channel9 {
        public static void Clear() {
            var context = HttpContext.Current;
            context.Cache.Remove("__videos");
        }
    
        public static Ch9Video GetVideo(string key) {
            var videos = Videos();
            return videos.Where(vid => vid.Key == key).SingleOrDefault();
        }
    
        public static IList<Ch9Video> Videos() {
            var context = HttpContext.Current;
            var videoList = context.Cache["__videos"] as IList<Ch9Video>;
        
            if(videoList != null) return videoList;
            videoList = GenerateFromFeed();
       
            context.Cache.Insert("__videos", videoList, null, DateTime.Now.AddHours(1), 
                                 Cache.NoSlidingExpiration);
            return videoList;
        }
    
        private static IList<Ch9Video> GenerateFromFeed() {
            var feedUrl = ConfigurationManager.AppSettings["ch9Feed"];
            var reader = XmlReader.Create(feedUrl);
            var feed = SyndicationFeed.Load(reader);
        
            return feed.Items
                .OrderBy(item => item.PublishDate)
                .Select(item => {
                            var link = item.Links[1];
                            var url = link.Uri.ToString();
                            url = url.Replace("_ch9.wmv","_2MB_ch9.wmv");
                
                            return new Ch9Video  {
                                                     Key = GenerateKey(item.Id),
                                                     Title = item.Title.Text.Replace("mvcConf 2 - ", ""), 
                                                     Description = item.Summary.Text,
                                                     Url = item.Id,
                                                     MediaUrl = url//,
                                                     //ThumbnailUrl = item.GetThumbnailUrl()
                                                 };
                        })
                .ToList();
        }
    
        //private static string GetThumbnailUrl(this SyndicationItem item) {   
        //    var extensionNamespaceUri = "http://search.yahoo.com/mrss/";
        //    var extension= item.ElementExtensions
        //        .Where
        //        (x => x.OuterNamespace == extensionNamespaceUri)
        //        .FirstOrDefault();
        
        //    if (extension == null) return string.Empty;
        
        //    var element = extension.GetObject<XElement>();
        //    var attribute = element.Attribute("url");
        //    return attribute.Value;
        //}
    
        private static string GenerateKey(string url) {
            var tempData = System.Text.Encoding.UTF8.GetBytes(url);
            var tmpHash = new MD5CryptoServiceProvider().ComputeHash(tempData);
					
            var hash = Convert.ToBase64String(tmpHash);
            return hash.Replace("/", "_").Replace("+", "_");
        }
    }
}