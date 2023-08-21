using AutoMapper;
using BlogDemo.Contexts;
using BlogDemo.DTOs.BlogPostDTOs;
using BlogDemo.Models;
using BlogDemo.Services.HelperServices;
using BlogDemo.Services.TagService;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo.Services.BlogPostServices
{
    public class BlogPostService : IBlogPostService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;
        private readonly IHelperService _helperService;

        public BlogPostService(DataContext context, IMapper mapper, 
            ITagService tagService, IHelperService helperService)
        {
            _context = context;
            _mapper = mapper;
            _tagService = tagService;
            _helperService = helperService;
        }

        public async Task<BlogPost> CreateBlogPost(CreateBlogPostDTO blogPostDTO)
        {
            var blogPost = _mapper.Map<BlogPost>(blogPostDTO);

            blogPost.Tags = await TagExtraction(blogPostDTO.TagsCSV);

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
                .Include(bp => bp.Reviews)
                .Include(bp => bp.Tags)
                .FirstOrDefaultAsync();

            if (blogPost == null) throw new KeyNotFoundException("Blog Post Not Found.");

            return blogPost;
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            var blogPosts = await _context.BlogPosts
                .Include(bp=>bp.Tags)
                .Include(bp => bp.Reviews)
                    .ThenInclude(nr => nr.User)
                .OrderByDescending(bp => bp.UpdatedAt)
                .ToListAsync();

            return blogPosts;
        }

        public async Task<BlogPost> UpdateBlogPost(UpdateBlogPostDTO blogPostDTO)
        {
            var blogPost = await _context.BlogPosts
                .Where(bp => bp.Id == blogPostDTO.Id)
                .Include(bp => bp.Tags)
                .FirstOrDefaultAsync()
                ?? 
                throw new KeyNotFoundException("Blog Post Not Found.");

            List<string> tags = await _helperService.CSVExtract(blogPostDTO.TagsCSV);

            blogPost = _mapper.Map(blogPostDTO, blogPost);

            blogPost.Tags = new();

            blogPost.Tags = await TagExtraction(tags);

            _context.BlogPosts.Update(blogPost);
            await _context.SaveChangesAsync();

            return blogPost;
        }

        public async Task<List<Tag>> TagExtraction(string csv)
        {
            List<Tag> tags = new List<Tag>();

            List<string> extracted = await _helperService.CSVExtract(csv);

            extracted = MakeDistinct(extracted);

            foreach (string tagName in extracted)
            {
               var tag = await _context.Tags
                    .Where(t => t.Name.ToLower() == tagName.Trim().ToLower())
                    .FirstOrDefaultAsync()
                    ??
                    await _tagService.CreateTag(tagName);
                
                tags.Add(tag);
            }
            
            return tags;
        }
        
        public async Task<List<Tag>> TagExtraction(List<string> tagsList)
        {
            List<Tag> tags = new List<Tag>();

            tagsList = MakeDistinct(tagsList);

            foreach (string tagName in tagsList)
            {
               var tag = await _context.Tags
                    .Where(t => t.Name.ToLower() == tagName.Trim().ToLower())
                    .FirstOrDefaultAsync()
                    ??
                    await _tagService.CreateTag(tagName);
                
                tags.Add(tag);
            }
            
            return tags;
        }

        public List<string> MakeDistinct(List<string> stringList)
        {
            return  stringList.Distinct().ToList();
        }
    }
}
