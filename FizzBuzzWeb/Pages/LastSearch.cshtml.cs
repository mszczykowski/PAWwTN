using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class LastSearchModel : PageModel
    {
        public int Search { get; set; }
        public List<Search> SearchList { get; set; }
        public void OnGet()
        {
            var SessionSearchList = HttpContext.Session.GetString("SessionSearchList");
            if (SessionSearchList != null)
            {
                SearchList = JsonConvert.DeserializeObject<List<Search>>(SessionSearchList);
                SearchList.Reverse();
            }
        }
    }
}
