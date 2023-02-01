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
    public class RSInfo
    {
        [DataMember(Order = 1)]
        public RSInfoType Type { get; set; }

        [DataMember(Order = 2)]
        public int Usage { get; set; }

        [DataMember(Order = 3)]
        public DateTime Date { get; set; }
        

        public RSInfo()
        {
            DateTime Date1 = DateTime.UtcNow;
            Date = new DateTime(Date1.Year, Date1.Month, Date1.Day, Date1.Hour, Date1.Minute, Date1.Second, Date1.Kind);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is RSInfo))
            {
                return false;
            }

            RSInfo obj1= obj as RSInfo;

            DateTime simpler = new DateTime(Date.Year, Date.Month, Date.Day, Date.Hour, Date.Minute, Date.Second, Date.Kind);

            if ((Type == obj1.Type) && (Usage == obj1.Usage) && (simpler == obj1.Date))
            {
                return true;
            }

            return false;
        }

        public RSInfo(RSInfoType type, int usage, DateTime date)
        {
            Type = type;
            Date = date;
            Usage = usage;
        }

        public RSInfo(string text)
        {
            string[] strings = text.Split('*');

            RSInfoType type = (RSInfoType)Enum.Parse(typeof(RSInfoType), strings[0], true);
            int usage = int.Parse(strings[1]);
            DateTime date = DateTime.ParseExact(strings[2], "dd-MMM-yy HH:mm:ss", null);
            
            Type = type;
            Usage = usage;
            Date = date;
        }

        public string TextSave()
        {
            return ($"{Type}*{Usage}*{Date.ToString("dd-MMM-yy HH:mm:ss")}");
        }

        public override string ToString()
        {
            return ($"type : {Type}  usage : {Usage}  date : {Date.ToString("dd-MMM-yy HH:mm:ss")}");
        }

        public override int GetHashCode()
        {
            return Date.GetHashCode() + Usage * 100 + (int)Type;
        }
    }
}
