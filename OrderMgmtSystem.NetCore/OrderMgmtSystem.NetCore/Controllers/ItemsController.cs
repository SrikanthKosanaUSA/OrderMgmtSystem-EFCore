using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderMgmtSystem.NetCore.Models;

namespace OrderMgmtSystem.NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly USAMarketingContext _context;

        public ItemsController(USAMarketingContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public IEnumerable<TblItem> GetTblItem()
        {

            return _context.TblItem;
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblItem = await _context.TblItem.FindAsync(id);

            if (tblItem == null)
            {
                return NotFound();
            }

            return Ok(tblItem);
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblItem([FromRoute] int id, [FromBody] TblItem tblItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblItem.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(tblItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Items
        [HttpPost]
        public async Task<IActionResult> PostTblItem([FromBody] TblItem tblItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblItem.Add(tblItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblItem", new { id = tblItem.ItemId }, tblItem);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblItem = await _context.TblItem.FindAsync(id);
            if (tblItem == null)
            {
                return NotFound();
            }

            _context.TblItem.Remove(tblItem);
            await _context.SaveChangesAsync();

            return Ok(tblItem);
        }

        private bool TblItemExists(int id)
        {
            return _context.TblItem.Any(e => e.ItemId == id);
        }
    }
}