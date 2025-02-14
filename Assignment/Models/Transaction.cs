using Assignment.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    public class Transaction
    {

        [Key]
        public int TransactionId { get; set; }
        public string UserId { get; set; }

        public DateTime date { get; set; }
        public AssignmentUser User { get; set; }
        [Required]
        public string SenderFirstName { get; set; }
        public string SenderMiddleName { get; set; }

        [Required]
        public string SenderLastName { get; set; }
        [Required]
        public string SenderAddress { get; set; }
        [Required]
        public string SenderCountry { get; set; }

        [Required]
        public string ReceiverFirstName { get; set; }
        public string ReceiverMiddleName { get; set; }
        [Required]
        public string ReceiverLastName { get; set; }
        [Required]
        public string ReceiverAddress { get; set; }
        [Required]
        public string ReceiverCountry { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        [Precision(18, 18)]
        public decimal TransferAmountMYR { get; set; } // Transfer amount in MYR
        [Required]

        [Precision(18, 18)]
        public decimal ExchangeRate { get; set; }
        [Required]
        [Precision(18, 18)]
        public decimal PayoutAmountNPR { get; set; }
    }
}
