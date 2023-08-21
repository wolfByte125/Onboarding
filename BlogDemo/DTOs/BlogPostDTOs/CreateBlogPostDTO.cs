namespace BlogDemo.DTOs.BlogPostDTOs
{
    public class CreateBlogPostDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        // Tags is a Comma Separated Value
        public string TagsCSV { get; set; } = string.Empty;
    }
}
