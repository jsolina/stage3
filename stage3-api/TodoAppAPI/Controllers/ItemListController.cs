using Domain.Contracts;
using Domain.Models;
using Infrastracture.Contracts;
using Masking.Serilog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAppAPI.Controllers
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
            //serilog config / i use masking.serilog
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();

            Log.Logger = new LoggerConfiguration()
                 .ReadFrom.Configuration(configuration)
                 .Destructure.ByMaskingProperties(opts =>
                 {
                     opts.PropertyNames.Add("itemName");
                     opts.Mask = "******";
                 })
                 .CreateLogger();

            //end serilog config
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
        public IActionResult CreateC([FromBody] ItemListModel ItemLists)
        {
            try
            {
                Log.Information("Post Request on {@ItemList}", new ItemListModel
                {
                    idItem = ItemLists.idItem,
                    idTask = ItemLists.idTask,
                    itemName = ItemLists.itemName,
                    itemDetails = ItemLists.itemDetails,
                    itemStatus = ItemLists.itemStatus
                });

                _services.Create(ItemLists);
                return StatusCode(200, "Successfully Created!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult UpdateItems([FromBody] ItemListModel ItemLists)
        {
            try
            {
                Log.Information("Update Request on {@ItemList}", new ItemListModel
                {
                    idItem = ItemLists.idItem,
                    idTask = ItemLists.idTask,
                    itemName = ItemLists.itemName,
                    itemDetails = ItemLists.itemDetails,
                    itemStatus = ItemLists.itemStatus
                });

                _services.Update(ItemLists);
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
