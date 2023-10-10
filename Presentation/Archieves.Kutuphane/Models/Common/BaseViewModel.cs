using System.ComponentModel.DataAnnotations;

namespace Archieves.Kutuphane.Models.Common
{
    public class BaseViewModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
