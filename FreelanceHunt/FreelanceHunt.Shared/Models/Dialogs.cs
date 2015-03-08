using System;
using System.Collections.Generic;
using System.Text;

namespace FreelanceHunt.Models
{

    public class Dialog
    {
        public string thread_id { get; set; }
        public string subject { get; set; }
        public string url { get; set; }
        public string url_api { get; set; }
        public From from { get; set; }
        public string has_attach { get; set; }
        public string message_count { get; set; }
        public DateTime first_post_time { get; set; }
        public DateTime last_post_time { get; set; }
        public bool? is_unread { get; set; }
    }
}
