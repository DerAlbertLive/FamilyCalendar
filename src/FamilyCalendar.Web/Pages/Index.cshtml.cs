using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyCalendar.Web.Models;
using FamilyCalendar.Web.MSGraph;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FamilyCalendar.Web.Pages
{
    public class IndexModel : PageModel
    {


        public IndexModel()
        {
            Dashboard = new DashboardModel();
        }
        public Task OnGet()
        {
            return Task.CompletedTask;
        }

        public DashboardModel Dashboard { get; set; }
    }
}
