using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ThreadsEg
{
    class asyncwait
    {
        public async Task<string> firstmethod()
        {
            await Task.Delay(5000);
            return "good";
        }
        public static void main()
        {
            asyncwait obj = new asyncwait();
            var data = obj.firstmethod().Result;
            Console.WriteLine(data);
        }
    }
}