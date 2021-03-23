using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace practice.Models
{
    [Table("TableMvc2")]
    public class TableMvc2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoId { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name ="Location")]
        public string Loc { get; set; }
    }
}
