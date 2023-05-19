using Application.Posts.Dtos;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PostDto, Post>();
         
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.SpecialParts, opt =>
                {
                    opt.MapFrom(src => src.SpecialParts.Select(part =>
                        new PartDto { SerialNumber = part.SerialNumber }).ToArray());
                });
        }
    }
}
