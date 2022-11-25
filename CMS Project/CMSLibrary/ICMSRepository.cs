using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLibrary
{
    internal interface ICMSRepository
    {
        int Login(string username, string password);
    }
}
