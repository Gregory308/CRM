using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    [Table("Notifications", Schema = "CRM")]
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }
        [Required]
        [MaxLength(512)]
        public string Description { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }

    }
}
