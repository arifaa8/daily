using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreWebApp.Pages
{
    public class DemoModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()  // This will get the data when page get loaded
        {
            Message = "Hello World !" + "Current Time is :" + System.DateTime.Now.ToShortDateString();
        }

        public void OnPost()  // This will get the data when page get loaded
        {
        }
     }
}
