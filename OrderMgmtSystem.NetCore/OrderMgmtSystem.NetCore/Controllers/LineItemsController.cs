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
    public class LineItemsController : ControllerBase
    {
        private readonly USAMarketingContext _context;

        public LineItemsController(USAMarketingContext context)
        {
            _context = context;
        }

        // GET: api/LineItems
        [HttpGet]
        public IEnumerable<TblLineItem> GetTblLineItem()
        {
            return _context.TblLineItem;
        }

        // GET: api/LineItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblLineItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblLineItem = await _context.TblLineItem.FindAsync(id);

            if (tblLineItem == null)
            {
                return NotFound();
            }

            return Ok(tblLineItem);
        }

        // PUT: api/LineItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLineItem([FromRoute] int id, [FromBody] TblLineItem tblLineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblLineItem.LineItemId)
            {
                return BadRequest();
            }

            _context.Entry(tblLineItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLineItemExists(id))
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

        // POST: api/LineItems
        [HttpPost]
        public async Task<IActionResult> PostTblLineItem([FromBody] TblLineItem tblLineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblLineItem.Add(tblLineItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblLineItem", new { id = tblLineItem.LineItemId }, tblLineItem);
        }

        // DELETE: api/LineItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLineItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblLineItem = await _context.TblLineItem.FindAsync(id);
            if (tblLineItem == null)
            {
                return NotFound();
            }

            _context.TblLineItem.Remove(tblLineItem);
            await _context.SaveChangesAsync();

            return Ok(tblLineItem);
        }

        private bool TblLineItemExists(int id)
        {
            return _context.TblLineItem.Any(e => e.LineItemId == id);
        }
    }
}