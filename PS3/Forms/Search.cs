using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PS3.Forms
{
    public class Search
    {
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Display(Name = "Wartość")]
        [Range(1,1000, ErrorMessage = "Dopuszczalne są wartości od 1 do 1000")]
        public int? Number { get; set; }
        [Display(Name = "Rezultat")]
        public string Result { get; set; }
        [Display(Name = "Data wyszukiwania")]
        public DateTime SearchDate { get; set; }
        public void UpdateDate()
        {
            SearchDate = DateTime.Now;
        }
        public string ResultToString()
        {
            if (Result == "bad") return "nie spełnia FizzBuzz";
            else return Result;
        }
    }
}
