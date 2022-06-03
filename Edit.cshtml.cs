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
    public class EditModel : PageModel
    {
        [BindProperty]
        public Register register { get; set; }
        public ActionResult OnGet(int? UserID)
        {
            if (UserID == null)
            {
                return NotFound();
            }
            else if (UserID != null)
            {
               register = Curd.GetDataByID(UserID);
                
            }
            return Page();
           
        }

        public ActionResult OnPost(Register register)
        {
            bool result = Curd.Update(register);
            if (result == true)
            {
                return RedirectToPage("./UserDetails");
            }
            else
            {
                return RedirectToPage("./Error");
            }
        }
      }
}
