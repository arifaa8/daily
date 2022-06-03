using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreWebApp.Model;
namespace CoreWebApp.Pages
{
    public class OnPostExModel : PageModel
    {
        public void OnGet()
        {
        }

        public string MyData { get; set; }


        public void OnPostSubmit(Person obj)
        {
            this.MyData = obj.FirstName + "  " + obj.LastName;
        }
    }
}
