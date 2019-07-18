using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Adjective
    {
        [Key]
        public int AdjectiveID { get; set; }
        [Required]
        [Display(Name = "Adjective")]
        public string AdjectiveWord { get; set; }


    }
}
