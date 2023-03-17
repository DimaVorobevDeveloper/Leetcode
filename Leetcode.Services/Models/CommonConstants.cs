using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Services.Models
{
    public class CommonConstants
    {
        public static Dictionary<char, char> CharDict = new()
        {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'},
        };
    }
}
