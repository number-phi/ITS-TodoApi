using System.Collections.Generic;
using TodoApi.Models;
using TodoApi.Services.Interfaces;
using TodoApi.Data;
using System.Linq;
using System;
using TodoApi.Data.Entities;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> CreateItem(TodoItemBaseModel item)
        {
            var entity = _mapper.Map<TodoItem>(item);
            _context.TodoItems.Add(entity);            
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteItem(int id)
        {
            var item = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new Exception("Item Not Found");
            }

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TodoItemModel>> GetAll()
        {
            var list = await _context.TodoItems.ToListAsync();

            var listModel = new List<TodoItemModel>();

            foreach (var item in list)
            {               
                listModel.Add(_mapper.Map<TodoItemModel>(item));
            }

            return listModel;
        }

        public async Task<TodoItemModel> GetById(int id)
        {
            var item = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<TodoItemModel>(item);
        }

        public async Task UpdateItem(int id, TodoItemBaseModel item)
        {
            var itemFound = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            if (itemFound == null)
                throw new System.Exception("Item Not Found");

            itemFound.Name = item.Name;
            itemFound.IsCompleted = item.IsCompleted;
            _context.TodoItems.Update(itemFound);
            await _context.SaveChangesAsync();
        }
    }
}
