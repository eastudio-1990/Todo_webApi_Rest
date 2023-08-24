using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Services;

namespace WebApplication1.Controllers
{
    [Route("api/ToDo/{ToDoId}/Categories/{CategoryId}")]
    [ApiController]
    public class ToDoCategoryController : ControllerBase
    {
        private readonly ToDoRepository _toDoRepository;

        public ToDoCategoryController(ToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
        [HttpPost]
        public IActionResult Post(int ToDoId,int CategoryId)
        {

            return Ok();
        }
    }
}
