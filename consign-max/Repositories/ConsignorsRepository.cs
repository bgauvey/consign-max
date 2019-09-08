using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consign_max.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace consign_max.Repositories
{
    public class ConsignorsRepository: IConsignorsRepository
    {
        private readonly ConsignMaxDbContext _Context;
        private readonly ILogger _Logger;

        public ConsignorsRepository(ConsignMaxDbContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("ConsignorsRepository");
        }

        public async Task<List<Consignor>> GetConsignorsAsync()
        {
            return await _Context.Consignors.OrderBy(c => c.LastName)
                                 .Include(c => c.State)
                                 .Include(c => c.Items)
                                 .ToListAsync();
        }

        public async Task<PagingResult<Consignor>> GetConsignorsPageAsync(int skip, int take)
        {
            var totalRecords = await _Context.Consignors.CountAsync();
            var Consignors = await _Context.Consignors
                                 .OrderBy(c => c.LastName)
                                 .Include(c => c.State)
                                 .Include(c => c.Items)
                                 .Skip(skip)
                                 .Take(take)
                                 .ToListAsync();
            return new PagingResult<Consignor>(Consignors, totalRecords);
        }

        public async Task<Consignor> GetConsignorAsync(int id)
        {
            return await _Context.Consignors
                                  .Include(c => c.State)
                                 .Include(c => c.Items)
                                 .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Consignor> InsertConsignorAsync(Consignor Consignor)
        {
            _Context.Add(Consignor);
            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _Logger.LogError($"Error in {nameof(InsertConsignorAsync)}: " + exp.Message);
            }

            return Consignor;
        }

        public async Task<bool> UpdateConsignorAsync(Consignor Consignor)
        {
            //Will update all properties of the Consignor
            _Context.Consignors.Attach(Consignor);
            _Context.Entry(Consignor).State = EntityState.Modified;
            try
            {
                return (await _Context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(UpdateConsignorAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> DeleteConsignorAsync(int id)
        {
            //Extra hop to the database but keeps it nice and simple for this demo
            //Including orders since there's a foreign-key constraint and we need
            //to remove the orders in addition to the Consignor
            var Consignor = await _Context.Consignors
                                .Include(c => c.Items)
                                .SingleOrDefaultAsync(c => c.Id == id);
            _Context.Remove(Consignor);
            try
            {
                return (await _Context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (System.Exception exp)
            {
                _Logger.LogError($"Error in {nameof(DeleteConsignorAsync)}: " + exp.Message);
            }
            return false;
        }
    }
}
