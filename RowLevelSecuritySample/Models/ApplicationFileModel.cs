using RowLevelSecuritySample.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowLevelSecuritySample.Models
{
    [Table("ApplicationFile", Schema = DatabaseSchemaConstants.DefaultSchema)]
    public class ApplicationFileModel
    {
        [Key]
        public int ApplicationFileId { get; set; }
        [Required]
        public required string Filename { get; set; }

        public int ApplicationId { get; set; }
        [Required]
        public required ApplicationModel Application { get; set; }
    }
}
