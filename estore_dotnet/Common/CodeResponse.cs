using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estore_dotnet.Common
{
    public class CodeResponse
    {
        /// <summary>
        /// Code Response 200
        /// </summary>
        public static readonly int OK = 200;

        /// <summary>
        /// Code Response 500
        /// </summary>
        public static readonly int SERVER_ERROR = 500;

        /// <summary>
        /// Code Response 404
        /// </summary>
        public static readonly int NOT_FOUND = 404;
        
        /// <summary>
        /// Code Response 401
        /// </summary>
        public static readonly int NOT_LOGIN = 401;
        
        /// <summary>
        /// Code Response 403
        /// </summary>
        public static readonly int NOT_ACCESS = 403;
        
        /// <summary>
        /// Code Response 201
        /// </summary>
        public static readonly int NOT_VALIDATE = 201;
        
        /// <summary>
        /// Code Response 202
        /// </summary>
        public static readonly int HAVE_ERROR = 202;
    }
}