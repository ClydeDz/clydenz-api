using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace clydenz_api.Models
{
    public class UrlMapping
    {
        public int ID { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }

        [JsonIgnore]
        public virtual ICollection<UrlHits> UrlHits { get; set; }
    }
}
