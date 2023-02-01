using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRegister
    {
        int Register(string userName, string userNickName, string passKey);
    }
}
