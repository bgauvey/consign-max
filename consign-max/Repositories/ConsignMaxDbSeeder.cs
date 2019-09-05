using consign_max.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consign_max.Repositories
{
    public class ConsignMaxDbSeeder
    {
        readonly ILogger _Logger;

        public ConsignMaxDbSeeder(ILoggerFactory loggerFactory)
        {
            _Logger = loggerFactory.CreateLogger("ConsignMaxDbSeederLogger");
        }

        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            //Based on EF team's example at https://github.com/aspnet/MusicStore/blob/dev/samples/MusicStore/Models/SampleData.cs
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var mesDb = serviceScope.ServiceProvider.GetService<ConsignMaxDbContext>();
                if (await mesDb.Database.EnsureCreatedAsync())
                {
                    if (!await mesDb.Items.AnyAsync())
                    {
                        await InsertItemsSampleData(mesDb);
                    }
                }
            }
        }

        public async Task InsertItemsSampleData(ConsignMaxDbContext db)
        {
            var items = GetItems();
            db.Items.AddRange(items);
            try
            {
                int numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation(@"Saved {numAffected} states");
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(ConsignMaxDbSeeder)}: " + exp.Message);
                throw;
            }
        }

        private List<Item> GetItems()
        {
            var items = new List<Item>
            {
                new Item {},
            };

            return items;
        }
    }
}
