using System;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Services.Interfaces
{
    public interface ITodoServices
    {
        //api/TodoItems
        public List<TodoItemModel> GetAll();
        public int CreateItem(TodoItemBaseModel item);

        //api/TodoItems/{id}
        // GET, PUT, DELETE
        public TodoItemModel GetById(int id);
        public void UpdateItem(int id, TodoItemBaseModel item);
        public void DeleteItem(int id);

    }
}
