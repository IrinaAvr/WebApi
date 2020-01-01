using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Models
{
    public class RepositoryModel
    {
        public int Id { get; set; }
        public string RepositoryName { get; set; }
        public string FotoURL { get; set; }
        public bool Bookmark { get; set; }

    }

    public class ResultItem
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public Owner owner { get; set; }

    }

    public class Owner
    {
        public int id { get; set; }
        public string avatar_url { get; set; }

    }

    public class ResultRootObject
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<ResultItem> items { get; set; }

    }

}




