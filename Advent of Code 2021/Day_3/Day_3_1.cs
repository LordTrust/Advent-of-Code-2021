using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2021.Day_3
{
    public static class Day_3_1
    {
        public static int Solve()
        {
            string path = @"Day_3\Input.txt";

            string[] input = File.ReadAllLines(path);

            string gammaRate = "", epsilonRate = "";

            for (int i = 0; i < 12; i++)
            {
                int zero = 0, one = 0;
                foreach (string item in input)
                {
                    if(item.Substring(i, 1).Equals("0"))
                    {
                        zero++;
                    }
                    else
                    {
                        one++;
                    }
                }

                if(zero > one)
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                } else
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
            }

            return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
        }
    }
}
