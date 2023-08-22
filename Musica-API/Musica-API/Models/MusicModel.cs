namespace Musica_API.Models
{
    public class MusicModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int YearRelease { get; set; } = 0;
        public double Duration { get; set; } = 0.0;
        public bool IsFavorite { get; set; }


    }
}
