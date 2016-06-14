using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Net;

namespace MiniTrader
{
    class Program
    {
        static string HttpGet(string url)
        {
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        static void Main(string[] args)
        {
            dynamic rates = JValue.Parse(HttpGet("http://api.fixer.io/latest?symbols=NOK&base=USD"));
            Console.WriteLine(rates);
            var dateTime = DateTime.ParseExact(rates.date.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Console.WriteLine(dateTime);
            Console.ReadKey();
            //JsonConvert.DeserializeObject()
        }
    }
}
