﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Infrastracture.Contracts;
using Serilog;
using Masking.Serilog;
using Microsoft.Extensions.Configuration;

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
            //serilog config / i use masking.serilog
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();

            Log.Logger = new LoggerConfiguration()
                 .ReadFrom.Configuration(configuration)
                 .Destructure.ByMaskingProperties(opts =>
                 {
                     opts.PropertyNames.Add("email");
                     opts.Mask = "******";
                 })
                 .CreateLogger();
            //end serilog config

            //get request
            var emp = _services.FindAll();
            return Ok(emp);
            //end get request
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
                Log.Information("Post Request on {@TaskList}", new TaskList
                {
                    idTask = TaskLists.idTask,
                    taskName = TaskLists.taskName,
                    taskDetails = TaskLists.taskDetails,
                    email = TaskLists.email
                }
                );

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
                Log.Information("Update Request on {@TaskList}", new TaskList 
                { 
                    idTask = TaskLists.idTask,
                    taskName = TaskLists.taskName,
                    taskDetails = TaskLists.taskDetails,
                    email = TaskLists.email 
                }
                );

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