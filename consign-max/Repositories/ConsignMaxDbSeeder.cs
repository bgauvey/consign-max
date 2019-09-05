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
                var consighMaxDb = serviceScope.ServiceProvider.GetService<ConsignMaxDbContext>();
                if (await consighMaxDb.Database.EnsureCreatedAsync())
                {
                    if (!await consighMaxDb.Consignors.AnyAsync())
                    {
                        await InsertSampleData(consighMaxDb);
                    }
                }
            }
        }

        public async Task InsertSampleData(ConsignMaxDbContext db)
        {
            var states = GetStates();
            db.States.AddRange(states);
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

            var consignors = GetConsignors();
            db.Consignors.AddRange(consignors);
            try
            {
                int numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation(@"Saved {numAffected} consignors");
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(ConsignMaxDbSeeder)}: " + exp.Message);
                throw;
            }
        }


        private List<Consignor> GetConsignors()
        {
            var consignors = new List<Consignor>
            {
                new Consignor
                {
                    LastName = "Gauvey",
                    FirstName = "Bill",
                    AddressLine1 = "170 Marshall Ln",
                    City = "Greeneville",
                    State = new State { Abbreviation = "TN", Name = "Tennessee" },
                    Zip = "37743",
                    MobilePhone = "4233295206",
                    Commission = .6,
                    EmailAddress = "bgauvey@gmail.com",
                    Items = new List<Item>
                    {
                        new Item
                        {
                             Description = "Wicker Table",
                             AskingPrice = 40.0,
                             Commission = .6,
                             MinimumPrice = 25
                        },
                        new Item
                        {
                             Description = "Wicker Chair",
                             AskingPrice = 12.5,
                             Commission = .6,
                             MinimumPrice = 10
                        }
                    }
                },
            };

            return consignors;
        }

        private List<State> GetStates()
        {
            var states = new List<State>
            {
                new State { Name = "Alabama", Abbreviation = "AL" },
                new State { Name = "Montana", Abbreviation = "MT" },
                new State { Name = "Alaska", Abbreviation = "AK" },
                new State { Name = "Nebraska", Abbreviation = "NE" },
                new State { Name = "Arizona", Abbreviation = "AZ" },
                new State { Name = "Nevada", Abbreviation = "NV" },
                new State { Name = "Arkansas", Abbreviation = "AR" },
                new State { Name = "New Hampshire", Abbreviation = "NH" },
                new State { Name = "California", Abbreviation = "CA" },
                new State { Name = "New Jersey", Abbreviation = "NJ" },
                new State { Name = "Colorado", Abbreviation = "CO" },
                new State { Name = "New Mexico", Abbreviation = "NM" },
                new State { Name = "Connecticut", Abbreviation = "CT" },
                new State { Name = "New York", Abbreviation = "NY" },
                new State { Name = "Delaware", Abbreviation = "DE" },
                new State { Name = "North Carolina", Abbreviation = "NC" },
                new State { Name = "Florida", Abbreviation = "FL" },
                new State { Name = "North Dakota", Abbreviation = "ND" },
                new State { Name = "Georgia", Abbreviation = "GA" },
                new State { Name = "Ohio", Abbreviation = "OH" },
                new State { Name = "Hawaii", Abbreviation = "HI" },
                new State { Name = "Oklahoma", Abbreviation = "OK" },
                new State { Name = "Idaho", Abbreviation = "ID" },
                new State { Name = "Oregon", Abbreviation = "OR" },
                new State { Name = "Illinois", Abbreviation = "IL" },
                new State { Name = "Pennsylvania", Abbreviation = "PA" },
                new State { Name = "Indiana", Abbreviation = "IN" },
                new State { Name = "Rhode Island", Abbreviation = "RI" },
                new State { Name = "Iowa", Abbreviation = "IA" },
                new State { Name = "South Carolina", Abbreviation = "SC" },
                new State { Name = "Kansas", Abbreviation = "KS" },
                new State { Name = "South Dakota", Abbreviation = "SD" },
                new State { Name = "Kentucky", Abbreviation = "KY" },
                new State { Name = "Tennessee", Abbreviation = "TN" },
                new State { Name = "Louisiana", Abbreviation = "LA" },
                new State { Name = "Texas", Abbreviation = "TX" },
                new State { Name = "Maine", Abbreviation = "ME" },
                new State { Name = "Utah", Abbreviation = "UT" },
                new State { Name = "Maryland", Abbreviation = "MD" },
                new State { Name = "Vermont", Abbreviation = "VT" },
                new State { Name = "Massachusetts", Abbreviation = "MA" },
                new State { Name = "Virginia", Abbreviation = "VA" },
                new State { Name = "Michigan", Abbreviation = "MI" },
                new State { Name = "Washington", Abbreviation = "WA" },
                new State { Name = "Minnesota", Abbreviation = "MN" },
                new State { Name = "West Virginia", Abbreviation = "WV" },
                new State { Name = "Mississippi", Abbreviation = "MS" },
                new State { Name = "Wisconsin", Abbreviation = "WI" },
                new State { Name = "Missouri", Abbreviation = "MO" },
                new State { Name = "Wyoming", Abbreviation = "WY" }
            };

            return states;
        }
    }
}
