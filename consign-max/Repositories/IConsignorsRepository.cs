using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using consign_max.Models;

namespace consign_max.Repositories
{
    public interface IConsignorsRepository
    {
        Task<List<Consignor>> GetConsignorsAsync();
        Task<Consignor> GetConsignorAsync(int id);
    }
}
