namespace BlogDemo.DTOs.ReviewDTOs
{
    public class NewUpdateReviewDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string ReviewString { get; set; }

        public int? Rating { get; set; } = null;
    }
}
