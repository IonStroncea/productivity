using ComputerInfo;
using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllSavedValuesController : ControllerBase
    {
        private IDataSender dataSender;

        public AllSavedValuesController(IDataSender dataSender)
        {
            this.dataSender = dataSender;
        }

        [HttpGet]
        public List<RSInfo> GetAllByType(string type, int computerId, int userId)
        {
            RSInfoType rSInfo = (RSInfoType)Enum.Parse(typeof(RSInfoType), type);

            List<RSInfo> result = dataSender.GetAllRSInfoByType(computerId, rSInfo);

            return result;
        }
    }
}
