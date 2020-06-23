using DTO.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO.Money
{
    public class ExpensesDTO
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public PaymentType Type { get; set; }
        public DateTime OutcomeDate { get; set; }
    }
}
