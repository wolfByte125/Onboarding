namespace BlogDemo.DTOs.ReviewDTOs
{
    public class AddReviewDTO
    {
        public int UserId { get; set; }

        public int BlogPostId { get; set; }
        public string ReviewString { get; set; }

        public int? Rating { get; set; } = null;
    }
}
