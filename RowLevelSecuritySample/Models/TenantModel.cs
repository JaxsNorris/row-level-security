using RowLevelSecuritySample.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowLevelSecuritySample.Models
{
    [Table("Tenant", Schema = DatabaseSchemaConstants.DefaultSchema)]
    public class TenantModel
    {
        [Key]
        public int TenantId { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Path { get; set; }

        public required ICollection<UserModel> Users { get; set; }
    }
}
