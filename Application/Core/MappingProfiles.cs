using Application.Dtos;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreatePostDto, Post>();

            CreateMap<EditPostDto, Post>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // TODO
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.SpecialParts, opt => opt.Ignore());
        }
    }
}
