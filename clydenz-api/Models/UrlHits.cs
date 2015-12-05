using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace clydenz_api.Models
{
    public class UrlHits
    {
        public int ID { get; set; }
        public int UrlMappingID { get; set; } // foreign key
        public string Country { get; set; }
        public string OperatingSystem { get; set; }

        [JsonIgnore]
        public virtual UrlMapping UrlMapping { get; set; }
    }
}
