using StringCalculator;
using StringCalculator.Exceptions;

namespace StringCalculatorTests.UnitTests;

[TestClass]
public class StringCalculatorTests
{
    private CalculatorString _calculatorString;

    [TestInitialize]
    public void Init()
    {
        _calculatorString = new CalculatorString();
    }

    [TestMethod]
    [DataRow("", false)]
    [DataRow(null, false)]
    [DataRow("test", true)]
    public void StringInput_NullOrEmptyString_ReturnsBool(string value, bool boolExcepted)
    {
        Assert.AreEqual(_calculatorString.IsString(value), boolExcepted);
    }

    [TestMethod]
    [DataRow("//*/", Separators.Multiply)]
    [DataRow("//;/", Separators.Semicolon)]
    [DataRow("2", Separators.Float)]
    public void Decryption_RightString_True(string valueOne, Separators enumSeparator)
    {
        var res = _calculatorString.GetSeparator(valueOne);
        Assert.AreEqual(res, enumSeparator);
    }

    [TestMethod]
    [DataRow(Separators.Multiply, "//*/4*5*6", new[] { "4", "5", "6" })]
    [DataRow(Separators.Multiply, "//*/4", new[] { "4" })]
    [DataRow(Separators.Semicolon, "//;/4;5;6", new[] { "4", "5", "6" })]
    [DataRow(Separators.Semicolon, "//;/4", new[] { "4" })]
    [DataRow(Separators.Float, "4,5,6", new[] { "4", "5", "6" })]
    [DataRow(Separators.Float, "4", new[] { "4" })]
    [DataRow(Separators.Float, "test", new[] { "test" })]
    public void SplitStringBySeparator_WithEnumSeparator_StringValueList(Separators separators, string stringInput,
        string[] listResult)
    {
        var expectedList = listResult.ToList();
        var res = _calculatorString.SplitStringBySeparator(separators, stringInput);
        CollectionAssert.AreEqual(res, expectedList);
    }

    [TestMethod]
    [DataRow(Separators.Multiply, "//*/4", new[] { "4" })]
    [DataRow(Separators.Semicolon, "//;/4", new[] { "4" })]
    [DataRow(Separators.Float, "4", new[] { "4" })]
    [DataRow(Separators.Float, "test", new[] { "test" })]
    public void SplitStringBySeparator_WhenSeparatorNotFound_ThrowsCustomeSplitException(Separators separators,
        string stringInput, string[] stringExcepted)
    {
        var expectedList = stringExcepted.ToList();
        var res = _calculatorString.SplitStringBySeparator(separators, stringInput);
        CollectionAssert.AreEqual(expectedList, res);
    }

    [TestMethod]
    [DataRow(new[] { "4" }, true)]
    [DataRow(new[] { "0" }, true)]
    [DataRow(new[] { "-4" }, true)]
    [DataRow(new[] { "4", "1000" }, true)]
    [DataRow(new[] { "4", "-1000" }, true)]
    public void CheckListIsConsitent_WhereNumberIsFound_ReturnTrue(string[] listInput, bool isExcepted)
    {
        var listInputCast = listInput.ToList();
        var res = _calculatorString.IsListConsitent(listInputCast);
        Assert.AreEqual(isExcepted, res);
    }

    [TestMethod]
    [DataRow(new[] { "test" })]
    [DataRow(new[] { "4", "test" })]
    [DataRow(new[] { "test", "4" })]
    public void CheckListIsConsitent_WhereLetterIsFound_ThrowsCustomeHandleParseException(string[] listInput)
    {
        var listInputCast = listInput.ToList();
        Assert.ThrowsException<HandleParsingError>(() => _calculatorString.IsListConsitent(listInputCast));
    }

    [TestMethod]
    [DataRow(new[] { "test" }, "You try to convert 'test' to a number, it's impossible.")]
    [DataRow(new[] { "4", "test" }, "You try to convert 'test' to a number, it's impossible.")]
    [DataRow(new[] { "test", "4" }, "You try to convert 'test' to a number, it's impossible.")]
    public void CheckListIsConsitent_WhereLetterIsFound_ThrowsCustomeHandleParseExceptionWithCustomMessage(
        string[] listInput, string expectedErrorMessage)
    {
        var listInputCast = listInput.ToList();
        var exception =
            Assert.ThrowsException<HandleParsingError>(() => _calculatorString.IsListConsitent(listInputCast));
        Assert.AreEqual(expectedErrorMessage, exception.Message);
    }

    [TestMethod]
    [DataRow(new[] { "4" }, new[] { 4 })]
    [DataRow(new[] { "4", "1000" }, new[] { 4, 1000 })]
    [DataRow(new[] { "-1", "1000" }, new[] { -1, 1000 })]
    [DataRow(new[] { "0", "-1000" }, new[] { 0, -1000 })]
    [DataRow(new[] { "-1000", "-1", "0", "1", "1000" }, new[] { -1000, -1, 0, 1, 1000 })]
    public void ConvertStrListToInt_WithValidInput_ReturnsValidIntList(string[] listInputStr, int[] listInputInt)
    {
        var listInputStrCast = listInputStr.ToList();
        var listInputIntCast = listInputInt.ToList();
        var res = _calculatorString.ConvertStrListToInt(listInputStrCast);
        CollectionAssert.AreEqual(listInputIntCast, res);
    }

    [TestMethod]
    [DataRow(new[] { 4 }, new[] { 4 })]
    [DataRow(new[] { 4, 0 }, new[] { 4, 0 })]
    [DataRow(new[] { 4, 0, -1 }, new[] { 4, 0, 0 })]
    [DataRow(new[] { 4, 0, -1, 1000 }, new[] { 4, 0, 0, 1000 })]
    [DataRow(new[] { 4, 0, -1, 1001 }, new[] { 4, 0, 0, 0 })]
    public void CheckOrParseToValidValue_WithNegativeOrMaximumValue_ReplaceByZero(int[] listInputToCheck,
        int[] listInputExcepted)
    {
        var listInputToCheckCast = listInputToCheck.ToList();
        var listInputExceptedCast = listInputExcepted.ToList();
        var res = _calculatorString.CheckOrParseValidValue(listInputToCheckCast);
        CollectionAssert.AreEqual(listInputExceptedCast, res);
    }

    [TestMethod]
    [DataRow(new[] { 4 }, 4)]
    [DataRow(new[] { 4, 0 }, 4)]
    [DataRow(new[] { 4, 0, 0 }, 4)]
    [DataRow(new[] { 4, 0, 0, 1000 }, 1004)]
    [DataRow(new[] { 4, 0, 0, 0 }, 4)]
    [DataRow(new[] { 4, 8, 12, 16, 0, 999 }, 1039)]
    public void GetSumOfConsistentListInt_WithOnlyCleanNumber_ReturnIntSum(int[] listInputToSum, int sumExcepted)
    {
        var listInputToSumCast = listInputToSum.ToList();
        var res = _calculatorString.GetSumOfConsistentList(listInputToSumCast);
        Assert.AreEqual(sumExcepted, res);
    }

    [TestMethod]
    [DataRow(42, "Result is : 42")]
    public void SetSumToDisplay_WithSumOfConsistentList_ShouldConsoleWriteDisplayResult(int sum,
        string consoleMessageExcepted)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        _calculatorString.DisplayResult(sum);
        Assert.AreEqual(consoleMessageExcepted, stringWriter.ToString().Trim());
    }
}