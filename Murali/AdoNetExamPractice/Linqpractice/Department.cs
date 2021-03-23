using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Linqpractice
{
   public  class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  id { get; set; }
        public string  Name { get; set; }
        public string Loc { get; set; }
       
    }
}
