namespace Opslagsværk_API.DTOs.AssignmentDTOs
{
    public class ReadAssignmentDTO
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
    }   
}
