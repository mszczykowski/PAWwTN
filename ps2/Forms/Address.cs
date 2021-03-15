using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ps2.Forms
{
    public class Address
    {
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Display(Name = "Kod pocztowy")]
        [StringLength(5, ErrorMessage = "Należy wpisać 5 cyfr", MinimumLength = 5)]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string ZipCode { get; set; }
        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string City { get; set; }
        [Display(Name = "Numer")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public int Number { get; set; }
    }

}
