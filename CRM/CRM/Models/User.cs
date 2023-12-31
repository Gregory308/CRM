﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    [Table("Users", Schema = "CRM")]
    public class User
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
        public string Role { get; set; }
        [Required]
        [MaxLength(128)]
        public string Login { get; set; }
        [Required]
        [MaxLength(128)]
        public string Password { get; set; }
        public List<Notification>? Notifications { get; } = new();
    }
}
