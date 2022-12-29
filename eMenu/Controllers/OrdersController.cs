using AutoMapper;
using eMenu.Services.Abstract;
using eMenu.Services.Models;
using eMenu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eMenu.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]                               
    [Route("api/v{version:apiVersion}/[controller]")] 
    [ApiController]

    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        /// <summary>
        /// Orders controller
        /// </summary>
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Orders by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
    
        public IActionResult GetOrders([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = orderService.GetOrders(limit, offset);

            var response = mapper.Map<PageResponse<OrderResponse>>(pageModel);

            return Ok(response); 
        
        }

        /// <summary>
        /// Update Orders
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public IActionResult UpdateOrders([FromRoute] Guid id, [FromBody] UpdateOrderRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = orderService.UpdateOrder(id, mapper.Map<UpdateOrderModel>(model));

                return Ok(mapper.Map<OrderResponse>(resultModel));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.ToString()); 
            }
        }

        /// <summary>
        /// Delete Order
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteOrder([FromRoute] Guid id)
        {
            try
            {
                orderService.DeleteOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        // <summary>
        /// Create Order
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateOrder([FromQuery] Guid TableId,[FromBody] OrderModel order)   
        {
            var response = orderService.CreateOrder(TableId, order);
            return Ok(response);
        }

        /// <summary>
        /// Get Order
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOrder([FromRoute] Guid id)
        {
            try
            {
                var orderModel = orderService.GetOrder(id);
                return Ok(mapper.Map<OrderResponse>(orderModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
