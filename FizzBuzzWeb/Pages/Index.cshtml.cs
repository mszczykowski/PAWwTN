using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Data;
using Microsoft.AspNetCore.Identity;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        [BindProperty]
        public Search Search { get; set; }
        public List<Search> SearchList { get; set; }
        public bool ShowResult { get; set; }
        private readonly SearchContext _context;
        public IndexModel(ILogger<IndexModel> logger, SearchContext context, 
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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
                var userID = _userManager.GetUserId(User);
                Search.OwnerID = userID;
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
