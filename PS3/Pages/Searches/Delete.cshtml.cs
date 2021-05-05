using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PS3.Data;
using PS3.Forms;

namespace PS3.Pages.Searches
{
    public class DeleteModel : PageModel
    {
        private readonly PS3.Data.SearchContext _context;

        public DeleteModel(PS3.Data.SearchContext context)
        {
            _context = context;
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

            if (Search != null)
            {
                _context.Search.Remove(Search);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
