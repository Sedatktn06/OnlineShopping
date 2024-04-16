using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Order.Apllication.Commands.OrderCommands;
using OnlineShopping.Order.Apllication.Models.OrderModels;
using OnlineShopping.Order.Apllication.Queries.OrderQueries;

namespace OnlineShopping.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrdersQuery());
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderModel model)
        {
            await _mediator.Send(new CreateOrderCommand(model));
            return Ok("Sipariş oluşturulmuştur.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrder(int id)
        {
            await _mediator.Send(new RemoveOrderCommand(id));
            return Ok("Sipariş silinmiştir");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderModel model)
        {
            await _mediator.Send(new UpdateOrderCommand(model));
            return Ok("Sipariş güncellenmiştir.");
        }
    }
}
