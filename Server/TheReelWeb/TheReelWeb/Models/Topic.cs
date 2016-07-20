using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheReelWeb.Models
{
    [Table("Topic")]
    public class Topic
    {
        public int id { get; set; }
        public string name { get; set; } 
        public string description { get; set; }
        public string image { get; set; }
    }
}