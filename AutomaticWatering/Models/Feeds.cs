using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomaticWatering.Models
{
    public class Feeds
    {
        public int EntryId { get; set; }
        public DateTime CreateTime { get; set; }
        public int Field1 { get; set; }
        public int Field2 { get; set; }
    }
}