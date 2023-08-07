﻿using AutoMapper;
using BlogDemo.Contexts;
using BlogDemo.DTOs.BlogPostDTOs;
using BlogDemo.DTOs.ReviewDTOs;
using BlogDemo.DTOs.ReviewDTOs;
using BlogDemo.DTOs.UserDTOs;
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
            // BLOG POST
            CreateMap<CreateBlogPostDTO, BlogPost>();
            CreateMap<UpdateBlogPostDTO, BlogPost>();

            // USER
            CreateMap<AddUserDTOs, User>();
            CreateMap<UpdateUserDTO, User>();

            // REVIEW
            CreateMap<AddReviewDTO,  Review>();
            CreateMap<UpdateReviewDTO,  Review>();
        }
    }
}
