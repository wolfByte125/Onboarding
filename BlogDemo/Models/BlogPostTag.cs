using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogDemo.Models
{
    public class BlogPostTag
    {
        [Key]
        public int Id { get; set; }
        public BlogPost? BlogPost { get; set; }
        [ForeignKey("BlogPost")]
        public int BlogPostId { get; set; }
        public Tag? Tag { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
    }
}
