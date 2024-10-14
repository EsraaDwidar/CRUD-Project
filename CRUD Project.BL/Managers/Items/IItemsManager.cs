using CRUD_Project.BL.Dtos;

namespace CRUD_Project.BL
{
    public interface IItemsManager
    {
        IEnumerable<ItemsDto> GetAll();
        ItemsDto GetById(int id);
        int Add(AddItemDto item);
        bool Update(ItemsDto item);
        bool Delete(int id);
    }
}
