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

        double GetCPUFreqGHZ();

        double GetCPUFreqMHZ();

        void RenewData();

        List<string> GetCPUName();

        List<String> GetGPUName();
    }
}
