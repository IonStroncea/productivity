using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebSite.Pages
{
    public class LiveDataModel : PageModel
    {
        public Dictionary<int, string> computers { get; set; }

        private IUserDataSource userData;

        public LiveDataModel(IUserDataSource userData)
        {
            this.userData = userData;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.Get("userId") == null)
            {
                return Redirect("/LogIn");
            }

            this.computers = userData.GetAllComputers((int)HttpContext.Session.GetInt32("userId"));

            return Page();
        }
    }
}
