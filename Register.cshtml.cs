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
    public class RegisterModel : PageModel
    {
        Curd obj = new Curd();

        [BindProperty]
        public Register register { get; set; }
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            bool result = obj.AddUsers(register);
            if (result == true)
            {
                return RedirectToPage("./Login");
            }
            else
            {
                return RedirectToPage("./Error");
            }
        }
    }
}
