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
    public class IndexModel : PageModel
    {
        private readonly PS3.Data.SearchContext _context;

        public IndexModel(PS3.Data.SearchContext context)
        {
            _context = context;
        }

        public IList<Search> Search { get;set; }

        public async Task OnGetAsync()
        {
            Search = await _context.Search.Take(10).OrderByDescending(p => p.SearchDate).ToListAsync();
        }
    }
}
