using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebSite.Pages
{
    public class RegisterModel : PageModel
    {
        public string Message { get; set; }

        private IRegister register;

        public RegisterModel(IRegister register)
        {
            this.register = register;    
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string userName = Request.Form["userName"];
            string password = Request.Form["password"];
            string userNickName = Request.Form["userNickName"];

            int userId = register.Register(userName, userNickName, password);

            if (userId != -1)
            {
                HttpContext.Session.Clear();
                HttpContext.Session.SetInt32("userId", userId);

                return Redirect("/");
            }

            this.Message = "Wrong credentials";
            return Page();
        }
    }
}
