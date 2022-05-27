using System.Collections.Generic;
using TodoApi.Models;
using TodoApi.Services.Interfaces;
using TodoApi.Data;
using System.Linq;
using System;
using TodoApi.Data.Entities;

namespace TodoApi.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly TodoContext _context;

        public TodoServices(TodoContext context)
        {
            _context = context;
        }

        private TodoItem ReflectionItem(TodoItemBaseModel item)
        {
            var newItem = new TodoItem();
            newItem.Name = item.Name;
            newItem.IsCompleted = item.IsCompleted;
            return newItem;
        }

        private TodoItemModel ReflectionItemModel(TodoItem item)
        {
            var newItem = new TodoItemModel();
            newItem.Id = item.Id;
            newItem.Name = item.Name;
            newItem.IsCompleted = item.IsCompleted;
            return newItem;
        }

        public int CreateItem(TodoItemBaseModel item)
        {
            var entity = ReflectionItem(item);
            _context.TodoItems.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public void DeleteItem(int id)
        {
            var item = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new Exception("Item Not Found");
            }

            _context.TodoItems.Remove(item);
            _context.SaveChanges();
        }

        public List<TodoItemModel> GetAll()
        {
            var list = _context.TodoItems.ToList();

            var listModel = new List<TodoItemModel>();

            foreach (var item in list)
            {
                listModel.Add(ReflectionItemModel(item));
            }

            return listModel;
        }

        public TodoItemModel GetById(int id)
        {
            var item = _context.TodoItems.FirstOrDefault(x => x.Id == id);

            return ReflectionItemModel(item);
        }

        public void UpdateItem(int id, TodoItemBaseModel item)
        {
            var itemFound = _context.TodoItems.FirstOrDefault(x => x.Id == id);

            if (itemFound == null)
                throw new System.Exception("Item Not Found");

            itemFound.Name = item.Name;
            itemFound.IsCompleted = item.IsCompleted;
            _context.TodoItems.Update(itemFound);
            _context.SaveChanges();

        }
    }
}
