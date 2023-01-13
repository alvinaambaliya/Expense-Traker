using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Expensetracker.Models
{
    [Table("expense_limit")]
    public class Expense_limit
    {
        [Key]
        public int e_id { get; set; }
        [Required]
        public int Total_expense { get; set; }
        [Required]
        public int Total_expense_limit { get; set; }
    }
}