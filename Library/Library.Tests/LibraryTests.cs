using Library.Domain.Data;

namespace Library.Tests;

/// <summary>
/// Набор unit тестов для тестирования доменной области
/// </summary>
public class LibraryTests(DataSeeder dataSeeder) : IClassFixture<DataSeeder>
{
    /// <summary>
    /// Проверяет что активные выдачи сортируются по названию книги и возвращают ожидаемый порядок идентификаторов книг
    /// </summary>
    [Fact]
    public void IssuedBooks_OrderByBookTitle_ReturnsActiveIssuesOrderedByTitle()
    {
        var actualBookIds = dataSeeder.BookIssues
            .Where(bi => bi.ReturnDate == null)
            .Join(dataSeeder.Books,
                  bi => bi.BookId,
                  b => b.Id,
                  (bi, b) => new { bi, b })
            .OrderBy(x => x.b.Title)
            .Select(x => x.b.Id)
            .ToList();

        var expectedBookIds = new List<int> { 1, 1, 4, 7 };

        Assert.Equal(expectedBookIds, actualBookIds);
    }

    /// <summary>
    /// Топ 5 читателей за последний год по количеству выдач и сравнивает по Id и по количествам
    /// </summary>
    [Fact]
    public void Top5Readers_ByIssuesCountInPeriod_ReturnsExpectedTop5()
    {
        var periodStart = DateTime.UtcNow.AddYears(-1);
        var periodEnd = DateTime.UtcNow;

        var topReaders = dataSeeder.BookIssues
            .Where(bi => bi.IssueDate >= periodStart && bi.IssueDate <= periodEnd)
            .GroupBy(bi => bi.ReaderId)
            .Select(g => new { ReaderId = g.Key, Count = g.Count() })
            .Join(dataSeeder.Readers, g => g.ReaderId, r => r.Id, (g, r) => new { r.Id, r.FullName, g.Count })
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.FullName)
            .Take(5)
            .ToList();

        var actualIds = topReaders.Select(x => x.Id).ToList();
        var actualCounts = topReaders.Select(x => x.Count).ToList();

        var expectedIds = new List<int> { 2, 1, 3, 8, 10 };
        var expectedCounts = new List<int> { 2, 2, 1, 1, 1 };

        Assert.Equal(expectedIds, actualIds);
        Assert.Equal(expectedCounts, actualCounts);
    }

    /// <summary>
    /// Читатели, у которых есть выдачи с максимальным количеством дней, и сортирует их по ФИО
    /// </summary>
    [Fact]
    public void Readers_ByMaxLoanDaysOrderedByFullName_ReturnsExpected()
    {
        var maxDays = dataSeeder.BookIssues.Max(bi => bi.Days);

        var readersWithMaxDays = dataSeeder.BookIssues
            .Where(bi => bi.Days == maxDays)
            .Select(bi => bi.ReaderId)
            .Distinct()
            .Join(dataSeeder.Readers, id => id, r => r.Id, (id, r) => new { r.Id, r.FullName })
            .OrderBy(r => r.FullName)
            .Select(r => r.Id)
            .ToList();

        var expectedId = 1;
        var expectedDays = 60;

        Assert.Single(readersWithMaxDays);
        Assert.Equal(expectedDays, maxDays);
        Assert.Equal(expectedId, readersWithMaxDays[0]);
    }

    /// <summary>
    /// Топ 5 издательств за последний год по количеству выдач и сравнивает по Id и количествам
    /// </summary>
    [Fact]
    public void Top5Publishers_ByIssuesCountLastYear_ReturnsExpectedTop5()
    {
        var lastYearStart = DateTime.UtcNow.AddYears(-1);
        var lastYearEnd = DateTime.UtcNow;

        var topPublishers = dataSeeder.BookIssues
            .Where(bi => bi.IssueDate >= lastYearStart && bi.IssueDate <= lastYearEnd)
            .Join(dataSeeder.Books, bi => bi.BookId, b => b.Id, (bi, b) => b.PublisherId)
            .GroupBy(pid => pid)
            .Select(g => new { PublisherId = g.Key, Count = g.Count() })
            .Join(dataSeeder.Publishers, g => g.PublisherId, p => p.Id, (g, p) => new { p.Id, p.Name, g.Count })
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Name)
            .Take(5)
            .ToList();

        var actualPublisherIds = topPublishers.Select(x => x.Id).ToList();
        var actualCounts = topPublishers.Select(x => x.Count).ToList();

        var expectedPublisherIds = new List<int> { 6, 4, 5, 1, 2 };
        var expectedCounts = new List<int> { 3, 2, 2, 1, 1 };

        Assert.Equal(expectedPublisherIds, actualPublisherIds);
        Assert.Equal(expectedCounts, actualCounts);
    }

    /// <summary>
    /// Топ 5 наименее популярных книг за последний год сравнение по Id и количествам
    /// </summary>
    [Fact]
    public void Bottom5Books_ByIssuesCountLastYear_ReturnsExpectedBottom5() 
{
    var lastYearStart = DateTime.UtcNow.AddYears(-1);
    var lastYearEnd = DateTime.UtcNow;
    
    var bookCounts = dataSeeder.Books
        .GroupJoin(
            dataSeeder.BookIssues.Where(bi => bi.IssueDate >= lastYearStart && bi.IssueDate <= lastYearEnd),
            b => b.Id,
            bi => bi.BookId,
            (b, issues) => new { Book = b, Count = issues.Count() }
        )
        .OrderBy(x => x.Count)
        .ThenBy(x => x.Book.Title, StringComparer.Ordinal)
        .ToList();

    var actualBookIds = bookCounts.Select(x => x.Book.Id).ToList();
    var expectedBookIds = new List<int> { 9, 10, 5, 6, 3 };
    Assert.Equal(expectedBookIds, actualBookIds);
    }
}