using BlogDemo.Utils;
using System.ComponentModel.DataAnnotations;
namespace BlogDemo.Models
{
    public class NewReview : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string ReviewString { get; set; }

        public int? Rating { get; set; } = null;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
