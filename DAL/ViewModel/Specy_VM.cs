using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class Specy_VM
    {
        public int SpecyId { get; set; }

        [Required(ErrorMessage = "SPECY NAME is Required")]
        public string SpecyName { get; set; }
        public string Note { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "COMPANY NAME is Required")]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
