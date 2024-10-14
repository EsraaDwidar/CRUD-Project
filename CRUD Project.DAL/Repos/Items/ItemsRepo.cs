

namespace CRUD_Project.DAL
{
    public class ItemsRepo : IItemsRepo
    {
        private readonly ItemsContext _context;
        public ItemsRepo(ItemsContext context)
        {
            _context = context;
        }

        public IEnumerable<Items> GetAll()
        {
            return _context.Set<Items>();
        }

        public Items GetById(int id)
        {
            return _context.Set<Items>().FirstOrDefault(x => x.Id == id);
        }

        public void Add(Items item)
        {
            _context.Set<Items>().Add(item);
        }

        public void Delete(Items item)
        {
            _context.Set<Items>().Remove(item);
        }

        public void Update(Items item)
        {
            
        }

        public int Count()
        {
            return _context.Set<Items>().Count();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

    }
}
