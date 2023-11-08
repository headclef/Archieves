using System.ComponentModel.DataAnnotations;

namespace Archieves.Kutuphane.Models.User
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }

        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
