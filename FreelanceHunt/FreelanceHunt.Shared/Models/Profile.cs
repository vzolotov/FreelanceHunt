using System;
using System.Collections.Generic;
using System.Text;

namespace FreelanceHunt.Models
{   
    public class Profile : FreelanceHunt.Models.IProfile
    {
        public string profile_id { get; set; }
        public string url { get; set; }
        public string url_private_message { get; set; }
        public string avatar { get; set; }
        public bool is_freelancer { get; set; }
        public bool is_employer { get; set; }
        public string login { get; set; }
        public string fname { get; set; }
        public string sname { get; set; }
        public DateTime? birth_date { get; set; }
        public string rating { get; set; }
        public string rating_position { get; set; }
        public string country_name_ru { get; set; }
        public string city_name_ru { get; set; }
        public DateTime creation_date { get; set; }
        public string positive_reviews { get; set; }
        public string negative_reviews { get; set; }
        public string is_phone_verified { get; set; }
        public string is_fname_verified { get; set; }
        public string is_birth_date_verified { get; set; }
        public string is_wmid_verified { get; set; }
        public string is_okpay_verified { get; set; }
        public string is_email_verified { get; set; }
        public bool is_online { get; set; }
        public DateTime last_activity { get; set; }
        public string website { get; set; }
        public string status_name { get; set; }
        public string skill_name { get; set; }
        public string skill_alt_name { get; set; }
        public string rating_position_category { get; set; }
        public string rating_position_category_alt { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string skype { get; set; }
        public string wmid { get; set; }
        public string yandex_money { get; set; }
        public string icq { get; set; }
    }

}
