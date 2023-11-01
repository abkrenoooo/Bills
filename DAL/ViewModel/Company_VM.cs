using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.ViewModel
{
    public class Company_VM
    {
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "COMPANY NAME is Required")]
        public string CompanyName { get; set; }
        public string Note { get; set; }
    }
}
