using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NounCreate
    {
        [Key]
        public int NounID { get; set; }
        [Display(Name = "Noun")]
        public string NounWord { get; set; }
    }
}
