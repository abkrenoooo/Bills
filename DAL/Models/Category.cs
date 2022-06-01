using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        [ForeignKey("SpecyId")]
        public int SpecyId { get; set; }
        public virtual Specy Specy { get; set; }
        public string ItemName { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal ByingPrice { get; set; }
        public string Note { get; set; }
    }
}
