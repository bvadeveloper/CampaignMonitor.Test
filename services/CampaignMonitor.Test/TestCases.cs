using CampaignMonitor.Test.Exceptions;

namespace CampaignMonitor.Test;

public static class TestCases
{
    /// <summary>
    /// Using the most appropriate means, implement an "isNullOrEmpty" check on the standard String type.
    /// It should be functionally equivalent without calling any "isNullOrEmpty" built in function.
    /// </summary>
    /// <returns></returns>
    public static bool isNullOrEmpty(string value) => value == null || value.Length == 0;

    /// <summary>
    /// Write a function that takes a single positive integer, and returns a collection / sequence (e.g. array) of
    /// integers. The return value should contain those integers that are positive divisors of the input integer.
    /// </summary>
    /// <returns></returns>
    public static List<uint> TestCase2(uint input)
    {
        var result = new List<uint>();

        for (uint i = 1; i <= input; i++) // O(n)
        {
            if (input % i == 0)
            {
                result.Add(i);
            }
        }

        return result;
    }

    /// <summary>
    /// Write a function that takes three integer inputs and returns a single output. The inputs are the lengths
    /// of the sides of a triangle. The output is the area of that triangle
    /// </summary>
    /// <returns></returns>
    public static double TestCase3(int a, int b, int c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            throw new InvalidTriangleException("input incorrect");
        }

        var p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    /// <summary>
    /// Write a function that takes an array of integers, and returns an array of integers. The return value
    /// should contain those integers which are most common in the input array.
    /// </summary>
    /// <returns></returns>
    public static List<int> TestCase4(List<int> input)
    {
        var hashSet = new HashSet<int>();
        var output = new List<int>();

        foreach(var i in input)
        {
            if (hashSet.Add(i))
            {
                continue;
            }

            output.Add(i);
        }

        return output.Count == 0 ? hashSet.ToList() : output;
    }
}