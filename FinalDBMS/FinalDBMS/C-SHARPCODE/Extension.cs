using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDBMS
{
    public static class Extension
    {
        public static string Substring2(this string value, int startIndex, int endIndex)
        {
            return value.Substring(startIndex, (endIndex - startIndex + 1));
        }
    }
}
