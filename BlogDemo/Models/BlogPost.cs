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
        public List<Review> Reviews { get; set; } = new();
        public List<Tag> Tags { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // decimal : 128 bits
        // double : 64 bits
        
        // CALCULATED FIELDS
        public int Count => Reviews.Count();

        public double Sum => (Count != 0) 
            ? 
            (Double) (Reviews?.Sum(nr => nr.Rating) ?? 0) 
            :
            0;

        public double Rating => Count != 0
            ?
            Math.Round(Sum / Count, 1)
            :
            0;
    }
}
