using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2021.Day_6
{
    public static class Day_6_2
    {
        public static UInt64 Solve()
        {
            string path = @"Day_6\Input.txt";
            string[] input = File.ReadAllLines(path);

            Dictionary<int, UInt64> fishes = new Dictionary<int, UInt64>();

            for (int i = 0; i < 9; i++)
            {
                fishes.Add(i, 0);
            }

            foreach (string item in input[0].Split(','))
            {
                fishes[int.Parse(item)]++;
            }

            for (int i = 0; i < 256; i++)
            {
                UInt64 newFishes = 0;
                UInt64 oldNewFishes = 0;

                for (int j = 0; j < 9; j++)
                {
                    if(j == 0)
                    {
                        oldNewFishes += fishes[0];
                        newFishes += fishes[0];
                        fishes[0] = 0;
                    } else
                    {
                        fishes[j - 1] += fishes[j];
                        fishes[j] = 0;
                    }
                }

                fishes[8] += newFishes;
                fishes[6] += oldNewFishes;
            }

            UInt64 returnValue = 0;
               
            for (int i = 0; i < 9; i++)
            {
                returnValue += fishes[i]; 
            }

            return returnValue;
        }
    }
}
