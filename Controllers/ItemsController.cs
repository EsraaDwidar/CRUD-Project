using CRUD_Project.BL;
using CRUD_Project.BL.Dtos;
using CRUD_Project.DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Project.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsManager _itemsManager;

        public ItemsController(IItemsManager itemsManager)
        {
            _itemsManager = itemsManager;
        }
        
        // GET: api/<ItemsController>
        [HttpGet]
        public ActionResult<List<ItemsDto>> GetAll()
        {
            return _itemsManager.GetAll().ToList();
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public ActionResult<ItemsDto> GetById(int id)
        {
            var item = _itemsManager.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public  ActionResult Add(AddItemDto item)
        {

            var newUser = _itemsManager.Add(item);

            return CreatedAtAction(nameof(GetById), new { id = newUser },
                new Response ("item Added successfully" ));
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public ActionResult Update(ItemsDto item)
        {
            var itemToEdit = _itemsManager.Update(item);
            if (itemToEdit == null)
            {
                return NotFound();
            }
            return Ok(new Response("item Updated successfully"));
            
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemToDelete = _itemsManager.Delete(id);
            if (itemToDelete == null)
            {
                return NotFound();
            }
            return Ok(new Response("item Removed successfully"));
        }
    }
}
