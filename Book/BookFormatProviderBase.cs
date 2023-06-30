using System.Globalization;

public class BookFormatProviderBase
{

    public string Format(string format, object arg, IFormatProvider formatProvider)
    {
        if (arg == null || !(arg is Book) || string.IsNullOrEmpty(format))
            return string.Empty;

        var book = (Book)arg;

        return format.ToUpperInvariant() switch
        {
            "DETAILS" => $"Product details:\nAuthor: {book.Author}\nTitle: {book.Title}\nPublisher: {book.Publisher}, {book.Year}\nISBN-13: {book.ISBN}\nPaperback: {book.Pages.ToString("N0", CultureInfo.InvariantCulture)} pages",
            _ => string.Empty,
        };
     }
}
