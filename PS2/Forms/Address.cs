using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PS2.Forms
{
    public class Address
    {
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Display(Name = "Kod pocztowy")]
        public string ZipCode { get; set; }
        [Display(Name = "Miasto")]
        [Required(ErrorMessage ="Pole jest obowiązkowe")]
        public string City { get; set; }
        [Display(Name = "Numer")]
        public int Number { get; set; }
    }
}
