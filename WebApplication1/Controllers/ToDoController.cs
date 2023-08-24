using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Entities;
using WebApplication1.Models.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoRepository _toDoRepository;

        public ToDoController(ToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        // GET: api/<ToDoController>
        [HttpGet]
        public IActionResult Get()
        {
            var todoList = _toDoRepository.GetAll().Select(todo =>
            new ToDoItemDto
            {
                Id = todo.Id,
                InsertTine = todo.InsertTime,
                Text = todo.Text,
                Links = new List<Links>()
                {
                    new Links
                    {
                        Href=Url.Action(nameof(Get),"ToDo",new {todo.Id},Request.Scheme),
                        Rel="Self",
                        Method="GET"
                    },
                      new Links
                    {
                        Href=Url.Action(nameof(Delete),"ToDo",new {todo.Id},Request.Scheme),
                        Rel="Delete",
                        Method="Delete"
                    },
                      new Links
                    {
                        Href=Url.Action(nameof(Put),"ToDo",Request.Scheme),
                        Rel="Update",
                        Method="Put"
                    }
                }
            }).ToList();

            return Ok(todoList);
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var todo = _toDoRepository.GetById(id);

            return Ok(new ToDoItemDto
            {
                Id = todo.Id,
                InsertTine = todo.InsertTime,
                Text = todo.Text
            });
        }

        // POST api/<ToDoController>
        [HttpPost]
        public IActionResult Post([FromBody] ItemDto item)
        {
            var result = _toDoRepository.Add(new AddToDoDto()
            {
                ToDo = new ToDoDTO()
                {
                    Text = item.Text,
                }
            });

            string url = Url.Action(nameof(Get), "ToDo", new { Id = result.ToDo.Id }, Request.Scheme);

            return Created(url, result);
        }

        // PUT api/<ToDoController>/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] EditToDoDto value)
        {
            var result = _toDoRepository.Edit(value);
            return Ok(result);
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _toDoRepository.Delete(id);
            return Ok(result);
        }
    }
}
