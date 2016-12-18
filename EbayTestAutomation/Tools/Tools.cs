using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayTestAutomation.Tools
{
    public static class Tool
    {
        public static string GenerateNumbers()
        {
            return DateTime.Now.ToString("MMddyyHmmss");
        }
    }
}
