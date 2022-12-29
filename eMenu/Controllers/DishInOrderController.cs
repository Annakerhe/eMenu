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

    public class DishInOrderController : ControllerBase
    {
        private readonly IDishInOrderService dishInOrderService;
        private readonly IMapper mapper;

        /// <summary>
        /// DishInOrder controller
        /// </summary>
        public DishInOrderController(IDishInOrderService dishInOrderService, IMapper mapper)
        {
            this.dishInOrderService = dishInOrderService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get DishInOrder by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
    
        public IActionResult GetDishInOrder([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = dishInOrderService.GetDishesInOrders(limit, offset);

            var response = mapper.Map<PageResponse<DishInOrderResponse>>(pageModel);

            return Ok(response); 
        
        }

        /// <summary>
        /// Update DishInOrder
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public IActionResult UpdateDishInOrder([FromRoute] Guid id, [FromBody] UpdateOrderRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = dishInOrderService.UpdateDishInOrder(id, mapper.Map<UpdateDishInOrderModel>(model));

                return Ok(mapper.Map<OrderResponse>(resultModel));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.ToString()); 
            }
        }

        /// <summary>
        /// Delete DishInOrder
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDishInOrder([FromRoute] Guid id)
        {
            try
            {
                dishInOrderService.DeleteDishInOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        // <summary>
        /// Create DishInOrder
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateDishInOrder([FromQuery] Guid OrderId,[FromQuery] Guid DishId, [FromBody] DishInOrderModel dishInOrder)   
        {
            var response = dishInOrderService.CreateDishInOrder( OrderId, DishId, dishInOrder);
            return Ok(response);
        }

        /// <summary>
        /// Get DishInOrder
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDishInOrder([FromRoute] Guid id)
        {
            try
            {
                var dishInOrderModel = dishInOrderService.GetDishInOrder(id);
                return Ok(mapper.Map<DishInOrderResponse>(dishInOrderModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
