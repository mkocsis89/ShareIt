using System.ComponentModel.DataAnnotations;

namespace Domain
{
    /// <remarks>
    /// Parts are unique entities that represents a predefined set of objects. They are not directly associated with any specific
    /// <see cref="Post"/>, but rather serve as selectable options that can be associated with a <see cref="Post"/> through the
    /// <see cref="PostPart"/> connector table. 
    /// </remarks>
    public sealed class Part
    {
        [Key]
        public uint DesignId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
