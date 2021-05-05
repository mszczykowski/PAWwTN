using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FizzBuzzWeb.Pages.Searches
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.SearchContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public List<Search> Search { get; set; }
        public string UserID { get; set; }

        public IndexModel(FizzBuzzWeb.Data.SearchContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task OnGetAsync()
        {
            Search = await _context.Search.ToListAsync();
            Search.Reverse();
            UserID = _userManager.GetUserId(User);
        }
    }
}
