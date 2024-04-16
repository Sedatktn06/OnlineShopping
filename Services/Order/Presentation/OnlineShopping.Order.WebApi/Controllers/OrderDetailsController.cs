using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Order.Apllication.Commands.OrderCommands;
using OnlineShopping.Order.Apllication.Commands.OrderDetailCommands;
using OnlineShopping.Order.Apllication.Models.OrderDetailModels;
using OnlineShopping.Order.Apllication.Models.OrderModels;
using OnlineShopping.Order.Apllication.Queries.OrderDetailQueries;
using OnlineShopping.Order.Apllication.Queries.OrderQueries;

namespace OnlineShopping.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            var orderDetails = await _mediator.Send(new GetOrderDetailsQuery());
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var orderDetail = await _mediator.Send(new GetOrderDetailByIdQuery(id));
            return Ok(orderDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(OrderDetailModel model)
        {
            await _mediator.Send(new CreateOrderDetailCommand(model));
            return Ok("Sipariş detayı oluşturulmuştur.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _mediator.Send(new RemoveOrderDetailCommand(id));
            return Ok("Sipariş detayı silinmiştir");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(OrderDetailModel model)
        {
            await _mediator.Send(new UpdateOrderDetailCommand(model));
            return Ok("Sipariş detayı güncellenmiştir.");
        }
    }
}
