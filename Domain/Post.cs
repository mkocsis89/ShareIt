namespace Domain
{
    public sealed class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public ICollection<Score> Scores { get; set; } = new List<Score>();
    }
}
