using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS2.Forms;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PS2.Pages
{
    public class IndexModel : PageModel
    {
        public List<Address> AddressList { get; set; }
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Address Address { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var SessionAddressList = HttpContext.Session.GetString("SessionAddressList");
                if (SessionAddressList != null) AddressList = JsonConvert.DeserializeObject<List<Address>>(SessionAddressList);
                else AddressList = new List<Address>();
                AddressList.Add(Address);
                HttpContext.Session.SetString("SessionAddressList", JsonConvert.SerializeObject(AddressList));
                return RedirectToPage("./Address");
            }
            else return Page();
        }
    }
}
