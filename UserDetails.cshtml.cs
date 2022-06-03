using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreWebApp.Model;
using CoreWebApp.CallingSP;
namespace CoreWebApp.Pages
{
    public class UserDetailsModel : PageModel
    {
        [BindProperty]
        public List<Register> register { get; set; }
        public void OnGet()
        {
            register = Curd.GetAllData().ToList();
        }
    }
}
