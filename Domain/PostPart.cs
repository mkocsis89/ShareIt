namespace Domain
{
    /// <remarks>
    /// Connector table (junction table) to represent a many-many relationship between <see cref="Post"/> and <see cref="Part"/>.
    /// Cascading delete is configured at the DataBase level thus ensuring that the associated <see cref="PostPart"/> records are
    /// automatically deleted when a related <see cref="Post"/> or <see cref="Part"/> entity is deleted.
    /// </remarks>
    public sealed class PostPart
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public uint PartId { get; set; }
        public Part Part { get; set; }
    }
}
