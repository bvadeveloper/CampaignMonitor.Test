using CampaignMonitor.Test;
using CampaignMonitor.Test.Exceptions;

namespace CampaignMonitor.Tests;

public class TestsCase3
{
    [Test]
    public void Calculate_area_for_triangle_with_3_4_5_return_correct_value()
    {
        const double area = 6;
        var result = TestCases.TestCase3(3, 4, 5);

        Assert.That(area, Is.EqualTo(result));
    }

    [Test]
    public void Calculate_area_with_negative_values_throw_correct_exception()
    {
        Assert.Throws<InvalidTriangleException>(() => TestCases.TestCase3(-3, 4, 5));
    }
    
    [Test]
    public void Calculate_area_with_zero_values_throw_correct_exception()
    {
        Assert.Throws<InvalidTriangleException>(() => TestCases.TestCase3(3, 0, 5));
    }
}