using consign_max.Infrastructure;
using consign_max.Models;
using consign_max.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace consign_max.APIs
{
    [Route("api/consignors")]
    public class ConsignorApiController : Controller
    {
        IConsignorsRepository _ConsignorsRepository;
        ILogger _Logger;

        public ConsignorApiController(IConsignorsRepository consignorsRepo, ILoggerFactory loggerFactory)
        {
            _ConsignorsRepository = consignorsRepo;
            _Logger = loggerFactory.CreateLogger(nameof(ConsignorApiController));
        }


        // GET api/Consignors
        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(List<Consignor>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Consignors()
        {
            try
            {
                var consignors = await _ConsignorsRepository.GetConsignorsAsync();
                return Ok(consignors);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // GET api/Consignors/page/10/10
        [HttpGet("page/{skip}/{take}")]
        [NoCache]
        [ProducesResponseType(typeof(List<Consignor>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> ConsignorsPage(int skip, int take)
        {
            try
            {
                var pagingResult = await _ConsignorsRepository.GetConsignorsPageAsync(skip, take);
                Response.Headers.Add("X-InlineCount", pagingResult.TotalRecords.ToString());
                return Ok(pagingResult.Records);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // GET api/Consignors/5
        [HttpGet("{id}", Name = "GetConsignorRoute")]
        [NoCache]
        [ProducesResponseType(typeof(Consignor), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Consignors(int id)
        {
            try
            {
                var Consignor = await _ConsignorsRepository.GetConsignorAsync(id);
                return Ok(Consignor);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // POST api/Consignors
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(ApiResponse), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> CreateConsignor([FromBody]Consignor Consignor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var newConsignor = await _ConsignorsRepository.InsertConsignorAsync(Consignor);
                if (newConsignor == null)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return CreatedAtRoute("GetConsignorRoute", new { id = newConsignor.Id },
                        new ApiResponse { Status = true, Consignor = newConsignor });
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // PUT api/Consignors/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> UpdateConsignor(int id, [FromBody]Consignor Consignor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var status = await _ConsignorsRepository.UpdateConsignorAsync(Consignor);
                if (!status)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return Ok(new ApiResponse { Status = true, Consignor = Consignor });
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // DELETE api/Consignors/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> DeleteConsignor(int id)
        {
            try
            {
                var status = await _ConsignorsRepository.DeleteConsignorAsync(id);
                if (!status)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return Ok(new ApiResponse { Status = true });
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }
    }
}
