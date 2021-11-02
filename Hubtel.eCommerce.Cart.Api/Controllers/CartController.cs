using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hubtel.eCommerce.Cart.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Hubtel.eCommerce.Cart.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    //[ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly Data.ECommerceDbContext _context;

        public CartController(ILogger<CartController> logger, Data.ECommerceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Models.Cart item)
        {
            //if (item is null)
            //    ModelState.AddModelError("", "Invalid cart model.");

            //if (item?.ItemId <= 0)
            //    ModelState.AddModelError("", "Invalid item ID.");

            //if (string.IsNullOrWhiteSpace(item?.ItemName))
            //    ModelState.AddModelError("", "Invalid item name.");

            //if (string.IsNullOrWhiteSpace(item?.PhoneNumber))
            //    ModelState.AddModelError("", "Invalid customer phone number provided.");

            //if (item?.Quantity <= 0)
            //    ModelState.AddModelError("", "Invalid quantity supplied.");

            try
            {
                if (ModelState.IsValid)
                {
                    var existingitem = await _context.Items.FirstOrDefaultAsync(i=> i.ItemId == item.ItemId && i.PhoneNumber == item.PhoneNumber);
                    if (existingitem != null)
                    {
                        existingitem.Quantity += item?.Quantity ?? 0;
                        existingitem.Time = DateTime.UtcNow;
                        _context.Items.Update(existingitem);
                    }
                    else
                    {
                        if (item?.Time == null)
                            item.Time = DateTime.UtcNow;

                        _context.Items.Add(item);
                    }

                    _context.SaveChanges();
                    
                    var result = await _context.Items.FirstOrDefaultAsync(i => i.ItemId == item.ItemId && i.PhoneNumber == item.PhoneNumber);

                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                ModelState.AddModelError("", e.Message);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}/{phonenumber}")]
        public async Task<IActionResult> Delete(int? id, string phonenumber)
        {
            if (id != null && !string.IsNullOrWhiteSpace(phonenumber))
            {
                var item = await _context.Items.FirstOrDefaultAsync(i => i.ItemId == id && i.PhoneNumber == phonenumber);
                if (item != null)
                {
                    _context.Items.Remove(item);
                    _context.SaveChanges();
                    return Ok();
                }

                return NotFound();
            }

            return BadRequest(id == null && string.IsNullOrWhiteSpace(phonenumber)
                ? "Item & Phone number parameters is empty."
                : id == null
                    ? "Item parameter is empty."
                    : string.IsNullOrWhiteSpace(phonenumber)
                        ? "Phone number parameter is empty."
                        : string.Empty);
        }

        [HttpGet("{id}/{phonenumber}")]
        public async Task<ActionResult<Models.Cart>> Get(int? id, string phonenumber)
        {
            var items = await _context.Items.ToArrayAsync();

            if (id != null && !string.IsNullOrWhiteSpace(phonenumber))
            {
                var item = items?.FirstOrDefault(i => i.ItemId == id && i.PhoneNumber == phonenumber);
                if (item != null)
                    return Ok(item);

                return NotFound();
            }

            return BadRequest(id == null && string.IsNullOrWhiteSpace(phonenumber)
                ? "Item & Phone number parameters is empty."
                : id == null
                    ? "Item parameter is empty."
                    : string.IsNullOrWhiteSpace(phonenumber)
                        ? "Phone number parameter is empty."
                        : string.Empty);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string phonenumber, DateTime? time, int? quantity, int? item)
        {
            var items = await _context.Items.ToArrayAsync();

            var filtereditems = items
                .Where(i =>
                (string.IsNullOrWhiteSpace(phonenumber) || i.PhoneNumber == phonenumber) ||
                (time == null || i.Time == time) || (item == null || i.ItemId == item) ||
                (quantity == null || i.Quantity == quantity));

            if (filtereditems?.Count() > 0)
                return Ok(filtereditems);

            return NoContent();
        }
    }
}
