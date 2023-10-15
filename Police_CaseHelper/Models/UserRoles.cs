using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Police_CaseHelper.Models
{
    //[Table("AspNetUserRoles")]
    public class UserRoles
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        [Required]
        public string RoleId { get; set; }
    }
}
