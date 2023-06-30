using System;
using NUnit.Framework;

namespace Test;
[TestFixture]
public class BookFormatProviderTests
{
    private BookFormatProvider? bookFormatProvider;

    [SetUp]
    public void SetUp()
    {
        this.bookFormatProvider = new BookFormatProvider();
    }

    [Test]
    public void TestBookFormatProvider_DefaultValues()
    {
        var book = new Book
        {
            Title = "C# in Depth",
            Author = "Jon Skeet",
            Year = 2019,
            Publisher = "Manning Publications",
            ISBN = "9781617294532",
            Pages = 528,
            Price = 39.99m,
        };

        string expectedOutput = "Product details:\nAuthor: Jon Skeet\nTitle: C# in Depth\nPublisher: Manning Publications, 2019\nISBN-13: 9781617294532\nPaperback: 528 pages";
        string actualOutput = string.Format(this.bookFormatProvider, "{0:DETAILS}", book);

        Assert.AreEqual(expectedOutput, actualOutput);
    }

    [Test]
    public void TestBookFormatProvider_HighNumbers()
    {
        var book = new Book
        {
            Title = "C# in Depth",
            Author = "Jon Skeet",
            Year = 9999,
            Publisher = "Manning Publications",
            ISBN = "9781617294532",
            Pages = int.MaxValue,
            Price = decimal.MaxValue,
        };

        string expectedOutput = "Product details:\nAuthor: Jon Skeet\nTitle: C# in Depth\nPublisher: Manning Publications, 9999\nISBN-13: 9781617294532\nPaperback: 2,147,483,647 pages";
        string actualOutput = string.Format(this.bookFormatProvider, "{0:DETAILS}", book);

        Assert.AreEqual(expectedOutput, actualOutput);
    }

    [Test]
    public void TestBookFormatProvider_LowNumbers()
    {
        var book = new Book
        {
            Title = "C# in Depth",
            Author = "Jon Skeet",
            Year = 1,
            Publisher = "Manning Publications",
            ISBN = "9781617294532",
            Pages = 1,
            Price = 0.01m,
        };

        string expectedOutput = "Product details:\nAuthor: Jon Skeet\nTitle: C# in Depth\nPublisher: Manning Publications, 1\nISBN-13: 9781617294532\nPaperback: 1 pages";
        string actualOutput = string.Format(this.bookFormatProvider, "{0:DETAILS}", book);

        Assert.AreEqual(expectedOutput, actualOutput);
    }

    [Test]
    public void TestBookFormatProvider_ZeroValues()
    {
        var book = new Book
        {
            Title = "C# in Depth",
            Author = "Jon Skeet",
            Year = 0,
            Publisher = "Manning Publications",
            ISBN = "9781617294532",
            Pages = 0,
            Price = 0m,
        };

        string expectedOutput = "Product details:\nAuthor: Jon Skeet\nTitle: C# in Depth\nPublisher: Manning Publications, 0\nISBN-13: 9781617294532\nPaperback: 0 pages";
        string actualOutput = string.Format(this.bookFormatProvider, "{0:DETAILS}", book);

        Assert.AreEqual(expectedOutput, actualOutput);
    }

    [Test]
    public void TestBookFormatProvider_EmptyStrings()
    {
        var book = new Book
        {
            Title = string.Empty,
            Author = string.Empty,
            Year = 0,
            Publisher = string.Empty,
            ISBN = string.Empty,
            Pages = 0,
            Price = 0m,
        };

        string expectedOutput = "Product details:\nAuthor: \nTitle: \nPublisher: , 0\nISBN-13: \nPaperback: 0 pages";
        string actualOutput = string.Format(this.bookFormatProvider, "{0:DETAILS}", book);

        Assert.AreEqual(expectedOutput, actualOutput);
    }
}
