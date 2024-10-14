
namespace CRUD_Project.DAL
{
    public interface IItemsRepo
    {
        IEnumerable<Items> GetAll();
        Items GetById(int id);
        void Add(Items item);
        void Update(Items item);
        void Delete(Items item);
        int Count();
        int SaveChanges();
    }
}
