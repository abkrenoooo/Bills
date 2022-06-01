using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class Client_VM
    {
        public int ClientId { get; set; }
        [Required(ErrorMessage = "CLIENT NAME is Required")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "PHONE is Required")]
        [StringLength(14, ErrorMessage = "PHONE  must be just a 14 digit number")]
        [RegularExpression(@"([0-9]{14})$", ErrorMessage = "PHONE  must be just a 14 digit number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
    }
}
