using System;

namespace AdventOfCodeCS._2015
{
    public class Day17
    {
        public void Run()
        {
            var input = new [] { 43,3,4,10,21,44,4,6,47,41,34,17,17,44,36,31,46,9,27,38 };
            var goal = 150;
            var permutations = 0;
            var minContainerCount = int.MaxValue;

            var max = Math.Pow(2, input.Length);
            for (var iteration = 2; iteration < max; iteration++)
            {
                var sum = 0;
                var containerCount = 0;
                for (var i = 0; i < input.Length; i++)
                {
                    var mask = 1 << i;
                    if ((iteration & mask) == mask)
                    {
                        containerCount++;
                        sum += input[i];
                    }
                }

                if (sum == goal)
                {
                    if (containerCount < minContainerCount)
                    {
                        permutations = 0;
                        minContainerCount = containerCount;
                    }

                    if (containerCount == minContainerCount)
                    {
                        permutations++;
                    }
                }
            }

            Console.WriteLine(permutations);

        }
    }
}