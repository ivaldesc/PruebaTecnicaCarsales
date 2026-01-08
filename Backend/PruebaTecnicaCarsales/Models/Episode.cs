namespace PruebaTecnicaCarsales.Models
{
    public class Episode
    {
        public int id { get; set; }
        public string name { get; set; }
        public string air_date { get; set; }
        public string episode { get; set; }
        public List<string> characters { get; set; } = new();
        //public List<string> CharactersNames { get; set; }
        public string url { get; set; }
        public string created { get; set; }
    }

    public class EpisodeInfo
    {
        public int count { get; set; }
        public int pages { get; set; }
        public string? next { get; set; }
        public string? previous { get; set; }
    }

    public class EpisodeResponse
    {
        public EpisodeInfo info { get; set; }
        public List<Episode> results { get; set; }
    }

    public class EpisodeDetails
    {
        public Episode episode { get; set; }
        public List<Character> charactersDetails { get; set; }
    }
}
