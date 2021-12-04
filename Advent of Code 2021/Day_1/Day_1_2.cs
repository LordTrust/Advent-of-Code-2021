using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2021.Day_1
{
    public static class Day_1_2
    {
        public static int Solve()
        {
            string path = @"Day_1\1_1 _Input.txt";

            string[] _input = File.ReadAllLines(path);
            List<int> input = _input.Select(x => Int32.Parse(x)).ToList();

            int count = 0;
            int tempInt = 0;

            for (int i = 0; i < input.Count - 2; i++)
            {
                int number = input[i] + input[i+1] + input[i+2];
                if (tempInt != 0 && number > tempInt)
                {
                    count++;
                }

                tempInt = number;
            }

            return count;
        }
    }
}
