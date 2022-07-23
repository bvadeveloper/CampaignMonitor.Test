using CampaignMonitor.Test;

namespace CampaignMonitor.Tests;

public class TestsCase2
{
    [Test]
    public void Check_positive_divisors_for_6o_return_correct_sequence()
    {
        var result = TestCases.TestCase2(60);

        CollectionAssert.AreEqual(new List<uint> { 1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, 60 }, result);
    }
    
    [Test]
    public void Check_positive_divisors_for_42_return_correct_sequence()
    {
        var result = TestCases.TestCase2(42);

        CollectionAssert.AreEqual(new List<uint> {1, 2, 3, 6, 7, 14, 21, 42}, result);
    }
}