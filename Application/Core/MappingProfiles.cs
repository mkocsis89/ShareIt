using AutoMapper;
using Domain;

namespace Application.Core
{
    public sealed class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Post, Post>()
                .ForMember(dest => dest.SpecialParts, opt => opt.Ignore()) // Exclude SpecialParts from automatic mapping
                .AfterMap((source, destination, context) =>
                {
                    foreach (var sourcePart in source.SpecialParts)
                    {
                        var matchingPart = destination.SpecialParts.FirstOrDefault(destChild => destChild.Name == sourcePart.Name);

                        if (matchingPart == null)
                            destination.SpecialParts.Add(sourcePart);
                    }
                });
        }
    }
}
