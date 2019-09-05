using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consign_max.Models;

namespace consign_max.Repositories
{
    public class StatesRepository : IStatesRepository
    {
        private readonly ConsignMaxDbContext _Context;
        private readonly ILogger _Logger;

        public StatesRepository(ConsignMaxDbContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("StatesRepository");
        }

        public async Task<List<State>> GetStatesAsync()
        {
            return await _Context.States.OrderBy(s => s.Abbreviation).ToListAsync();
        }
    }
}
