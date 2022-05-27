using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Services;
using TodoApi.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/TodoItems")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoServices _services;

        public TodoItemController(ITodoServices services)
        {
            _services = services;
        }

        // GET: api/<TodoItemController>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TodoItemModel> GetAll()
        {
            return _services.GetAll();            
        }

        // GET api/<TodoItemController>/5
        [HttpGet("{id}")]
        public TodoItemModel GetItem(int id)
        {           
            var item = _services.GetById(id);
            
            if (item == null)
            {
                // Not Found
                return null;
            }

            return item;
        }

        // POST api/<TodoItemController>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] TodoItemBaseModel value)
        {
            if(value == null)
                return BadRequest("Item null");

            var id = _services.CreateItem(value);

            return CreatedAtAction(nameof(GetItem), new {id = id }, id);

        }

        // PUT api/<TodoItemController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TodoItemBaseModel value)
        {
            var todoItem = _services.GetById(id);
            
            if (todoItem == null)
                return NotFound("Todo Item Not Found");            

            try { 
                _services.UpdateItem(id, value);
            }
            catch(Exception e)
            {
                return NotFound("Todo Item Not Found");
            }

            return NoContent();
        }

        // DELETE api/<TodoItemController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var todoItem = _services.GetById(id);
            if (todoItem == null) 
                return NotFound("Todo Item Not Found");

            try
            {
                _services.DeleteItem(id);
            }
            catch (Exception e)
            {
                return NotFound("Todo Item Not Found");
            }

            return NoContent();

        }
    }
}
