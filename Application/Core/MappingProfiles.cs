using Application.Dtos;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreatePostDto, Post>()
                .ForMember(dest => dest.SpecialParts, opt => opt.Ignore());

            CreateMap<EditPostDto, Post>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SpecialParts, opt => opt.Ignore());

            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.SpecialParts, opt =>
                {
                    opt.MapFrom(src => src.SpecialParts.Select(part =>
                        new PartDto { SerialNumber = part.SerialNumber }).ToArray());
                });
        }
    }
}
