using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computerinfo
{
    public interface IGetComputerInfo
    {
        double GetRAMMB();

        double GetRAMGB();

        List<double> GetCPUFreqGHZ();

        List<double> GetCPUFreqMHZ();

        void RenewData();

        List<string> GetCPUName();

        List<string> GetGPUName();
    }
}
