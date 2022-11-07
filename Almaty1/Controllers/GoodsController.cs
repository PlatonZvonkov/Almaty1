using AlmatyApi.Models;
using AlmatyApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmatyApi.Controllers
{
    [ApiController]
    [Route("api/movedGoods")]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodsService service;

        public GoodsController(IGoodsService service)
        {
            this.service = service;
        }

        /**
         <summary> Get a list of goods movement by specified ammount </summary>
         */
        [HttpGet,Route("{take}")]
        public async Task<IActionResult> GetMovedGoodsAsync(int take)
        {
            if (take < 0)
            {
                return BadRequest(new { Message = "Ammount cannot be negative value!" });
            }
            List<MovedGoodsView> result = await service.GetAllMovedGoodsAsync(take);
            return Ok(result);
        }

        /**
         <summary> Post new movement of goods </summary>
         */
        [HttpPost, Route("movedGoods")]
        public async Task<IActionResult> NewGoodsMovementAsync([FromBody] MoovedGoods movedGoods)
        {
            if (movedGoods == null)
            {
                return BadRequest(new { Message = "Empty requests not allowed!" });
            }
            try
            {
                await service.PostNewMovedGoodsAsync(movedGoods);
            }
            catch (System.Exception)
            {

                return BadRequest(new { Message = "Server Error", StatusCode = 500 });
            }

            return Ok();
        }

        /**
         <summary> delete specific movement of goods </summary>
         */
        [HttpDelete]
        public IActionResult DeleteMovedGoods([FromBody] MoovedGoods movedGoods)
        {
            if (movedGoods == null)
            {
                return BadRequest(new { Message = "Empty requests not allowed!" });
            }
            try
            {
                service.DeleteMovedGoodsByModel(movedGoods);
            }
            catch (System.Exception)
            {

                return BadRequest(new { Message = "Server Error", StatusCode = 500 });
            }
            return Ok(movedGoods);
        }
    }
}
