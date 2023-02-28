using Computerinfo;
using ComputerInfo;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text.Json;

namespace WebSite.Pages
{
    public class MyComputersModel : PageModel
    {
        public List<GetComputerInfo> computers = new List<GetComputerInfo>();

        public IActionResult OnGet()
        {
            if (HttpContext.Session.Get("userId") == null)
            {
                return Redirect("/LogIn");
            }

            string uri = "https://localhost:7155/api/ComputerWholeInfo?userId=" + (int)HttpContext.Session.GetInt32("userId");

            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(uri);
            JArray jArray = JArray.Parse(response.Result);

            foreach (JObject item in jArray)
            {
                GetComputerInfo computer = item.ToObject<GetComputerInfo>();

                computer.name = item.GetValue("name").ToString();
                computer.computerId = item.GetValue("computerId").ToObject<int>();
                computer.RAMMb = item.GetValue("ramMb").ToObject<double>();
                computer.userId = item.GetValue("userId").ToObject<int>();

                computers.Add(computer);
            }


            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            string uri = "https://localhost:7155/api/ComputerWholeInfo?computerId=" + id;

            HttpClient client = new HttpClient();
            var response = client.DeleteAsync(uri);

            var result = response.Result;

            return OnGet();
        }
    }
}
