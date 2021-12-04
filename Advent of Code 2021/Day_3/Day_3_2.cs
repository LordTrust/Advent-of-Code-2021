using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2021.Day_3
{
    public static class Day_3_2
    {
        public static int Solve()
        {
            string path = @"Day_3\Input.txt";

            string[] Originput = File.ReadAllLines(path);

            string[] input = (string[])Originput.Clone();

            string co2Scrubber = Filter(input, false); 
            string oxygenGenerator = Filter(input, true);

            return Convert.ToInt32(co2Scrubber, 2) * Convert.ToInt32(oxygenGenerator, 2);
        }

        private static string Filter(string[] _input, bool mostSignificant)
        {
            List<string> inputOrig = _input.ToList();
            List<string> input = new List<string>(inputOrig);

            for (int i = 0; i < 12; i++)
            {
                string criteria = mostSignificant ? GetMostSignificant(i, input) : GetLeastSignificant(i, input);

                for (int j = 0; j < input.Count; j++)
                {
                    if(!input[j].Substring(i, 1).Equals(criteria))
                    {
                        input[j] = "";
                    }
                }

                input.RemoveAll(value => value.Equals(""));

                if(input.Count == 1)
                {
                    return input[0];
                }
            }

            return "0";
        }

        private static string GetMostSignificant(int index, List<string> input)
        {
            int zero = 0, one = 0;
            foreach (string item in input)
            {
                if (item.Substring(index, 1).Equals("0"))
                {
                    zero++;
                }
                else if (item.Substring(index, 1).Equals("1"))
                {
                    one++;
                }
            }

            if (one >= zero)
            {
                return "1";
            } else if (zero > one)
            {
                return "0";
            } else
            {
                return "-1";
            }
        }

        private static string GetLeastSignificant(int index, List<string> input)
        {
            int zero = 0, one = 0;
            foreach (string item in input)
            {
                if (item.Substring(index, 1).Equals("0"))
                {
                    zero++;
                }
                else if (item.Substring(index, 1).Equals("1"))
                {
                    one++;
                }
            }

            if (one < zero)
            {
                return "1";
            }
            else if (zero <= one)
            {
                return "0";
            } else
            {
                return "-1";
            }
        }
    }
}
