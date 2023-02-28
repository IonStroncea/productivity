using Computerinfo;
using ComputerInfo;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary;
using System.Text.Json;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerWholeInfoController : ControllerBase
    {
        private IDataSender dataSender;
        private IComputerDAL computerDAL;

        public ComputerWholeInfoController(IDataSender dataSender, IComputerDAL computerDAL)
        {
            this.dataSender = dataSender;
            this.computerDAL = computerDAL;
        }

        [HttpGet]
        public List<GetComputerInfo> GetComputersWholeInfo(int userId)
        { 
            List<GetComputerInfo> resultComp = dataSender.GetWholeComputersInfo(userId);

            return resultComp;
        }

        [HttpDelete]
        public bool DeleteComputer(int computerId)
        {
            return computerDAL.DeteleComputer(computerId);
        }
    }
}
