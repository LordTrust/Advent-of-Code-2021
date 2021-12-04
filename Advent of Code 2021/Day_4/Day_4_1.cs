using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2021.Day_4
{
    public static class Day_4_1
    {
        public static int Solve()
        {
            string path = @"Day_4\Input.txt";

            string[] input = File.ReadAllLines(path);

            string[] numbers = new string[27];

            List<List<string>> boards = new List<List<string>>();

            int index = -1;
            foreach (string item in input)
            {
                if (item.Length > 14)
                {
                    numbers = item.Split(',');
                }

                if (item.Equals(""))
                {
                    index++;
                    boards.Add(new List<string>());
                    continue;
                }

                if (index < 0) continue;
                boards[index].Add(string.Join(' ', RowSplit(item)));
            }

            List<Tuple<List<string>, int>> tuples = new List<Tuple<List<string>, int>>();

            for (int i = 0; i < boards.Count; i++)
            {
                Tuple<List<string>, int> tempIndex = CheckBoard(boards[i], numbers);

                tuples.Add(CheckBoard(boards[i], numbers));
            }

            int highestCount = tuples[0].Item2;
            int highestCountIndex = 0;

            for (int i = 1; i < tuples.Count; i++)
            {
                if (tuples[i].Item2 < highestCount)
                {
                    highestCountIndex = i;
                    highestCount = tuples[i].Item2;
                }
            }

            Tuple<List<string>, int> tuple = tuples[highestCountIndex];

            Console.WriteLine($"{highestCountIndex} {tuple.Item2}");

            tuple.Item1.RemoveAll(x => x.Equals("-1"));

            int zusammengezählt = 0;

            foreach (string item in tuple.Item1)
            {
                foreach (string item2 in RowSplit(item))
                {
                    zusammengezählt += Int32.Parse(item2) == -1 ? 0 : Int32.Parse(item2);
                }
            }



            return zusammengezählt *= Int32.Parse(numbers[tuple.Item2]);
        }

        private static Tuple<List<string>, int> CheckBoard(List<string> _input, string[] numbers)
        {
            int times = 0;
            List<string> input = new List<string>(_input);
            foreach (string _number in numbers)
            {
                string number = _number;

                if (Int32.Parse(number) < 10)
                {
                    number = "0" + _number;
                }

                for (int i = 0; i < input.Count; i++)
                {
                    string[] rowSplitted = RowSplit(input[i]).ToArray();

                    if (rowSplitted.Contains(number))
                    {
                        rowSplitted[Array.IndexOf(rowSplitted, number)] = "-1";
                    }

                    input[i] = string.Join(" ", rowSplitted);
                }

                foreach (string item in input)
                {
                    if (checkRow(item))
                    {
                        //return times;
                        return new Tuple<List<string>, int>(input, times);
                    }
                }

                if (checkColumns(input))
                {
                    return new Tuple<List<string>, int>(input, times);
                }

                times++;
            }

            return new Tuple<List<string>, int>(input, times);
        }

        private static bool checkRow(string input)
        {
            List<string> _input = RowSplit(input);
            _input.RemoveAll(x => !x.Equals("-1"));


            if (_input.Count == 5)
            {
                return true;
            }

            return false;
        }

        private static bool checkColumns(List<string> input)
        {
            for (int i = 0; i < 5; i++)
            {
                List<string> numbers = new List<string>();
                foreach (string item in input)
                {
                    numbers.Add(RowSplit(item)[i]);
                }

                numbers.RemoveAll(x => !x.Equals("-1"));

                if (numbers.Count == 5)
                {
                    return true;
                }
            }

            return false;
        }

        private static List<string> RowSplit(string row)
        {
            string[] returningValue = new string[5];

            returningValue[0] = RemoveWhitespace(row.Substring(0, 2));
            returningValue[1] = RemoveWhitespace(row.Substring(3, 2));
            returningValue[2] = RemoveWhitespace(row.Substring(6, 2));
            returningValue[3] = RemoveWhitespace(row.Substring(9, 2));
            returningValue[4] = RemoveWhitespace(row.Substring(12, 2));

            return returningValue.ToList();
        }

        private static string RemoveWhitespace(string input)
        {
            return new string(input.Replace(" ", "0"));
        }
    }
}
