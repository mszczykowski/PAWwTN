using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using PS2.Forms;


namespace PS2.Pages
{
    public class AddressModel : PageModel
    {
        public List<Address> AddressList { get; set; }
        public Address Address { get; set; }
        public void OnGet()
        {
            var SessionAddressList = HttpContext.Session.GetString("SessionAddressList");
            if (SessionAddressList != null) AddressList = JsonConvert.DeserializeObject<List<Address>>(SessionAddressList);
        }
    }
}