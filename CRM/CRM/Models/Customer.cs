using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    [Table("Customers", Schema = "CRM")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(128)]
        public string Email { get; set; }
        [Required]
        [MaxLength(128)]
        public string Login { get; set; }
        [Required]
        [MaxLength(128)]
        public string Password { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
    }
}
