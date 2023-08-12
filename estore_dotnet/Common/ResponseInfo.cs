using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estore_dotnet.Common
{
    public class ResponseInfo
    {
        public int Code { set; get; }

        public string Msg { set; get; } = "";

        public ResponseInfo()
        {
            Code = CodeResponse.OK;
            Msg = "";
        }
    }
}