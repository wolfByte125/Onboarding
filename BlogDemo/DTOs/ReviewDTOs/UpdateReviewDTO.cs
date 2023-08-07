namespace BlogDemo.DTOs.ReviewDTOs
{
    public class UpdateReviewDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlogPostId { get; set; }
        public string ReviewString { get; set; } = string.Empty;

        public int? Rating { get; set; } = null;
    }
}
