namespace WebApplication1.Models.Entities
{
    public class ToDoItemDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime InsertTine { get; set; }
        public List<Links> Links { get; set; }
    }
}
