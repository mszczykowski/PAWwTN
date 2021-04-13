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
    public class DetailsModel : PageModel
    {
        private readonly PS3.Data.SearchContext _context;

        public DetailsModel(PS3.Data.SearchContext context)
        {
            _context = context;
        }

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
    }
}
