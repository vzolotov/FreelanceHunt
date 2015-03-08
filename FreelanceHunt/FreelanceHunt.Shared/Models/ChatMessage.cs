using System;
using System.Collections.Generic;
using System.Text;

namespace FreelanceHunt.Models
{
    public class ChatMessage
    {
        public string url { get; set; }
        public From from { get; set; }
        public From to { get; set; }
        public string message_html { get; set; }
        public string message_text { get; set; }
        public string post_time { get; set; }
    }
}
