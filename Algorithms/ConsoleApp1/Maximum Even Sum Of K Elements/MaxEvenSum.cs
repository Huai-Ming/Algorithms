using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleGround.Maximum_Even_Sum_Of_K_Elements
{
    public class MaxEvenSum
    {
        public static int GetMaxEvenSum(int[] array, int k)
        {
            if (k > array.Length || array.Length == 0)
            {
                return -1;
            }

            var evenList = new List<int>();
            var oddList = new List<int>();

            array = array.OrderByDescending(e => e).ToArray();

            foreach (var item in array)
            {
                if (item % 2 == 0)
                {
                    evenList.Add(item);
                }
                else
                {
                    oddList.Add(item);
                }
            }

            var evenIndex = 0;
            var oddIndex = 0;
            var maxSum = 0;

            while(k > 0)
            {
                if (k % 2 == 1)
                {
                    if (evenList.Any())
                    {
                        maxSum += evenList[evenIndex];
                        evenIndex++;
                        k--;
                    }
                    else
                    {
                        maxSum = -1;
                        return maxSum;
                    }
                }
                else
                {
                    if (evenIndex < evenList.Count - 1 && oddIndex < oddList.Count - 1)
                    {
                        var evenMax = evenList[evenIndex] + evenList[evenIndex + 1];
                        var oddMax = oddList[oddIndex] + oddList[oddIndex + 1];
                        if (evenMax > oddMax)
                        {
                            maxSum += evenMax;
                            evenIndex += 2;
                        }
                        else
                        {
                            maxSum += oddMax;
                            oddIndex += 2;
                        }
                      
                        
                    }
                    else if (evenIndex < evenList.Count - 1)
                    {
                        maxSum += evenList[evenIndex] + evenList[evenIndex + 1];
                        evenIndex += 2;
                    }
                    else if (oddIndex < oddList.Count - 1)
                    {
                        maxSum += oddList[oddIndex] + oddList[oddIndex + 1];
                        oddIndex += 2;
                    }
                    else
                    {
                        return -1;
                    }

                    k -= 2;
                }
            }


            return maxSum;
        }

        static void Main(string[] args)
        {
           Console.WriteLine(GetMaxEvenSum(new []{7,7,7,7,7},4));
           Console.Read();
        }
    }
}
