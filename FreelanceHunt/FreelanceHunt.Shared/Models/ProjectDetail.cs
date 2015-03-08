using System;
using System.Collections.Generic;
using System.Text;

namespace FreelanceHunt.Models
{

    public class ProjectDetail: Project
    {
        public Dictionary<ushort, string> payment_types { get; set; }
        public List<string> tags { get; set; }
    }
}
