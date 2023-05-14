namespace Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Part> SpecialParts { get; set; } = new List<Part>();
        public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
    }
}
