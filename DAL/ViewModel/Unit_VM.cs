using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class Unit_VM
    {
        public int UnitId { get; set; }
        [Required(ErrorMessage = "UNIT NAME is Required")]
        public string UnitName { get; set; }
        public string Note { get; set; }
    }
}
