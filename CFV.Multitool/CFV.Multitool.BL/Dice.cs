using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFV.Multitool.BL
{
    public static class Dice
    {
        public static int Roll (int number, int sides) {
            int sum = 0;
            Random random = new Random();
            for (int i = 0;  i < number; i++)
            {
                sum += random.Next(1, sides + 1);
            }
            return sum;
        }
    }
}
