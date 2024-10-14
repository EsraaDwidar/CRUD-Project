
namespace CRUD_Project.BL.Dtos
{
    public class ItemsDto
    {
        public int Id { get; set; }
        public string Task { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
    }
}