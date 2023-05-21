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
            CreateMap<EditPostDto, Post>();
            CreateMap<Post, PostDto>();
            CreateMap<Score, ScoreDto>();
        }
    }
}
