using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Infrastracture.Contracts;

namespace CourseAPI.Controllers
{

    [Route("api/itemlist")]
    [ApiController]
    public class ItemListController : ControllerBase
    {
        private IItemListServices _services;
        public ItemListController(IItemListServices services) => _services = services;

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
        public IActionResult CreateC([FromBody] ItemList ItemList)
        {
            try
            {
                _services.Create(ItemList);
                return StatusCode(200, "Successfully Created!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult UpdateItems([FromBody] ItemList ItemList)
        {
            try
            {
                _services.Update(ItemList);
                return StatusCode(200, "Successfully Updated!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItems(int id)
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