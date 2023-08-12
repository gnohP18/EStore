using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estore_dotnet.Common
{
    public class MsgResponse
    {
        /// <summary>
        /// Mgs Success
        /// </summary> 
        public static string SUCCESS = "SUCCESS";
        
        /// <summary>
        /// Mgs Failure
        /// </summary>
        public static string FAILURE = "FAILURE";
    
        /// <summary>
        /// Mgs Update
        /// </summary>
        public static string UPDATE = "UPDATE"; 
    
        /// <summary>
        /// Mgs Create
        /// </summary>
        public static string CREATE = "CREATE"; 
    
        /// <summary>
        /// Mgs Create
        /// </summary>
        public static string DELETE = "DELETE"; 
    }
}