using AutoMapper;
using eMenu.Services.Abstract;
using eMenu.Services.Models;
using eMenu.Models;
using Microsoft.AspNetCore.Mvc;

namespace eMenu.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishService dishesService;
        private readonly IMapper mapper;

        /// <summary>
        /// Dishes controller
        /// </summary>
        public DishesController(IDishService  dishesService,IMapper mapper)
        {
            this.dishesService=dishesService;
            this.mapper=mapper;
        }
        /// <summary>
        /// create Dish
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateDish([FromBody] DishModel dish)
        {
            var response = dishesService.CreateDish(dish);
            return Ok(response);
        }
        
        /// <summary>
        /// Get Dishes by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetDishes([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = dishesService.GetDishes(limit,offset);

            return Ok(mapper.Map<PageResponse<DishResponse>>(pageModel));
        }
        /// <summary>
        /// Delete Dish
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDish([FromRoute] Guid id)
        {
            try
            {
                dishesService.DeleteDish(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get Dish
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDish([FromRoute] Guid id)
        {
            try
            {
                var DishModel =dishesService.GetDish(id);
                return Ok(mapper.Map<DishResponse>(DishModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update Dish
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateDish([FromRoute] Guid id, [FromBody] UpdateDishRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =dishesService.UpdateDish(id,mapper.Map<UpdateDishModel>(model));
            return Ok(mapper.Map<DishResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }          
    }

}