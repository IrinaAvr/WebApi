using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
//using System.Web.Http;
using System.Net;
using Models;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DAL
{
    public class Repositories
    {
        public List<RepositoryModel> GetRepositoriesByKeyword(string Keyword)
        {
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream data = client.OpenRead(new Uri("https://api.github.com/search/repositories?q=" + Keyword, UriKind.Absolute));

            StreamReader reader = new StreamReader(data);

            string jsonString = reader.ReadToEnd();

            data.Close();

            reader.Close();

            //string path = @"C:\Users\irinaav1\Documents\Visual Studio 2015\Projects\WEBAPI\WEBAPI\repositories.json";
            //jsonString = File.ReadAllText(path).ToString();
            var RepositoryList = new List<RepositoryModel>();
            var obj = JsonConvert.DeserializeObject<ResultRootObject>(jsonString);

            if (obj != null && obj.total_count > 0)
            {
                foreach (var item in obj.items)
                {
                    RepositoryList.Add(new RepositoryModel()
                    {
                        Id = item.id,

                        RepositoryName = item.full_name,

                        FotoURL = item.owner.avatar_url,

                        Bookmark = false
                    });
                }
            }
            return RepositoryList;
        }
    }
}