using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserDataSource
    {
        Dictionary<int, string> GetAllComputers(int userId);

        Dictionary<string, string> GetUserDTO(int userId);

        int CreateComputer(int userId, string compName);
    }
}
