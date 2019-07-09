using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SillyInsultHistory
    {
        [Key]
        public int SillyInsultHistoryID { get; set; }
        
        public string AdjectiveWord { get; set; }
        public string NounWord { get; set; }
        public string TitleWord { get; set; }



    }
}