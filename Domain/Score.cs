namespace Domain
{
    public enum ScoreType
    {
        Creativity,
        Uniqueness
    }

    public sealed class Score
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        // TODO UserId
        public ScoreType Type { get; set; }
    }
}
