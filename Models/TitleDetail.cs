using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TitleDetail
    {
        [Key]
        public int TitleID { get; set; }
        [Display(Name = "Title")]
        public string TitleWord { get; set; }
    }
}