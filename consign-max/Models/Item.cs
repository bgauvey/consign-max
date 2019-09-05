using System;
namespace consign_max.Models
{
    public class Item
    { 
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal AskingPrice { get; set; }
        public decimal MinimumPrice { get; set; }
        public decimal EndingPrice { get; set; }
        public decimal Commission { get; set; }
        public decimal ListingFee { get; set; }
        public decimal SaleDayLimit { get; set; }
    }
}
