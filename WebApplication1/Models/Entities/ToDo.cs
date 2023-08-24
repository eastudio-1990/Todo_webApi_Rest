﻿namespace WebApplication1.Models.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime InsertTime { get; set; }
        public bool IsRemoved { get; set; }
        public ICollection<Category> Categories{ get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ToDo> ToDos { get; set; }
    }
}
