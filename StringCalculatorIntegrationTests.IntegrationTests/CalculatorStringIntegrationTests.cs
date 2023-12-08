using StringCalculator;

namespace StringCalculatorIntegrationTests.IntegrationTests;

[TestClass]
public class CalculatorStringIntegrationTests
{
    private CalculatorString _calculatorString;

    [TestInitialize]
    public void Init()
    {
        _calculatorString = new CalculatorString();
    }

    [TestMethod]
    [DataRow("//;/4;5;6", "Result is : 15")]
    [DataRow("//*/4*5*6", "Result is : 15")]
    [DataRow("//;/-2;5;1001", "Result is : 5")]
    [DataRow("4,5,6", "Result is : 15")]
    [DataRow("-2,5,1001", "Result is : 5")]
    public void GetInputStringToIntSum_ValidInputString_CalculatesSum(string inputString, string consoleMessageExcepted)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        _calculatorString.GetInputStringToIntSum(inputString);
        Assert.AreEqual(consoleMessageExcepted, stringWriter.ToString().Trim());
    }

    // TODO : Tester le reste et les throw de la main methode
    
    // [TestMethod]
    // [DataRow("-2,test,1001", "PARSING ERROR LOG : You try to convert 'test' to a number, it's impossible.")]
    // public void GetInputStringToIntSum_InvalidInputString_ConsolException(string listInput, string expectedErrorMessage)
    // {
    //     var stringWriter = new StringWriter();
    //     Console.SetOut(stringWriter);
    //     _calculatorString.GetInputStringToIntSum(listInput);
    //     Assert.AreEqual(expectedErrorMessage, stringWriter.ToString().Trim());
    // }


    // [TestMethod]
    // [DataRow("//;/-2;e;1001", typeof(HandleParsingError))]
    // [DataRow("/;/-2;e;1001",  typeof(HandleParsingError))]
    // [DataRow("/e/-2;e;1001", typeof(HandleParsingError))]
    // [DataRow("/-2;e;1001", typeof(HandleParsingError))]
    // [DataRow("/-2,e;1001", typeof(HandleParsingError))]
    // [DataRow("/-2,e*1001", typeof(HandleParsingError))]
    // [DataRow("//*/-2*e;1001", typeof(HandleParsingError))]
    // [DataRow("/*/-2;e;1001", typeof(HandleParsingError))]
    // [DataRow("/e/-2*e;1001", typeof(HandleParsingError))]
    // [DataRow("-2*e*1001", typeof(HandleParsingError))]
    // [DataRow("/*2,e_1001", typeof(HandleParsingError))]
    // [DataRow("2*e*1001", typeof(HandleParsingError))]
    // [DataRow("-2,e,1001", typeof(HandleParsingError))]
    // [DataRow("-2,e,1001", typeof(HandleParsingError))]
    // [DataRow("-2,e,1001", typeof(HandleParsingError))]
    // [DataRow("-2,e,1001", typeof(HandleParsingError))]
    // [DataRow(",-2,e,1001", typeof(HandleParsingError))]
    // [DataRow("/-2,;e*1001", typeof(HandleParsingError))]
    // [DataRow("//*/-2,;e*1001", typeof(HandleParsingError))]
    // public void GetInputStringToIntSum_InvalidInputString_ReturnHandleException(string inputString, Type expectedExceptionType)
    // {
    // {
    // Assert.ThrowsException(expectedExceptionType, () => _calculatorString.GetInputStringToIntSum(inputString));

    // Assert.ThrowsException<HandleParsingError>(() => _calculatorString.GetInputStringToIntSum(inputString));
    // }
    // }
}