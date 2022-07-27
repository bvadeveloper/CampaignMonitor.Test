using CampaignMonitor.Test;

namespace CampaignMonitor.Tests;

public class TestsCase1
{

    [Test]
    public void input_null_result_true()
    {
        var isNullOrEmpty = TestCases.isNullOrEmpty(null);
        
        Assert.That(isNullOrEmpty, Is.True);
    }
    
    [Test]
    public void input_single_letter_result_false()
    {
        var isNullOrEmpty = TestCases.isNullOrEmpty("a");
        
        Assert.That(isNullOrEmpty, Is.False);
    }
    
    [Test]
    public void input_empty_string_result_true()
    {
        var isNullOrEmpty = TestCases.isNullOrEmpty("");
        
        Assert.That(isNullOrEmpty, Is.True);
    }
    
    [Test]
    public void input_string_result_false()
    {
        var isNullOrEmpty = TestCases.isNullOrEmpty("null");
        
        Assert.That(isNullOrEmpty, Is.False);
    }
}
