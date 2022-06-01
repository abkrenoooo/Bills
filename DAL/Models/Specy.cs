using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Specy
    {
        [Key]
        public int SpecyId { get; set; }
        public string SpecyName { get; set; }
        public string Note { get; set; }
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<SalesInvoce> SalesInvoces { get; set; }

    }
}
