using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Models;
using System.IO;
using DAL;


namespace WebApi.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RepositoriesController : ApiController
    {
        [HttpGet]
        public List<RepositoryModel> GetRepositoriesByKeyword(string id)
        {
            return new Repositories().GetRepositoriesByKeyword(id);
            
        }

        [HttpPost]
        public List<RepositoryModel> BookmarkRepository(RepositoryModel rep)
        {
            List<RepositoryModel> list = new List<RepositoryModel>();
            if (HttpContext.Current.Session["bookmarks"] != null)
                list = (List<RepositoryModel>)HttpContext.Current.Session["bookmarks"];

            list.Add(rep);
            HttpContext.Current.Session["bookmarks"] = list;
            return list;
        }



        [HttpGet]
        public List<RepositoryModel> GetBookmarks()
        {
            List<RepositoryModel> list = new List<RepositoryModel>();
            if (HttpContext.Current.Session["bookmarks"] != null)
                list = (List<RepositoryModel>)HttpContext.Current.Session["bookmarks"];
            
            return list;

        }

    }
}