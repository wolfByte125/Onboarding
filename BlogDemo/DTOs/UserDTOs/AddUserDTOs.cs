namespace BlogDemo.DTOs.UserDTOs
{
    public class AddUserDTOs
    {
        public string UserName { get; set; } = string.Empty;
        public string? FullName { get; set; } = String.Empty;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
