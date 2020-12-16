using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Infrastracture.Contracts;

namespace CourseAPI.Controllers
{

    [Route("api/tasklist")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private ITaskListServices _services;
        public TaskListController(ITaskListServices services) => _services = services;

        [HttpGet]
        public IActionResult GetAll()
        {
            var emp = _services.FindAll();
            return Ok(emp);
        }

        [HttpGet("{id}")]       
        public IActionResult GetByID(int id)
        {
            var emp = _services.FindById(id);
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult CreateC([FromBody] TaskList TaskLists)
        {
            try
            {
                _services.Create(TaskLists);
                return StatusCode(200, "Successfully Created!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult UpdateTaskLists([FromBody] TaskList TaskLists)
        {
            try
            {
                _services.Update(TaskLists);
                return StatusCode(200, "Successfully Updated!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTaskLists(int id)
        {
            try
            {
                var emp = _services.FindById(id);
                _services.Remove(emp);
                return StatusCode(200, "Successfully Updated!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}