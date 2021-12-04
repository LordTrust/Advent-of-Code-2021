using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2021.Day_2
{
    public static class Day_2_2
    {
        public static int Solve()
        {
            string path = @"Day_2\2_1_Input.txt";

            string[] input = File.ReadAllLines(path);

            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach (string item in input)
            {
                string[] parts = item.Split(' ');
                switch (parts[0])
                {
                    case "forward":
                        int value = Int32.Parse(parts[1]);
                        horizontal += value;
                        depth += aim * value;
                        break;
                    case "down":
                        aim += Int32.Parse(parts[1]);
                        break;
                    case "up":
                        aim -= Int32.Parse(parts[1]);
                        break;
                }
            }

            return horizontal * depth;
        }
    }
}
