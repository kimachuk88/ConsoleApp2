using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.utils
{
    class Util
    {
        public static string GetRandomItemFromList(List<string> items)
        {
            Random rand = new Random();
            int index = rand.Next(items.Count);
            return items[index];
        }
    }
}
