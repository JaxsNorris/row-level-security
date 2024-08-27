namespace RowLevelSecuritySample.Models.Dto
{
    public class ApplicationDTO
    {
        public int ApplicationId { get; set; }
        public required string Description { get; set; }
        public required IList<ApplicationFileDto> ApplicationFiles { get; set; }

        internal static ApplicationDTO MapFrom(ApplicationModel model)
        {
            return new()
            {
                ApplicationId = model.ApplicationId,
                Description = model.Description,
                ApplicationFiles = model.ApplicationFiles.Select(f => ApplicationFileDto.MapFrom(f)).ToList(),
            };
        }
    }
}
