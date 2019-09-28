using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_net_academy_asp_mvc.Models.Entity
{
    public class Marker
    {
        public int Id { get; set; }
        public char Label { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
    }
}
