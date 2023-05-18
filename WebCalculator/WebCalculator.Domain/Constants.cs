namespace WebCalculator.Domain;
public static class Constants
{
    public static readonly List<string> UnaryOperators = new()
    {
        "negate",
        "sqr",
        "√",
        "1/"
    };

    public static readonly List<string> BinaryOperators = new()
    {
        "+",
        "-",
        "*",
        "/",
        "^",
    };

    public static readonly List<string> SupportedOperators = BinaryOperators.Concat(UnaryOperators).ToList();
}
