using System.Globalization;

namespace Web.Utils;

public static class FormatCurrency
{
    public static decimal Format(decimal value, int decimalPlaces = 2)
    {
        return Math.Round(value, decimalPlaces);
    }
    public static string FormatToCurrencyString(decimal value, int decimalPlaces = 2)
    {
        return Format(value, decimalPlaces).ToString(
            "C",// formatadores G - valor normal, C - currency(R$)
            CultureInfo.CreateSpecificCulture("pt-BR"));
    }
}