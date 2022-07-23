using CampaignMonitor.Test;

namespace CampaignMonitor.Tests;

public class TestsCase1
{

    [Test]
    public void Check_if_input_null_as_result_true()
    {
        var isNullOrEmpty = TestCases.isNullOrEmpty(null);
        
        Assert.That(isNullOrEmpty, Is.True);
    }
    
    [Test]
    public void Check_if_input_letter_a_as_result_false()
    {
        var isNullOrEmpty = TestCases.isNullOrEmpty("a");
        
        Assert.That(isNullOrEmpty, Is.False);
    }
    
    [Test]
    public void Check_if_input_empty_as_result_true()
    {
        var isNullOrEmpty = TestCases.isNullOrEmpty("");
        
        Assert.That(isNullOrEmpty, Is.True);
    }
    
    [Test]
    public void Check_if_input_correct_word_as_result_true()
    {
        var isNullOrEmpty = TestCases.isNullOrEmpty("null");
        
        Assert.That(isNullOrEmpty, Is.False);
    }
}