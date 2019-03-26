using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyCalendar.Web.MSGraph;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FamilyCalendar.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TestAccessService _service;

        public IndexModel(TestAccessService service)
        {
            _service = service;
        }
        public async Task OnGet()
        {
            await _service.CheckAsync();
        }
    }
}
