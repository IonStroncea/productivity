using Computerinfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using WebSite.Services;
using ServerLibrary;
using Newtonsoft.Json;

namespace WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<GetComputerInfo> computers = new List<GetComputerInfo>();
        private string server;
        public UserReaderDTO dto;

        public IndexModel(ILogger<IndexModel> logger, ServerConnectionString serverConnection)
        {
            _logger = logger;
            server = serverConnection.GetConnectionString();
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.Get("userId") != null) 
            {
                IsLogged();
            }
            return Page();
        }

        private void IsLogged()
        {
            string uri = server + "/api/ComputerWholeInfo?userId=" + (int)HttpContext.Session.GetInt32("userId");

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

            uri = server + "/userDTO?userId=" + (int)HttpContext.Session.GetInt32("userId");
            client = new HttpClient();
            var response1 = client.GetStringAsync(uri).Result;
            this.dto = JsonConvert.DeserializeObject<UserReaderDTO>(response1);
        }
    }
}