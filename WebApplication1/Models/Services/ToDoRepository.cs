using WebApplication1.Models.Context;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.Services
{
    public class ToDoRepository
    {
        private readonly DataBaseContext _context;

        public ToDoRepository(DataBaseContext dataBase)
        {
            _context = dataBase;
        }

        public List<ToDoDTO> GetAll()
        {
            return _context.Todos.Select(p => new ToDoDTO
            {
                Id = p.Id,
                InsertTime = p.InsertTime,
                IsRemoved = p.IsRemoved,
                Text = p.Text
            }).ToList();
        }

        public ToDoDTO GetById(int id)
        {
            var todo = _context.Todos.SingleOrDefault(p => p.Id == id); ;
            if (todo == null)
            {
                return new ToDoDTO
                {
                    Id = 0,
                    InsertTime = DateTime.Now,
                    IsRemoved = true,
                    Text = ""
                };
            }
            return new ToDoDTO
            {
                Id = todo.Id,
                InsertTime = todo.InsertTime,
                IsRemoved = todo.IsRemoved,
                Text = todo.Text
            };
        }

        public AddToDoDto Add(AddToDoDto dto)
        {
            ToDo newTodo = new ToDo()
            {
                InsertTime = DateTime.Now,
                Text = dto.ToDo.Text,
                Id = dto.ToDo.Id,
                IsRemoved = false,
            };

            foreach (var item in dto.Categories)
            {
                var category = _context.Categories.SingleOrDefault(p => p.Id == item);
                newTodo.Categories.Add(category);
            }

            _context.Add(newTodo);
            _context.SaveChanges();
            return new AddToDoDto
            {
                ToDo = new ToDoDTO
                {
                    Id = newTodo.Id,
                    InsertTime = newTodo.InsertTime,
                    IsRemoved = newTodo.IsRemoved,
                    Text = newTodo.Text
                },
                Categories=dto.Categories                
            };
        }

        public bool Delete(int Id)
        {
            //_context.Todos.Remove(new ToDo { Id = Id });
            var todo = _context.Todos.Find(Id);
            todo.IsRemoved = true;
            _context.SaveChanges();
            return true;
        }

        public bool Edit(EditToDoDto toDo)
        {
            var todo = _context.Todos.SingleOrDefault(p => p.Id == toDo.Id);
            todo.Text = toDo.Text;
            _context.SaveChanges();
            return true;
        }

    }


    public class ToDoDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime InsertTime { get; set; }
        public bool IsRemoved { get; set; }
        public ICollection<Category> Categories { get; set; }
    }

    public class AddToDoDto
    {
        public ToDoDTO ToDo { get; set; }
        public List<int> Categories { get; set; } = new List<int>();
    }

    public class EditToDoDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<int> Categories { get; set; }
    }
}
