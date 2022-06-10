using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Services.Interfaces
{
    public interface ITodoServices
    {
        //api/TodoItems
        public Task<List<TodoItemModel>> GetAll();
        public Task<int> CreateItem(TodoItemBaseModel item);

        //api/TodoItems/{id}
        // GET, PUT, DELETE
        public Task<TodoItemModel> GetById(int id);
        public Task UpdateItem(int id, TodoItemBaseModel item);
        public Task DeleteItem(int id);

    }
}
