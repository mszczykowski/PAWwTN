using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS3.Forms;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PS3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty] 
        public Search Search { get; set; }
        public List<Search> SearchList { get; set; }
        [BindProperty(SupportsGet = true)]
        public String Result { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Number { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var SessionSearchList = HttpContext.Session.GetString("SessionSearchList");
                if (SessionSearchList != null) SearchList = JsonConvert.DeserializeObject<List<Search>>(SessionSearchList);
                else SearchList = new List<Search>();
                Search.UpdateDate();
                if (Search.Number % 3 == 0) Search.Result += "Fizz";
                if (Search.Number % 5 == 0) Search.Result += "Buzz";
                if (Search.Number % 3 != 0 && Search.Number % 5 != 0) Search.Result += "bad";
                SearchList.Add(Search);
                HttpContext.Session.SetString("SessionSearchList", JsonConvert.SerializeObject(SearchList));
                return RedirectToPage("./Index/", new { Result = Search.Result, Number = Search.Number});
            }
            else
            {
                Result = null;
                return Page();
            }
        }

    }
}
