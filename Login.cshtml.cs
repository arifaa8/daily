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
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Register register { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            bool res = Curd.Login(register);
            if (res==true)
            {
                return RedirectToPage("./Home");
            }
            else
            {
                return RedirectToPage("./Error");
            }
        }
    }
}
