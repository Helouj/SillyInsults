using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Title
    {
        [Key]
        public int TitleID { get; set; }
        [Required]
        public string TitleWord { get; set; }


    }
}