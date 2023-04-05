using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSite.Services;

namespace WebSite.Pages
{
    public class LiveDataModel : PageModel
    {
        public Dictionary<int, string> computers { get; set; }
        public string server;

        private IUserDataSource userData;

        public LiveDataModel(IUserDataSource userData, ServerConnectionString serverConnection)
        {
            this.userData = userData;
            server = serverConnection.GetConnectionString();
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
