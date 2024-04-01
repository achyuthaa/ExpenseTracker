using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Please select a Category.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Amount should be greater than zero")]
        public string Amount { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public String? Note { get; set; }

        public DateTime? Date { get; set; } = DateTime.Now;
        [NotMapped]
        public string? TransactionWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + Category.Title;   
            }
        
        }
        [NotMapped]
        public string? CustomizeAmount
        {
            get
            {
                if (decimal.TryParse(Amount, out decimal amountValue))
                {
                    return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + amountValue.ToString("c0");
                }
                else
                {
                    // Handle parsing failure if necessary
                    return ""; // or any default value
                }
            }
        }





    }
}
