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

    public class TablesController : ControllerBase
    {
        private readonly ITableService tableService;
        private readonly IMapper mapper;

        /// <summary>
        /// Tables controller
        /// </summary>
        public TablesController(ITableService tableService, IMapper mapper)
        {
            this.tableService = tableService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Tables by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
    
        public IActionResult GetTables([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = tableService.GetTables(limit, offset);

            var response = mapper.Map<PageResponse<TableResponse>>(pageModel);

            return Ok(response); 
        
        }

        /// <summary>
        /// Update Table
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public IActionResult UpdateTable([FromRoute] Guid id, [FromBody] UpdateTableRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = tableService.UpdateTable(id, mapper.Map<UpdateTableModel>(model));

                return Ok(mapper.Map<TableResponse>(resultModel));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.ToString()); 
            }
        }

        /// <summary>
        /// Delete Table
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTable([FromRoute] Guid id)
        {
            try
            {
                tableService.DeleteTable(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        // <summary>
        /// Create Table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateTable([FromBody] TableModel table)   
        {
            var response = tableService.CreateTable(table);
            return Ok(response);
        }

        /// <summary>
        /// Get Table
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTable([FromRoute] Guid id)
        {
            try
            {
                var tableModel = tableService.GetTable(id);
                return Ok(mapper.Map<TableResponse>(tableModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
