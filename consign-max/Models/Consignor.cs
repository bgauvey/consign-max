using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace consign_max.Models
{
    public class Consignor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string MiddleInitial { get; set; }

        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string AddressLine1 { get; set; }

        [MaxLength(50)]
        public string AddressLine2 { get; set; }

        [MaxLength(50), Required]
        public string City { get; set; }

        [MaxLength(2), Required]
        public State State { get; set; }

        [MaxLength(10), Required]
        public string Zip { get; set; }

        [MaxLength(10)]
        public string MobilePhone { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string EmailAddress { get; set; }

        public double Commission { get; set; }

        public DateTime? UpdateDate { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("ConsignorId")]
        public List<Item> Items { get; set; }
    }
}
