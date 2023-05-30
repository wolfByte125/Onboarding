using AutoMapper;
using BlogDemo.Contexts;
using BlogDemo.DTOs.BlogPostDTOs;
using BlogDemo.Models;

namespace Secretary_Job_Mgmt.Utils
{
    public class AutoMapperProfile : Profile
    {
        private readonly IMapper _mapper;

        public AutoMapperProfile(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
        }
        public AutoMapperProfile()
        {
            CreateMap<CreateBlogPostDTO, BlogPost>();
            CreateMap<UpdateBlogPostDTO, BlogPost>();
        }
    }
}
