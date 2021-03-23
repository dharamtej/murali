using Marten.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameWork
{
   public class orders
    {
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }
        public string  Name { get; set; }
        public string PhoneNumber { get; set; }
        public int ID { get; set; }
       
    }
}
