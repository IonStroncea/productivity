using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogin userLogin;
        private IUserDataSource userData;

        public UserController(ILogin userLogin, IUserDataSource userData) 
        {
            this.userLogin = userLogin;
            this.userData = userData;
        }

        [HttpGet("/logInComputer")]
        public string LogInWith(string username, string password, string compName, string newComp)
        {
            int userId = userLogin.Login(username, password);
            int compId = 0;

            if (!Boolean.Parse(newComp))
            {
                compId = userData.GetAllComputers(userId).Where(x => x.Value == compName).First().Key;
            }
            else 
            {
                compId = userData.CreateComputer(userId, compName);
            }

            if (userId != -1)
            {
                return $"{userId}=={username}=={password}=={compId}";
            }

            return "Error";
        }

        [HttpGet]
        public Dictionary<int, string> LogIn(string username, string password)
        {
            int userId = userLogin.Login(username, password);

            if (userId != -1)
            {
                return userData.GetAllComputers(userId);
            }

            return null;
        }
    }
}
