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

namespace AngularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentOrderDetailsController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public PaymentOrderDetailsController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/PaymentOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentOrderDetails>>> GetpaymentOrderDetails()
        {
            return await _context.paymentOrderDetails.ToListAsync();
        }

        // GET: api/PaymentOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<PaymentOrderDetails>>> GetPaymentOrderDetails(int id)
        {
            var paymentOrderDetails = await _context.paymentOrderDetails.Where(x=>x.BillId== id).ToListAsync();

            if (paymentOrderDetails == null)
            {
                return NotFound();
            }

            return paymentOrderDetails;
        }

        // PUT: api/PaymentOrderDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentOrderDetails(int id, PaymentOrderDetails paymentOrderDetails)
        {
            if (id != paymentOrderDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentOrderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentOrderDetailsExists(id))
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

        // POST: api/PaymentOrderDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaymentOrderDetails>> PostPaymentOrderDetails([FromBody]List<paymentVM> paymentOrderDetails)
        {
             UserBill  userBill = new UserBill();
            userBill.UserName = paymentOrderDetails.FirstOrDefault().OwnerName;
            userBill.PhoneNumber = paymentOrderDetails.FirstOrDefault().PhoneNumber;
            userBill.TotalPrice = paymentOrderDetails.FirstOrDefault().Total;
            userBill.Date = DateTime.Now;

            _context.userBills.Add(userBill);
            await _context.SaveChangesAsync();

            List<PaymentOrderDetails> PaymentOrderDetailsSave = new List<PaymentOrderDetails>();

            foreach (var item in paymentOrderDetails)
            {
                PaymentOrderDetails PaymentOrderDetail = new PaymentOrderDetails();
                PaymentOrderDetail.NameProduct = item.NameProduct;
                PaymentOrderDetail.NumberProducts = item.NumberProducts;
                PaymentOrderDetail.Size = item.Size;
                PaymentOrderDetail.Price = item.Price;
                PaymentOrderDetail.TotalPrice = item.TotalPrice;
                PaymentOrderDetail.BillId = userBill.BillNumber;
                PaymentOrderDetailsSave.Add(PaymentOrderDetail);
            }
            _context.paymentOrderDetails.AddRange(PaymentOrderDetailsSave);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/PaymentOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentOrderDetails>> DeletePaymentOrderDetails(int id)
        {
            var paymentOrderDetails = await _context.paymentOrderDetails.FindAsync(id);
            if (paymentOrderDetails == null)
            {
                return NotFound();
            }

            _context.paymentOrderDetails.Remove(paymentOrderDetails);
            await _context.SaveChangesAsync();

            return paymentOrderDetails;
        }

        private bool PaymentOrderDetailsExists(int id)
        {
            return _context.paymentOrderDetails.Any(e => e.Id == id);
        }
    }
}
