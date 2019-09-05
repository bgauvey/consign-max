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


        // GET api/consignors/5
        [HttpGet("{id}", Name = "GetConsignorRoute")]
        [NoCache]
        [ProducesResponseType(typeof(Consignor), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Items(int id)
        {
            try
            {
                var consignor = await _ConsignorsRepository.GetConsignorAsync(id);
                return Ok(consignor);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }
    }
}
