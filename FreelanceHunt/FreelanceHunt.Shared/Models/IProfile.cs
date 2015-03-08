using System;
namespace FreelanceHunt.Models
{
    public interface IProfile
    {
        string avatar { get; set; }
        DateTime? birth_date { get; set; }
        string city_name_ru { get; set; }
        string country_name_ru { get; set; }
        DateTime creation_date { get; set; }
        string email { get; set; }
        string fname { get; set; }
        string icq { get; set; }
        string is_birth_date_verified { get; set; }
        string is_email_verified { get; set; }
        bool is_employer { get; set; }
        string is_fname_verified { get; set; }
        bool is_freelancer { get; set; }
        string is_okpay_verified { get; set; }
        bool is_online { get; set; }
        string is_phone_verified { get; set; }
        string is_wmid_verified { get; set; }
        DateTime last_activity { get; set; }
        string login { get; set; }
        string negative_reviews { get; set; }
        string phone { get; set; }
        string positive_reviews { get; set; }
        string profile_id { get; set; }
        string rating { get; set; }
        string rating_position { get; set; }
        string rating_position_category { get; set; }
        string rating_position_category_alt { get; set; }
        string skill_alt_name { get; set; }
        string skill_name { get; set; }
        string skype { get; set; }
        string sname { get; set; }
        string status_name { get; set; }
        string url { get; set; }
        string url_private_message { get; set; }
        string website { get; set; }
        string wmid { get; set; }
        string yandex_money { get; set; }
    }
}
