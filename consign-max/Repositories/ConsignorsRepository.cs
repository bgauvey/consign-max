using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using consign_max.Models;

namespace consign_max.Repositories
{
    public class ConsignorsRepository: IConsignorsRepository
    {
        public ConsignorsRepository()
        {
        }

        public Task<Consignor> GetConsignorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Consignor>> GetConsignorsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
