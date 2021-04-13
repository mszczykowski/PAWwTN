using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PS3.Forms
{
    public class Search
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Display(Name = "Wartość")]
        [Range(1,1000, ErrorMessage = "Dopuszczalne są wartości od 1 do 1000")]
        public int? Number { get; set; }
        [Display(Name = "Rezultat")]
        public int Result { get; set; }
        [Display(Name = "Data wyszukiwania")]
        public DateTime SearchDate { get; set; }
        public string ResultToString()
        {
            switch (Result)
            {     
                case 1:
                    return "Fizz";
                case 2:
                    return "Buzz";
                case 3:
                    return "FizzBuzz";
            }
            return "Nie spełnia FizzBuzz";
        }
        public void CalculateFizzBuzz()
        {
            if(Number != null)
            {
                Result = 0;
                SearchDate = DateTime.Now;
                if (Number % 3 == 0) Result += 1;
                if (Number % 5 == 0) Result += 2;
            }
        }
    }
}
