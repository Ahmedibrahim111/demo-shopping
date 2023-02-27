using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularApp.Models;
using PaymentAPI.Models;
using AngularApp.VM;
using System.IO;
using System.Net.Http.Headers;

namespace AngularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemMangementsController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public ItemMangementsController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/ItemMangements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemMangement>>> GetitemMangements()
        {
            return await _context.itemMangements.OrderBy(x=>x.Name).ToListAsync();
        }

        // GET: api/ItemMangements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemMangement>> GetItemMangement(int id)
        {
            var itemMangement = await _context.itemMangements.FindAsync(id);

            if (itemMangement == null)
            {
                return NotFound();
            }

            return itemMangement;
        }

        // PUT: api/ItemMangements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemMangement(int id,[FromBody] ItemEditVm itemMangement)
        {
            var item = await _context.itemMangements.FindAsync(id);
            if(item != null)
            {
                item.Name = itemMangement.name;
                item.Size = Convert.ToInt32(itemMangement.size);
                item.Price = Convert.ToDecimal(itemMangement.price);
                item.Attachement = itemMangement.attachement;

                await _context.SaveChangesAsync();
            }
            return Ok();

        }

        // POST: api/ItemMangements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult> PostItemMangement([FromBody] List<ItemVm> itemMangement )
        
        {
            if (itemMangement[0].name != "")
            {
List<ItemMangement> itemMangements = new List<ItemMangement>();

            foreach (var item in itemMangement)
            {
                var ItemMangementNew = new ItemMangement();

                ItemMangementNew.Name = item.name;
            ItemMangementNew.Size = Convert.ToInt32(item.size);
            ItemMangementNew.Price = Convert.ToDecimal(item.price);
            ItemMangementNew.Attachement = item.attachement;
                itemMangements.Add(ItemMangementNew);
            }
            


            _context.itemMangements.AddRange(itemMangements);
            await _context.SaveChangesAsync();

            return Ok();
            }
            return Ok();
            
        }

        // DELETE: api/ItemMangements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemMangement>> DeleteItemMangement(int id)
        {
            var itemMangement = await _context.itemMangements.FindAsync(id);
            if (itemMangement == null)
            {
                return NotFound();
            }

            _context.itemMangements.Remove(itemMangement);
            await _context.SaveChangesAsync();

            return itemMangement;
        }

        private bool ItemMangementExists(int id)
        {
            return _context.itemMangements.Any(e => e.Id == id);
        }
        [HttpPost("{Upload}")]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
