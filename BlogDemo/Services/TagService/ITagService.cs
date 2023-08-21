using BlogDemo.Models;

namespace BlogDemo.Services.TagService
{
    public interface ITagService
    {
        Task<Tag> CreateTag(string tagName);
    }
}