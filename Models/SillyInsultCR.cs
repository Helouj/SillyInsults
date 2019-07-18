using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SillyInsultCR
    {
        [Key]
        public int SillyInsultHistoryID { get; set; }
        [Display(Name = "Adjective")]
        public string AdjectiveWord { get; set; }
        [Display(Name = "Noun")]
        public string NounWord { get; set; }
        [Display(Name = "Title")]
        public string TitleWord { get; set; }



    }
}