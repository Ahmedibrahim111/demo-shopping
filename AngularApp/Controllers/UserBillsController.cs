using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularApp.Models;
using PaymentAPI.Models;

namespace AngularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBillsController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public UserBillsController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/UserBills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBill>>> GetuserBills()
        {
            return await _context.userBills.ToListAsync();
        }

        // GET: api/UserBills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserBill>> GetUserBill(int id)
        {
            var userBill = await _context.userBills.FindAsync(id);

            if (userBill == null)
            {
                return NotFound();
            }

            return userBill;
        }

        // PUT: api/UserBills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBill(int id, UserBill userBill)
        {
            if (id != userBill.BillNumber)
            {
                return BadRequest();
            }

            _context.Entry(userBill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBillExists(id))
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

        // POST: api/UserBills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserBill>> PostUserBill(UserBill userBill)
        {
            _context.userBills.Add(userBill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserBill", new { id = userBill.BillNumber }, userBill);
        }

        // DELETE: api/UserBills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserBill>> DeleteUserBill(int id)
        {
            var userBill = await _context.userBills.FindAsync(id);
            if (userBill == null)
            {
                return NotFound();
            }

            _context.userBills.Remove(userBill);
            await _context.SaveChangesAsync();

            return userBill;
        }

        private bool UserBillExists(int id)
        {
            return _context.userBills.Any(e => e.BillNumber == id);
        }
    }
}
