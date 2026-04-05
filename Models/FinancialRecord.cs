namespace WebApplication1.Models
{
    using System.ComponentModel.DataAnnotations;

    public class FinancialRecord
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }  // Income / Expense

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [MaxLength(200, ErrorMessage = "Notes cannot exceed 200 characters")]
        public string? Note { get; set; }
        public int CreatedBy { get; set; }
    }
}
