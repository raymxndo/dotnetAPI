using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Candidate
    {
        public int candidate_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone_num { get; set; }
        public string address_ { get; set; }
        public string country { get; set; }
    }
}
