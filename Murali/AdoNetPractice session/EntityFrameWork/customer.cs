using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameWork
{
   public  class customer
    {
        [Key]
        public int customer_id { get; set; }
        public string Customer_name { get; set; }
        public string city { get; set; }
        public char grade { get; set; }
        public int salesman_id { get; set; }
    }
}
