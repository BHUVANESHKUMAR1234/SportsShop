using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsShop.WebApi.Models;

namespace SportsShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MyContext _context;

        public OrdersController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<order>>> GetOrders()
        {


            return await _context.Orders
                 .Include(x => x.Customer)
                 .Include(x => x.Item)
                 .ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<order>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(x => x.Customer)
                 .Include(x => x.Item)
                .FirstOrDefaultAsync(x => x.OrderNumber == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, order order)
        {
            order.OrderNumber = id;

            int stock = _context.Items.Where(x => x.ItemNumber == order.ItemNumber).Single().ItemNumber;

            order.Price = _context.Items.Where(x => x.ItemNumber == order.ItemNumber).Single().Value;



            order.Total = order.Price * order.Quantity;
            if (id != order.OrderNumber)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<order>> PostOrder(order order)
        {
            int stock = _context.Items.Where(x => x.ItemNumber == order.ItemNumber).Single().ItemNumber;

           order.Price = _context.Items.Where(x => x.ItemNumber == order.ItemNumber).Single().Value;

            
            
            order.Total = order.Price * order.Quantity;

             _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderNumber }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderNumber == id);
        }
    }
}
