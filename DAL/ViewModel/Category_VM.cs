using DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class Category_VM
    {
        public int CategoryId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "COMPANY NAME is Required")]
        public int CompanyId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "SPECY NAME is Required")]
        public int SpecyId { get; set; }
        public string CompanyName { get; set; }
        public string SpecyName { get; set; }

        [Required(ErrorMessage = "ITEM NAME is Required")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "SELLING PRICE is Required")]
        public decimal SellingPrice { get; set; }

        [Required(ErrorMessage = "BUYING PRICE is Required")]
        public decimal ByingPrice { get; set; }
        public string Note { get; set; }
    }
}
