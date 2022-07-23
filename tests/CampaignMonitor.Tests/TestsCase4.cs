using CampaignMonitor.Test;

namespace CampaignMonitor.Tests;

public class TestsCase4
{
    [Test]
    public void Maximum_number_of_repeatable_items_is_5_and_4()
    {
        var result = TestCases.TestCase4(new List<int> { 5, 4, 3, 2, 4, 5, 1, 6, 1, 2, 5, 4 });

        CollectionAssert.AreEqual(new List<uint> { 5, 4 }, result);
    }

    [Test]
    public void Maximum_number_of_repeatable_items_is_1()
    {
        var result = TestCases.TestCase4(new List<int> { 1, 2, 3, 4, 5, 1, 6, 7 });

        CollectionAssert.AreEqual(new List<uint> { 1 }, result);
    }

    [Test]
    public void Maximum_number_of_repeatable_items_is_valid_sequence()
    {
        var result = TestCases.TestCase4(new List<int> { 1, 2, 3, 4, 5, 6, 7 });

        CollectionAssert.AreEqual(new List<uint> { 1, 2, 3, 4, 5, 6, 7 }, result);
    }
}