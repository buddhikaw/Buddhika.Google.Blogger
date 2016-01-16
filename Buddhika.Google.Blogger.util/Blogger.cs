using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Blogger.v3;
using Google.Apis.Blogger.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Buddhika.Google.Blogger.util
{
    public class Blogger
    {
        public UserCredential credential { get; set; }
        public BloggerService service { get; set; }

        public async void Authentication()
        {
            try
            {
                using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { BloggerService.Scope.Blogger },
                        "user", CancellationToken.None, new FileDataStore("Blogger.util"));
                }
            }
            catch (Exception)
            {

            }

        }

        public void ServiceOpen()
        {
            service = new BloggerService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Buddhika Blogger",
            });
        }

        public long GetPageViews()
        {
            long? count;
            var p = service.PageViews.Get("2590723630599333470");
            p.Range = PageViewsResource.GetRequest.RangeEnum.All;
            Pageviews response = p.Execute();
            count = response.Counts[0].Count;
            return count ?? 0;
            //StreamReader reader = new StreamReader(str);
            //string text = reader.ReadToEnd();
        }
    }
}
