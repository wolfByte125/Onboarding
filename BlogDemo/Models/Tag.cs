using System.ComponentModel.DataAnnotations;

namespace BlogDemo.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<BlogPost>? BlogPosts { get; set; }
    }
}
