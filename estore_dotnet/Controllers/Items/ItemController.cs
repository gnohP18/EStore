using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estore_dotnet.Models.Items;
using estore_dotnet.Models.Items.Schemas;
using Microsoft.AspNetCore.Mvc;

namespace estore_dotnet.Controllers.Items
{
    [Route("api/items")]
    public class ItemController : BaseController
    {
        private readonly IItemModel _itemModel;
        public ItemController(
            IItemModel itemModel,
            IServiceProvider provider) : base(provider)
        {
            _itemModel = itemModel;
        }

        /// <summary>
        /// get list item
        /// <para>Created at: 10/08/2023</para>
        /// <para>Created by: gnohP18</para>
        /// </summary>
        /// <returns>list of item</returns>
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                return Ok(await _itemModel.GetAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// get list item
        /// <para>Created at: 10/08/2023</para>
        /// <para>Created by: gnohP18</para>
        /// <param name="id">id of the item</param>
        /// </summary>
        /// <returns>list of item</returns>
        [HttpGet("id")]
        public async Task<IActionResult> GetList(string id)
        {
            try
            {
                return Ok(await _itemModel.GetAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Create an item
        /// </summary>
        /// <param name="shoes">Detail Item</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Shoes shoes)
        {
            try
            {
                return Ok(await _itemModel.CreateAsync(shoes));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="shoes">Detail Item</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Shoes shoes)
        {
            try
            {
                return Ok(await _itemModel.UpdateAsync(id, shoes));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Delete list of item 
        /// </summary>
        /// <param name="ids">list id of item</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string[] ids)
        {
            try
            {
                return Ok(await _itemModel.DeleteAsync(ids));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}