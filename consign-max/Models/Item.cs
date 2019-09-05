using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace consign_max.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ConsignorId { get; set; }

        [MaxLength(200), Required]
        public string Description { get; set; }

        [Required]
        public double AskingPrice { get; set; }
        public double MinimumPrice { get; set; }
        public double? EndingPrice { get; set; }
        public double Commission { get; set; }
        public double? ListingFee { get; set; }
        public double? SaleDayLimit { get; set; }

        public DateTime? SaleDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
