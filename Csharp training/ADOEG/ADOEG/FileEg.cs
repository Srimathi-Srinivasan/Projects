using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ADOEG
{
    internal class FileEg
    {
        public static void Main()
        {
            FileStream fs = new FileStream("message.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs); //like a pen
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            sw.WriteLine(name + " " + DateTime.Now);
            sw.Flush();
            fs.Close();

        }
        

    }
}
