using BlogDemo.Utils;
using System.ComponentModel.DataAnnotations;

namespace BlogDemo.Models
{
    public class BlogPost : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
