
namespace CRUD_Project.BL.Dtos
{
    public class AddItemDto
    {
        public string Task { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
    }
}