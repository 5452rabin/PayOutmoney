using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Assignment.ViewModel
{
    public class TrasactionVM
    {
        public int TransactionId { get; set; }
        public RateVM RateVM { get; set; }
        [Required(ErrorMessage = "Sender's first name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string SenderFirstName { get; set; }

        [StringLength(50, ErrorMessage = "Middle name cannot be longer than 50 characters.")]
        public string SenderMiddleName { get; set; }

        [Required(ErrorMessage = "Sender's last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string SenderLastName { get; set; }

        [Required(ErrorMessage = "Sender's address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        public string SenderAddress { get; set; }

        [Required(ErrorMessage = "Sender's country is required.")]
        [StringLength(100, ErrorMessage = "Country name cannot be longer than 100 characters.")]
        public string SenderCountry { get; set; }

        // Receiver Information
        [Required(ErrorMessage = "Receiver's first name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string ReceiverFirstName { get; set; }

        [StringLength(50, ErrorMessage = "Middle name cannot be longer than 50 characters.")]
        public string ReceiverMiddleName { get; set; }

        [Required(ErrorMessage = "Receiver's last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string ReceiverLastName { get; set; }

        [Required(ErrorMessage = "Receiver's address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        public string ReceiverAddress { get; set; }

        [Required(ErrorMessage = "Receiver's country is required.")]
        [StringLength(100, ErrorMessage = "Country name cannot be longer than 100 characters.")]
        public string ReceiverCountry { get; set; }

        // Payment Details
        [Required(ErrorMessage = "Bank name is required.")]
        [StringLength(100, ErrorMessage = "Bank name cannot be longer than 100 characters.")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Account number is required.")]
        [StringLength(16, ErrorMessage = "Bank name cannot be longer than 100 characters.")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Transfer amount in MYR is required.")]
        [Precision(18, 4)]
        public decimal TransferAmountMYR { get; set; }

        [Required(ErrorMessage = "Exchange rate is required.")]
        [Precision(18, 4)]
        public decimal ExchangeRate { get; set; }

        [Required(ErrorMessage = "Payout amount in NPR is required.")]
        [Precision(18, 4)]
        public decimal PayoutAmountNPR { get; set; }
        public DateTime date { get; set; }


        [Required(ErrorMessage = "UserId is required.")]
        public string UserId { get; set; }
    }
}
