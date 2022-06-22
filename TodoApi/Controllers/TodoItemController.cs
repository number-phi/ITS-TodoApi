using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Services;
using TodoApi.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Authorize]
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
        public async Task<ActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return Ok(result);
        }

        // GET api/<TodoItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetItem(int id)
        {           
            var item = await _services.GetById(id);
            
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST api/<TodoItemController>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TodoItemBaseModel value)
        {
            if(value == null)
                return BadRequest("Item null");

            var id = await _services.CreateItem(value);

            return CreatedAtAction(nameof(GetItem), new {id = id }, id);

        }

        // PUT api/<TodoItemController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TodoItemBaseModel value)
        {
            var todoItem = await _services.GetById(id);
            
            if (todoItem == null)
                return NotFound("Todo Item Not Found");            

            try { 
                await _services.UpdateItem(id, value);
            }
            catch(Exception e)
            {
                return NotFound("Todo Item Not Found");
            }

            return NoContent();
        }

        // DELETE api/<TodoItemController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var todoItem = await _services.GetById(id);
            if (todoItem == null) 
                return NotFound("Todo Item Not Found");

            try
            {
                await _services.DeleteItem(id);
            }
            catch (Exception e)
            {
                return NotFound("Todo Item Not Found");
            }

            return NoContent();

        }
    }
}
