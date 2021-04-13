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
using PS3.Data;

namespace PS3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Search Search { get; set; }
        public List<Search> SearchList { get; set; }
        public bool ShowResult { get; set; }
        private readonly SearchContext _context;
        public IndexModel(ILogger<IndexModel> logger, SearchContext context)
        {
            _logger = logger;
            _context = context;
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
                Search.CalculateFizzBuzz();
                _context.Search.Add(Search);
                _context.SaveChanges();
                SearchList.Add(Search);
                HttpContext.Session.SetString("SessionSearchList", JsonConvert.SerializeObject(SearchList));
                ShowResult = true;
                return Page();
            }
            else
            {
                ShowResult = false;
                return Page();
            }
        }

    }
}
