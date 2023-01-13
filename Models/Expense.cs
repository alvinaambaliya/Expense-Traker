using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Expensetracker.Models
{
    [Table("expenses")]
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required,RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",ErrorMessage ="not allow numaric value.")]
        public string Title { get; set; }
        [Required,RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",ErrorMessage ="not allow numaric value.")]
        public string Description { get; set; }
        public DateTime Date_Time { get; set; } = DateTime.Now;

        [ForeignKey("category"),Required]

        public string Category_name { get; set; }
        [Required]
        public int Amount { get; set; }
        public Category category { get; set; }
       // public List<Category> categorylist { get; set; }
    }
}