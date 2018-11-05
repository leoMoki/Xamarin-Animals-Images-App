namespace ImagesApp.Services.Models
{
    public class Breed
    {
        public int id { get; set; }
        public string name { get; set; }
        public string life_span { get; set; }
        public string breed_group { get; set; }
        public string temperament { get; set; }
        public Weight weight { get; set; }
        public Height height { get; set; }
    }
}