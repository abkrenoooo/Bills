using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helper
{
   public class ResponseBody<T> where T : class
    {
        public string message { get; set; }

        public IList<T> data { get; set; }
        public int status_code { get; set; }
    }
}
