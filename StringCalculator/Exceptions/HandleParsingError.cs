namespace StringCalculator.Exceptions;

public class HandleParsingError : Exception
{
    public HandleParsingError(string? message) : base(message)
    {
        Console.WriteLine("PARSING ERROR LOG : " + message);
    }
}