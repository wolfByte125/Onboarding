using BlogDemo.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogDemo.Models
{
    public class Review : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public User? User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public BlogPost? BlogPost { get; set; }
        
        [ForeignKey("BlogPost")]
        public int BlogPostId { get; set; }
        public string ReviewString { get; set; } = string.Empty;

        public int? Rating { get; set; } = null;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
