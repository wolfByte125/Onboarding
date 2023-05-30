﻿using AutoMapper;
using BlogDemo.Contexts;
using BlogDemo.DTOs.BlogPostDTOs;
using BlogDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo.Services.BlogPostServices
{
    public class BlogPostService : IBlogPostService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BlogPostService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BlogPost> CreateBlogPost(CreateBlogPostDTO blogPostDTO)
        {
            var blogPost = _mapper.Map<BlogPost>(blogPostDTO);

            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();

            return blogPost;
        }

        public async Task<BlogPost> DeleteBlogPost(int id)
        {
            var blogPost = await _context.BlogPosts
                .Where(bp => bp.Id == id)
                .FirstOrDefaultAsync();

            if (blogPost == null) throw new KeyNotFoundException("Blog Post Not Found.");

            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();

            return blogPost;
        }

        public async Task<BlogPost> GetBlogPost(int id)
        {
            var blogPost = await _context.BlogPosts
                .Where(bp => bp.Id == id)
                .FirstOrDefaultAsync();

            if (blogPost == null) throw new KeyNotFoundException("Blog Post Not Found.");

            return blogPost;
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            var blogPosts = await _context.BlogPosts
                .OrderByDescending(bp => bp.Id)
                .ToListAsync();

            return blogPosts;
        }

        public async Task<BlogPost> UpdateBlogPost(UpdateBlogPostDTO blogPostDTO)
        {
            var blogPost = await _context.BlogPosts
                .Where(bp => bp.Id == blogPostDTO.Id)
                .FirstOrDefaultAsync();

            if (blogPost == null) throw new KeyNotFoundException("Blog Post Not Found.");

            blogPost = _mapper.Map(blogPostDTO, blogPost);

            _context.BlogPosts.Update(blogPost);
            await _context.SaveChangesAsync();

            return blogPost;
        }
    }
}
