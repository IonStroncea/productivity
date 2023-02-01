using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebSite.Pages
{
    public class LogInModel : PageModel
    {
        public string Message { get; set; }

        private ILogin userLogin;

        public LogInModel(ILogin userLogin)
        {
            this.userLogin = userLogin;
        }

        public void OnGet()
        {
            HttpContext.Session.Clear();
        }

        public IActionResult OnPost() 
        {
            string userName = Request.Form["userName"];
            string password = Request.Form["password"];

            int userId = userLogin.Login(userName, password);

            if (userId != -1)
            {
                HttpContext.Session.SetInt32("userId", userId);

                return Redirect("/");
            }

            this.Message = "Wrong credentials";
            return Page();            
        }
    }
}
