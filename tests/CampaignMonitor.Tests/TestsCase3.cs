using CampaignMonitor.Test;
using CampaignMonitor.Test.Exceptions;

namespace CampaignMonitor.Tests;

public class TestsCase3
{
    [Test]
    public void triangle_area_with_lenght_3_4_5_is_6()
    {
        const double area = 6;
        var result = TestCases.TestCase3(3, 4, 5);

        Assert.That(area, Is.EqualTo(result));
    }

    [Test]
    public void calculate_area_with_negative_values_throw_exception()
    {
        Assert.Throws<InvalidTriangleException>(() => TestCases.TestCase3(-3, 4, 5));
    }
    
    [Test]
    public void calculate_area_with_zero_values_throw_exception()
    {
        Assert.Throws<InvalidTriangleException>(() => TestCases.TestCase3(3, 0, 5));
    }
}
