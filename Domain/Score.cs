namespace Domain
{
    public sealed class Score
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public int Creactivity { get; set; }
        public int Uniqueness { get; set; }
    }
}
