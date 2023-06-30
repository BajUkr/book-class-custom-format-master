using System;
using System.Globalization;

public class Book
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int Year { get; set; }
    public string? Publisher { get; set; }
    public string? ISBN { get; set; }
    public int Pages { get; set; }
    public decimal Price { get; set; }
}

public class BookFormatProvider : BookFormatProviderBase, IFormatProvider, ICustomFormatter
{
    public object? GetFormat(Type formatType)
    {
        return formatType == typeof(ICustomFormatter) ? this : null;
    }
}
