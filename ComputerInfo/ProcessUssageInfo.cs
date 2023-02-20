using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ComputerInfo
{
    [DataContract]
    public class ProcessUssageInfo
    {
        [DataMember(Order = 1)]
        public int id { get; set; }

        [DataMember(Order = 2)]
        public string name { get; set; }

        [DataMember(Order = 3)]
        public double ussage { get; set; }

        [DataMember(Order = 4)]
        public double ramUssage { get; set; }

        public ProcessUssageInfo()
        { }

        public ProcessUssageInfo(int id, string name, double ussage, double ramUssage)
        {
            this.id = id;
            this.name = name;
            this.ussage = ussage;
            this.ramUssage = ramUssage;
        }

        public ProcessUssageInfo(ProcessUssage processUssage)
        { 
            this.id = processUssage.id;

            this.name = processUssage.name;

            this.ussage= processUssage.ussage;

            this.ramUssage= processUssage.ramUssage;
        }
    }
}
