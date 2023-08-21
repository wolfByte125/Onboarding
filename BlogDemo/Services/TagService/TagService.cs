using AutoMapper;
using BlogDemo.Contexts;
using BlogDemo.Models;

namespace BlogDemo.Services.TagService
{
    public class TagService : ITagService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TagService(DataContext dataContext, IMapper imapper)
        {
            _context = dataContext;
            _mapper = imapper; 
        }

        public async Task<Tag> CreateTag(string tagName)
        {
            Tag tag = new();

            tag.Name = tagName;

            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return tag;
        }
    }
}
