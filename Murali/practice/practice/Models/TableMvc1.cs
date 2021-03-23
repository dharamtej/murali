using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace practice.Models
{
    [Table("TableMvc1")]
    public class TableMvc1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(10,MinimumLength =5,ErrorMessage ="Sorry, Minimum 5 and Maximum 10")]
        [Display(Name ="Email")]
        public string EmailId { get; set; }
        [ForeignKey("AutoId")]
        public TableMvc2 tableMvc2 { get; set; }
    }
}
