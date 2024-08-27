using RowLevelSecuritySample.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowLevelSecuritySample.Models
{
    [Table("User", Schema = DatabaseSchemaConstants.DefaultSchema)]
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public int TenantId { get; set; }
        public TenantModel Tenant { get; set; } = null!;
    }
}
