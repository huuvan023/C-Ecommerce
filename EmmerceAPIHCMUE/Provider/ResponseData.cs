using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Provider
{
    public class ResponseData
    {
        private int code = 0;
        private string message;
        private object data;
        public ResponseData(int status, string message, object data)
        {
            Code = status;
            Message = message;
            this.data = data;
        }

        public int Code { get => code; set => code = value; }
        public string Message { get => message; set => message = value; }
        public object Data { get => data; set => data = value; }
    }
}
