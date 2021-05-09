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
    public class DeleteModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.SearchContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteModel(FizzBuzzWeb.Data.SearchContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Search Search { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Search = await _context.Search.FirstOrDefaultAsync(m => m.Id == id);

            if (Search == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Search = await _context.Search.FindAsync(id);

            if (Search != null && Search.OwnerID != null && Search.OwnerID == _userManager.GetUserId(User))
            {
                _context.Search.Remove(Search);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
