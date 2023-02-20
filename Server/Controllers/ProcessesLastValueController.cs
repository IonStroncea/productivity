using ComputerInfo;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessesLastValueController : ControllerBase
    {
        private IDataSender dataSender;

        public ProcessesLastValueController(IDataSender dataSender)
        {
            this.dataSender = dataSender;
        }

        [HttpGet]
        public List<ProcessUssageInfo> GetLastProcessUssageInfo(int computerId)
        {
            List<ProcessUssageInfo> result = dataSender.GetLatestUssageInfo(computerId);

            return result;
        }
    }
}
