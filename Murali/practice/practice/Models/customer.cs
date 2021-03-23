using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace practice.Models
{
    [Table("CustomerDetails")]
    public class customer
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sno { get; set; }
        public string CustomerName { get; set; }
        public string Phonenumber { get; set; }
        public int ProductId { get; set; }
    }
}
