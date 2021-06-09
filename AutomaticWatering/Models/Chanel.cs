using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomaticWatering.Models
{
    public class Chanel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public int Last_Entry_Id { get; set; }
    }
}