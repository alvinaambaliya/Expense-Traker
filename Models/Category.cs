using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Expensetracker.Models
{
    [Table("categories")]
    public class Category
    {
        [Key,Required, RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "not allow numaric value.")]
        public string Category_name { get; set; }
        [Required]
        public int Category_expense_limit { get; set; }
        public List<Expense> expenselist { get; set; }
    }
}