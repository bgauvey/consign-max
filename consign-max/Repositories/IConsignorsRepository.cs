using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using consign_max.Models;

namespace consign_max.Repositories
{
    public interface IConsignorsRepository
    {
        Task<List<Consignor>> GetConsignorsAsync();
        Task<PagingResult<Consignor>> GetConsignorsPageAsync(int skip, int take);
        Task<Consignor> GetConsignorAsync(int id);

        Task<Consignor> InsertConsignorAsync(Consignor Consignor);
        Task<bool> UpdateConsignorAsync(Consignor Consignor);
        Task<bool> DeleteConsignorAsync(int id);
    }
}
