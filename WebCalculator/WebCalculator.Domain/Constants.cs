using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
