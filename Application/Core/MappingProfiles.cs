using Application.Dtos;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PostDto, Post>();
            CreateMap<Post, PostDto>();
            CreateMap<Score, ScoreDto>();
        }
    }
}
