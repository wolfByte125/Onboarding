namespace BlogDemo.DTOs.NewReviewDTOs
{
    public class NewAddReviewDTO
    {
        public int UserId { get; set; }

        public int BlogId { get; set; }
        public string ReviewString { get; set; }

        public int? Rating { get; set; } = null;
    }
}
