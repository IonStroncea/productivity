using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ComputerInfo
{
    [DataContract]
    public class MRSInfo
    {
        [DataMember(Order = 1)]
        List<RSInfo> infos = default;

        public MRSInfo() 
        {
            infos = new List<RSInfo>();
            foreach (int type in Enum.GetValues(typeof(RSInfoType)))
            {
                RSInfo info = new RSInfo();
                info.Type = (RSInfoType)Enum.ToObject(typeof(RSInfoType), type);

                infos.Add(info);
            }
        }

        public List<RSInfo> GetInfos() 
        {
            return infos;
        }

        public RSInfo GetInfo(RSInfoType type) 
        {
            List<RSInfo> infosList = infos.Where(x => x.Type == type).ToList();
            if (infosList.Count == 1)
            {
                return infosList[0];
            }
            else 
            {
                return infosList[0].Usage > infosList[1].Usage ? infosList[0] : infosList[1];
            }

        }

        public bool ExistType(RSInfoType type)
        {
            foreach (RSInfo info in infos)
            {
                if (info.Type == type)
                {
                    return true;
                }
            }

            return false;
        }

        public void SetInfo(RSInfo info)
        {
            for (int i = 0; i < infos.Count; i++)
            {
                if (infos[i].Type == info.Type)
                {
                    infos[i] = info;
                }
            }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is MRSInfo))
            {
                return false;
            }

            MRSInfo obj1 = obj as MRSInfo;

            foreach (RSInfo info in infos)
            {
                if (!info.Equals(obj1.GetInfo(info.Type)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
