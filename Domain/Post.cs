namespace Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public ICollection<Part> SpecialParts { get; set; } = new List<Part>();
        public ICollection<Score> Scores { get; set; } = new List<Score>();
    }
}
