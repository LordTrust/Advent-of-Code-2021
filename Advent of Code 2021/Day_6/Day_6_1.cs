using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2021.Day_6
{
    public static class Day_6_1
    {
        public static int Solve()
        {
            string path = @"Day_6\Input.txt";
            string[] input = File.ReadAllLines(path);

            List<int> fishes = new List<int>();

            foreach (string item in input[0].Split(','))
            {
                fishes.Add(int.Parse(item));
            }

            for (int i = 0; i < 80; i++)
            {
                int newFishes = 0;
                for (int j = 0; j < fishes.Count; j++)
                {
                    if(fishes[j] == 0)
                    {
                        fishes[j] = 6;
                        newFishes++;
                    } else
                    {
                        fishes[j]--;
                    }
                }

                for (int j = 0; j < newFishes; j++)
                {
                    fishes.Add(8);
                }
            }

            return fishes.Count;
        }
    }
}
