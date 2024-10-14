using CRUD_Project.DAL;
using CRUD_Project.BL.Dtos;


namespace CRUD_Project.BL
{
    public class ItemManager : IItemsManager
    {
        private readonly IItemsRepo _itemsRepo;
        //private readonly ItemsContext _itemsContext;

        public ItemManager(IItemsRepo itemsRepo)
        {
            _itemsRepo = itemsRepo;
        }

        public IEnumerable<ItemsDto> GetAll()
        {
            IEnumerable<Items> items = _itemsRepo.GetAll();
            return items.Select(x => new ItemsDto
            {
                Id = x.Id,
                Task = x.Task,
                IsDone = x.IsDone,
            });
        }

        public ItemsDto GetById(int id)
        {
            Items item = _itemsRepo.GetById(id);
            if (item == null)
            {
                return null;
            }
            return new ItemsDto
            {
                Id = item.Id,
                Task = item.Task,
                IsDone = item.IsDone,
            };
        }

        public int Add(AddItemDto itemToAdd)
        {
            Items item = new Items
            {
                Task = itemToAdd.Task,
                IsDone = itemToAdd.IsDone,
            };
            _itemsRepo.Add(item);
            _itemsRepo.SaveChanges();
            return item.Id;
        }

        public bool Delete(int id)
        {
            Items item = _itemsRepo.GetById(id);
            if (item == null)
            {
                return false;
            }
            _itemsRepo.Delete(item);
            _itemsRepo.SaveChanges();
            return true;
        }

        public bool Update(ItemsDto itemToUpdate)
        {
            Items item = _itemsRepo.GetById(itemToUpdate.Id);
            if (item == null)
            {
                return false;
            }
            item.Task = itemToUpdate.Task;
            item.IsDone = itemToUpdate.IsDone;
            _itemsRepo.Update(item);
            _itemsRepo.SaveChanges();
            return true;
        }
    }
}