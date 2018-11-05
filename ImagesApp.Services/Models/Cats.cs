using System.Collections.Generic;

namespace ImagesApp.Services.Models
{
    public class Cats
    {
        public List<Breed> breeds { get; set; }
        public List<object> categories { get; set; }
        public string id { get; set; }
        public string url { get; set; }
    }
}
