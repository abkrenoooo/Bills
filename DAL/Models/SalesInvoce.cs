using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SalesInvoce
    {
        [Key]
        public int SalesInvoceId { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int Quantity { get; set; }
        public decimal PercentageDiscount { get; set; }
        public decimal ValueDiscount { get; set; }

    }
}
