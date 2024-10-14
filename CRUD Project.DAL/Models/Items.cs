using System.ComponentModel.DataAnnotations;

namespace CRUD_Project.DAL
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Task { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
        
    }
}
