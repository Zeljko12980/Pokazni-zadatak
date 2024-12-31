using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly PizzaContext _context;

        public OrderController(PizzaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _context.Orders.Include(p=>p.Cart).ToListAsync());
        }

         [HttpPost]
        public async Task<ActionResult> PlaceOrder([FromBody] Order orderRequest)
    {
       

        // Process the order here, e.g., saving to the database
        // For now, we will simply return the received data as confirmation
        var orderConfirmation = new Order
        {
           Name=orderRequest.Name,
           LastName=orderRequest.LastName,
           Phone=orderRequest.Phone,
           Address=orderRequest.Address,
           Cart=orderRequest.Cart,  
           TotalPrice=orderRequest.TotalPrice,
        };

        // For example, save the order to the database here
        // _orderService.SaveOrder(orderRequest);
        _context.Orders.Add(orderConfirmation);
        await _context.SaveChangesAsync();  

        return Ok(orderConfirmation);


    }

    [HttpDelete("{id}")]
     public async Task<ActionResult> DeleteOrderConfirmation(int id)
     {
        var order = await _context.Orders.FirstOrDefaultAsync(p=>p.Id==id);

        _context.Orders.Remove(order);

        await _context.SaveChangesAsync();

        return Ok();
     }
}
}