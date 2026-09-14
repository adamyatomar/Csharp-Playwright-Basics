using System;

namespace Framework.Utils
{
    public class FrameworkUtils
    {
        public string GetCustomTimestamp()
        {
            
            return DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
        }
        

    }

}