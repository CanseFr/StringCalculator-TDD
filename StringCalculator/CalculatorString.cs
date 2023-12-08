using StringCalculator.Exceptions;

namespace StringCalculator;

public class CalculatorString
{
    private readonly List<int> listNumbsConsistent = new();
    private bool exceptionSplit;
    private List<string> listStrSplitBy = new();
    public Separators Separators;

    public bool IsString(string stringInput)
    {
        return !string.IsNullOrEmpty(stringInput);
    }

    public Separators GetSeparator(string stringInput)
    {
        if (stringInput.StartsWith(Starter.Starter.ToSymbol()))
        {
            if (stringInput[2].Equals(Separators.Semicolon.ToSymbol())) return Separators.Semicolon;

            if (stringInput[2].Equals(Separators.Multiply.ToSymbol())) return Separators.Multiply;
        }

        return Separators.Float;
    }

    public List<string> SplitStringBySeparator(Separators separators, string stringInput)
    {
        exceptionSplit = false;

        if (separators == Separators.Float) listStrSplitBy = stringInput.Split(Separators.Float.ToSymbol()).ToList();

        if (separators == Separators.Semicolon)
            listStrSplitBy = stringInput.Substring(4).Split(Separators.Semicolon.ToSymbol()).ToList();

        if (separators == Separators.Multiply)
            listStrSplitBy = stringInput.Substring(4).Split(Separators.Multiply.ToSymbol()).ToList();

        return listStrSplitBy;
    }

    public bool IsListConsitent(List<string> listInput)
    {
        foreach (var input in listInput)
            if (!int.TryParse(input, out var result))
                throw new HandleParsingError("You try to convert '" + input + "' to a number, it's impossible.");

        return true;
    }

    public List<int> ConvertStrListToInt(List<string> listInput)
    {
        listNumbsConsistent.Clear();
        foreach (var input in listInput)
            listNumbsConsistent.Add(int.TryParse(input, out var result) ? result : default);

        return listNumbsConsistent;
    }

    public List<int> CheckOrParseValidValue(List<int> listInput)
    {
        for (var i = 0; i < listInput.Count; i++)
            if (listInput[i] < 0 || listInput[i] > 1000)
                listInput[i] = 0;

        return listInput;
    }


    public int GetSumOfConsistentList(List<int> listNumber)
    {
        var sum = 0;
        listNumber.ForEach(n => sum += n);
        return sum;
    }

    public void DisplayResult(int sum)
    {
        Console.WriteLine("Result is : " + sum);
    }

    public void GetInputStringToIntSum(string inputString)
    {
        var calculator = new CalculatorString();

        try
        {
            if (calculator.IsString(inputString))
            {
                calculator.Separators = calculator.GetSeparator(inputString);

                var splitStrings = calculator.SplitStringBySeparator(calculator.Separators, inputString);

                if (calculator.IsListConsitent(splitStrings))
                {
                    var convertedIntegers = calculator.ConvertStrListToInt(splitStrings);

                    var validValues = calculator.CheckOrParseValidValue(convertedIntegers);

                    var sum = calculator.GetSumOfConsistentList(validValues);

                    calculator.DisplayResult(sum);
                }
            }
        }
        catch (HandleParsingError ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }
}