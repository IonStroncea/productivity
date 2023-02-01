using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ComputerInfo
{
    public class RSInfoSend
    {
        public RSInfo info { get; set;}

        public bool sendStatus { get; set;}

        public RSInfoSend() { }

        public RSInfoSend(RSInfo info) 
        { 
            this.info = info;
            sendStatus = false;
        }

        public RSInfoSend(RSInfo info, bool sendStatus) 
        {
            this.info = info;
            this.sendStatus = sendStatus;
        }

        public override string ToString()
        {
            return $"Send status : {sendStatus} {info.ToString()}";
        }

        public string TextSave()
        {
            return $"{(sendStatus ? 1 : 0)}*{info.TextSave()}";
        }

        public RSInfoSend(string text)
        {
            sendStatus = text[0] == '1' ? true : false;

            info = new RSInfo(text.Substring(2));
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is RSInfoSend))
            {
                return false;
            }
            RSInfoSend obj1 = obj as RSInfoSend;

            if ((sendStatus == obj1.sendStatus) && info.Equals(obj1.info))
            {
                return true;
            }

            return false;
        }
    }
}
