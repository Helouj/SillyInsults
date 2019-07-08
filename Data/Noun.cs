using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Noun
    {
        [Key]
        public int NounID { get; set; }
        [Required]
        public string NounWord { get; set; }


    }
}
