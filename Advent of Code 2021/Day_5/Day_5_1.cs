using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2021.Day_5
{
    public static class Day_5_1
    {
        public static int Solve()
        {
            string path = @"Day_5\Input.txt";

            string[] input = File.ReadAllLines(path);
            List<List<int>> grid = new List<List<int>>();
            List<List<int>> lines = new List<List<int>>();

            int maxX = 0;
            int maxY = 0;

            foreach (string line in input)
            {
                string[] splittedLine = line.Split(" -> ");

                List<int> tempCords = new List<int>();

                foreach (string item in splittedLine)
                {
                    string[] temp = item.Split(',');
                    tempCords.Add(Int32.Parse(temp[0]));
                    tempCords.Add(Int32.Parse(temp[1]));
                }

                List<int> tempSave = new List<int>();

                if(tempCords[0] == tempCords[2])
                {
                    if (tempCords[1] < tempCords[3])
                    {
                        tempSave.Add(tempCords[0]);
                        tempSave.Add(tempCords[1]);
                        tempSave.Add(0);
                        tempSave.Add(tempCords[3] - tempCords[1]);
                    } else
                    {
                        tempSave.Add(tempCords[2]);
                        tempSave.Add(tempCords[3]);
                        tempSave.Add(0);
                        tempSave.Add(tempCords[1] - tempCords[3]);
                    }

                    lines.Add(tempSave);
                } else if(tempCords[1] == tempCords[3])
                {
                    if (tempCords[0] < tempCords[2])
                    {
                        tempSave.Add(tempCords[0]);
                        tempSave.Add(tempCords[1]);
                        tempSave.Add(tempCords[2] - tempCords[0]);
                        tempSave.Add(0);
                    }
                    else
                    {
                        tempSave.Add(tempCords[2]);
                        tempSave.Add(tempCords[3]);
                        tempSave.Add(tempCords[0] - tempCords[2]);
                        tempSave.Add(0);
                    }
                    lines.Add(tempSave);
                }

                if (maxX == 0) maxX = (tempCords[0] >= tempCords[2]) ? tempCords[0] : tempCords[2];
                if (maxY == 0) maxY = (tempCords[1] >= tempCords[3]) ? tempCords[1] : tempCords[3];
                if (tempCords[0] > maxX || tempCords[2] > maxX) maxX = (tempCords[0] >= tempCords[2]) ? tempCords[0] : tempCords[2];
                if (tempCords[1] > maxY || tempCords[3] > maxY) maxY = (tempCords[1] >= tempCords[3]) ? tempCords[1] : tempCords[3];
            }

            for (int i = 0; i < maxY + 1; i++)
            {
                grid.Add(new List<int>());
                for (int j = 0; j < maxX + 1; j++)
                {
                    grid[i].Add(0);
                }
            }

            int iiii = grid.Count;

            foreach (List<int> item in lines)
            {
                if (item[2] == 0)
                {
                    for (int i = 0; i < item[3] + 1; i++)
                    {
                        grid[item[1] + i][item[0]] += 1;
                    }
                } else if(item[3] == 0)
                {
                    for (int i = 0; i < item[2] + 1; i++)
                    {
                        grid[item[1]][item[0] + i] += 1;
                    }
                }
            }

            int count = 0;

            foreach (List<int> item in grid)
            {
                foreach (int number in item)
                {
                    if (number >= 2) count++;
                }
            }
            /*
            foreach (List<int> item in grid)
            {
                foreach (int number in item)
                {
                    Console.Write(number);
                }
                Console.Write(Environment.NewLine);
            }
            */
            return count;
        }
    }
}
