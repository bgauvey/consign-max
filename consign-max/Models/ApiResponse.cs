using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace consign_max.Models
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public Consignor Consignor { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}
