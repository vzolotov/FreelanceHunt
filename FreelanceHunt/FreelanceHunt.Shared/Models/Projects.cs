using System;
using System.Collections.Generic;
using System.Text;

namespace FreelanceHunt.Models
{
    public class Project
    {
        public ulong project_id { get; set; }
        public string url { get; set; }
        public string url_api { get; set; }
        public From from { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string description_html { get; set; }
        public string status_id { get; set; }
        public string status_name { get; set; }
        public string budget_amount { get; set; }
        public string budget_currency_code { get; set; }
        public string bid_count { get; set; }
        public DateTime publication_time { get; set; }
        public DateTime expire_time { get; set; }
        public string is_job { get; set; }
        public string is_featured { get; set; }
        public string is_identity_verified { get; set; }
        public string country_name_ru { get; set; }
        public Dictionary<int, string> skills { get; set; }
    }

    public class From
    {
        public string url { get; set; }
        public string url_api { get; set; }
        public string profile_id { get; set; }
        public string login { get; set; }
        public string fname { get; set; }
        public string sname { get; set; }
        public string avatar { get; set; }
    }


}
