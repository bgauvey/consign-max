using consign_max.Infrastructure;
using consign_max.Models;
using consign_max.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace consign_max.APIs
{
    [Route("api/states")]
    public class StatesApiController : Controller
    {
        IStatesRepository _StatesRepository;
        ILogger _Logger;

        public StatesApiController(IStatesRepository statesRepo, ILoggerFactory loggerFactory)
        {
            _StatesRepository = statesRepo;
            _Logger = loggerFactory.CreateLogger(nameof(StatesApiController));
        }

        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(List<State>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> States()
        {
            try
            {
                var states = await _StatesRepository.GetStatesAsync();
                return Ok(states);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

    }
}
