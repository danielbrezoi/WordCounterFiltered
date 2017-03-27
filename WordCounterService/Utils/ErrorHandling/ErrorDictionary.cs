using System;
using System.IO;
using System.Collections.Generic;

namespace WordCounterService.Utils
{
    /// <summary>
    /// This class can be use to get the custom message for each type of message
    /// </summary>
    public class ErrorDictionary : Dictionary<Type, string>
    {
        private static IDictionary<Type, string> _errorDictionary = new Dictionary<Type, string>() 
        {
            { typeof(ArgumentException), "Argument exception at: " },
            { typeof(PathTooLongException), "Path is to long at: " },
            { typeof(DirectoryNotFoundException), "Directory not found at: " },
            { typeof(IOException), "IOException not found at: " },
            { typeof(UnauthorizedAccessException), "Unauthorized Access at: " },
            { typeof(NotSupportedException), "Not supported at: " },
            { typeof(System.Security.SecurityException), "Directory not found at: " },
            { typeof(Exception), "Am unknow exception has ocured: " }
        };
        
        public ErrorDictionary()
        :base(_errorDictionary)
        {
        }
    }
}
