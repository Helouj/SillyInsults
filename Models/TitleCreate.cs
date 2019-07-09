using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TitleCreate
    {
        [Key]
        public int TitleID { get; set; }
        public string TitleWord { get; set; }
    }
}