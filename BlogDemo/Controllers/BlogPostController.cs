using BlogDemo.DTOs.BlogPostDTOs;
using BlogDemo.Services.BlogPostServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;
        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        // CREATE BLOG POST
        [HttpPost]
        public async Task<ActionResult> CreateBlogPost(CreateBlogPostDTO blogPostDTO)
        {
            try
            {
                return Ok(await _blogPostService.CreateBlogPost(blogPostDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // DELETE BLOG POST
        [HttpDelete]
        public async Task<ActionResult> DeleteBlogPost(int id)
        {
            try
            {
                return Ok(await _blogPostService.DeleteBlogPost(id));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // GET ALL BLOG POSTS
        [HttpGet]
        public async Task<ActionResult> GetBlogPosts()
        {
            try
            {
                return Ok(await _blogPostService.GetBlogPosts());
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // GET SINGLE BLOG POST
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBlogPost(int id)
        {
            try
            {
                return Ok(await _blogPostService.GetBlogPost(id));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // UPDATE BLOG POST
        [HttpPut]
        public async Task<ActionResult> UpdateBlogPost(UpdateBlogPostDTO blogPostDTO)
        {
            try
            {
                return Ok(await _blogPostService.UpdateBlogPost(blogPostDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

    }
}
