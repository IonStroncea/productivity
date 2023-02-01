using ServerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ComputerInfo;
using Common;
using ServerLibraryTest;

namespace ServerConsoleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataSender sender = new DataSender(new DataSource(new ConnectionStringProvider()), new Cache());

            List<RSInfo> infos = sender.GetAllRSInfo(1);

            infos.ForEach(x => Console.WriteLine($"{x.Type}  {x.Usage}  {x.Date}"));

            Console.WriteLine();



            infos = sender.GetAllRSInfoByType(1, RSInfoType.CPU);

            infos.ForEach(x => Console.WriteLine($"{x.Type}  {x.Usage}  {x.Date}"));

            Console.WriteLine();



            infos = sender.GetAllRSInfoByType(1, RSInfoType.GPU);

            infos.ForEach(x => Console.WriteLine($"{x.Type}  {x.Usage}  {x.Date}"));

            Console.WriteLine();



            infos = sender.GetAllRSInfoByType(1, RSInfoType.RAM);

            infos.ForEach(x => Console.WriteLine($"{x.Type}  {x.Usage}  {x.Date}"));

            Console.WriteLine();



            List<MRSInfo> mRSInfos = sender.GetAllMRSInfo(1);

            foreach (MRSInfo mRSInfo in mRSInfos)
            {
                mRSInfo.GetInfos().ForEach(x => Console.WriteLine($"{x.Type}  {x.Usage}  {x.Date}"));
            }

            Console.WriteLine();

        }
    }
}
