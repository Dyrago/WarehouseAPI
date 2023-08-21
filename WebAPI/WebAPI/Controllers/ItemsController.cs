using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.DTO;
using WebAPI.Application.DTO.DTOs;
using WebAPI.Application.Services.Items;
using WebAPI.Domain.Entities;

namespace WebAPI.Controllers
{
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Item))]
        [Route("api/[controller]")]
        public IActionResult GetAll()
        {
            var items = _itemService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(items);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Item))]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            var item = _itemService.GetById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Item))]
        [Route("api/[controller]")]
        public IActionResult Post([FromBody] ItemDTO item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _itemService.Add(DTOConverter.DTOToItem(item));
            return Ok("Item sucessfully added!");
        }

        //[HttpPost]
        //[ProducesResponseType(200, Type = typeof(Item))]
        //[Route("api/[controller]/{id}")]
        //public IActionResult Delete(int id)
        //{

        //    var item = _itemService.GetById(id);
        //    if (item != null)
        //        _itemService.Delete(i => i == id)

        //}

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult Update(int id, [FromBody] ItemDTO item)
        {
            if (item == null)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var itemExist = _itemService.GetById(id);

            if (itemExist != null)
            {
                var updtItem = DTOConverter.DTOToItem(item);
                updtItem.Id = id;   
                _itemService.Update(updtItem);
            }

            return Ok("Item updated!");
        }
    }
}
