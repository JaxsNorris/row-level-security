using RowLevelSecuritySample.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowLevelSecuritySample.Models
{
    [Table("Application", Schema = DatabaseSchemaConstants.DefaultSchema)]
    public class ApplicationModel
    {
        [Key]
        public int ApplicationId { get; set; }

        [Required]
        public int TenantId { get; set; }
        public required TenantModel Tenant { get; set; }

        [Required]
        public required string Description { get; set; }

        public required ICollection<ApplicationFileModel> ApplicationFiles { get; set; }
    }
}
