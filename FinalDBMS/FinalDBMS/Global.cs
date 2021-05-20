using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDBMS
{
    public class Global
    {
        public static string GlobalUserID { get; private set; }
        public static void SetGlobalUserID(string userID)
        {
            GlobalUserID = userID;
        }
    }
}
