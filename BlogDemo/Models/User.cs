using BlogDemo.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Versioning;
using System.Text.Json.Serialization;

namespace BlogDemo.Models
{
    public class User : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = null!;
        [RegularExpression(@"([0-9]){9}$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; } = null!;
        [NotMapped]
        public string Password { get; set; } = null!;
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
