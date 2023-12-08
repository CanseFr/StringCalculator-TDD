namespace StringCalculator;

public enum Starter
{
    Starter
}

public static class StarterExtensions
{
    public static string ToSymbol(this Starter op)
    {
        switch (op)
        {
            case Starter.Starter:
                return "//";
            default:
                throw new ArgumentException("Unknown operator");
        }
    }
}