using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AdjectiveEdit
    {
        [Key]
        public int AdjectiveID { get; set; }
        [Display(Name = "Adjective")]
        public string AdjectiveWord { get; set; }
    }
}
