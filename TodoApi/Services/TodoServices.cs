using System.Collections.Generic;
using TodoApi.Models;
using TodoApi.Services.Interfaces;
using TodoApi.Data;
using System.Linq;
using System;
using TodoApi.Data.Entities;
using AutoMapper;

namespace TodoApi.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public TodoServices(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int CreateItem(TodoItemBaseModel item)
        {
            var entity = _mapper.Map<TodoItem>(item);
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
                listModel.Add(_mapper.Map<TodoItemModel>(item));
            }

            return listModel;
        }

        public TodoItemModel GetById(int id)
        {
            var item = _context.TodoItems.FirstOrDefault(x => x.Id == id);

            return _mapper.Map<TodoItemModel>(item);
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
