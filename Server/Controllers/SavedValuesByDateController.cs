using ComputerInfo;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedValuesByDateController : ControllerBase
    {
        private IDataSender dataSender;

        public SavedValuesByDateController(IDataSender dataSender)
        {
            this.dataSender = dataSender;
        }

        [HttpGet]
        public List<RSInfo> GetAllByTypeAndDate(string type,int computerId, int userId, string startDate, string endtDate)
        {
            RSInfoType rSInfo = (RSInfoType)Enum.Parse(typeof(RSInfoType), type);

            List<RSInfo> result = dataSender.GetAllRSInfoByTypeAndDate100(rSInfo, computerId, userId, startDate, endtDate);

            return result;
        }
    }
}
