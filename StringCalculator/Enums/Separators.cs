namespace StringCalculator;

public enum Separators
{
    Multiply,
    Semicolon,
    Float
}

public static class SeparatorsExtensions
{
    public static char ToSymbol(this Separators op)
    {
        switch (op)
        {
            case Separators.Multiply:
                return '*';
            case Separators.Semicolon:
                return ';';
            case Separators.Float:
                return ',';
            default:
                throw new ArgumentException("Unknown operator");
        }
    }
}