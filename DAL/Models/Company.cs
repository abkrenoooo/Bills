using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Note { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Specy> Species { get; set; }
    }
}
