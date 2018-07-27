using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTemplate.Helpers
{
    public class Libs
    {
        public static string CreateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            return token;
        }
    }
    public class DatetimeHelper
    {
        public static string formatDatetime(string formatStr)
        {
            return null;
        }
        public static DateTime convertToUtc(DateTime datetime)
        {
            return datetime.ToUniversalTime();
        }
        public static DateTime formatEndDate(DateTime datetime)
        {
            return datetime;
        }
        public static DateTime formatStartDate(DateTime datetime)
        {
            return datetime;
        }
    }
    public class Response
    {
        public string success { get; set; }
        public string data { get; set; }
        public string message { get; set; }
    }
}
