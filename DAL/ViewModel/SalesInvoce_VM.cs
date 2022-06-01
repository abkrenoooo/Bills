using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class SalesInvoce_VM
    {
        public int SalesInvoceId { get; set; }
        [Required(ErrorMessage = "Quantity is Required")]
        public DateTime Date { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "CLIENT NAME is Required")]
        public string DateName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "ITEM NAME is Required")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public decimal SellingPrice { get; set; }
        [Required(ErrorMessage = "Quantity is Required")]
        public int Quantity { get; set; }
        public decimal PercentageDiscount { get; set; }
        public decimal ValueDiscount { get; set; }
        public decimal Net { get; set; }
        public decimal Total { get; set; }
    }
}
