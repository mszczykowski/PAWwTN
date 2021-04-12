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
        public string ResultToString()
        {
            if (Result == "bad") return "nie spełnia FizzBuzz";
            else return Result;
        }
        public void CalculateFizzBuzz()
        {
            if(Number != null)
            {
                SearchDate = DateTime.Now;
                if (Number % 3 == 0) Result += "Fizz";
                if (Number % 5 == 0) Result += "Buzz";
                if (Number % 3 != 0 && Number % 5 != 0) Result += "bad";
            }
        }
    }
}
