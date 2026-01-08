namespace PruebaTecnicaCarsales.Models
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public LocationInfo origin { get; set; }
        public LocationInfo location { get; set; }
        public string image { get; set; }
        public string url { get; set; }
    }

    public class LocationInfo
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
