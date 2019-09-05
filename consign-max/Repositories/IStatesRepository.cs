using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using consign_max.Models;

namespace consign_max.Repositories
{
    public interface IStatesRepository
    {
        Task<List<State>> GetStatesAsync();
    }
}
