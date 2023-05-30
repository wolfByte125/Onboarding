using BlogDemo.DTOs.BlogPostDTOs;
using BlogDemo.Models;

namespace BlogDemo.Services.BlogPostServices
{
    public interface IBlogPostService
    {
        Task<List<BlogPost>> GetBlogPosts();
        Task<BlogPost> GetBlogPost(int id);
        Task<BlogPost> CreateBlogPost(CreateBlogPostDTO blogPostDTO);
        Task<BlogPost> UpdateBlogPost(UpdateBlogPostDTO blogPostDTO);
        Task<BlogPost> DeleteBlogPost(int id);

    }
}
