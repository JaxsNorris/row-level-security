namespace RowLevelSecuritySample.Models.Dto
{
    public class ApplicationFileDto
    {
        public int ApplicationFileId { get; set; }
        public required string Filename { get; set; }

        internal static ApplicationFileDto MapFrom(ApplicationFileModel model)
        {
            return new()
            {
                ApplicationFileId = model.ApplicationFileId,
                Filename = model.Filename,
            };
        }
    }
}
