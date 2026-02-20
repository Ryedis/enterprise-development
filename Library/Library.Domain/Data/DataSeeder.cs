using Library.Domain.Models;

namespace Library.Domain.Data;

/// <summary>
/// Класс, содержащий заранее подготовленные тестовые данные
/// </summary>
public class DataSeeder
{
    
    private static readonly DateTime SeedNow = new(2026, 2, 19);

    public List<EditionType> EditionTypes { get; } =
    [
        new EditionType { Id = 1, Name = "Монография" },
        new EditionType { Id = 2, Name = "Методическое пособие" },
        new EditionType { Id = 3, Name = "Энциклопедия" },
        new EditionType { Id = 4, Name = "Биография" },
        new EditionType { Id = 5, Name = "Фэнтези" },
        new EditionType { Id = 6, Name = "Техническая литература" },
        new EditionType { Id = 7, Name = "Публицистика" },
        new EditionType { Id = 8, Name = "Поэзия" },
        new EditionType { Id = 9, Name = "Психология" },
        new EditionType { Id = 10, Name = "Бизнес-литература" },
    ];

    public List<Publisher> Publishers { get; } =
    [
        new Publisher { Id = 1, Name = "Бином" },
        new Publisher { Id = 2, Name = "Инфра-М" },
        new Publisher { Id = 3, Name = "Юрайт" },
        new Publisher { Id = 4, Name = "ДМК Пресс" },
        new Publisher { Id = 5, Name = "Лань" },
        new Publisher { Id = 6, Name = "Альпина Паблишер" },
        new Publisher { Id = 7, Name = "МИФ" },
        new Publisher { Id = 8, Name = "Вильямс" },
        new Publisher { Id = 9, Name = "Самокат" },
        new Publisher { Id = 10, Name = "Энергия" },
    ];

    public List<Book> Books { get; } =
    [
        new Book { Id = 1, InventoryNumber = "BK-101", AlphabetCode = "И-101", Authors = "И. Ньютон", Title = "Математические начала", EditionTypeId = 1, PublisherId = 5, Year = 1687 },
        new Book { Id = 2, InventoryNumber = "BK-102", AlphabetCode = "Т-210", Authors = "А. Тьюринг", Title = "Вычислительные машины", EditionTypeId = 6, PublisherId = 4, Year = 1936 },
        new Book { Id = 3, InventoryNumber = "BK-103", AlphabetCode = "К-310", Authors = "И. Кант", Title = "Критика чистого разума", EditionTypeId = 7, PublisherId = 6, Year = 1781 },
        new Book { Id = 4, InventoryNumber = "BK-104", AlphabetCode = "Р-410", Authors = "Д. Роулинг", Title = "Тайная комната", EditionTypeId = 5, PublisherId = 9, Year = 1998 },
        new Book { Id = 5, InventoryNumber = "BK-105", AlphabetCode = "М-510", Authors = "М. Портер", Title = "Конкурентная стратегия", EditionTypeId = 10, PublisherId = 7, Year = 1980 },
        new Book { Id = 6, InventoryNumber = "BK-106", AlphabetCode = "С-610", Authors = "К. Саган", Title = "Космос", EditionTypeId = 3, PublisherId = 1, Year = 1980 },
        new Book { Id = 7, InventoryNumber = "BK-107", AlphabetCode = "Ф-710", Authors = "З. Фрейд", Title = "Толкование сновидений", EditionTypeId = 9, PublisherId = 6, Year = 1899 },
        new Book { Id = 8, InventoryNumber = "BK-108", AlphabetCode = "Л-810", Authors = "С. Лем", Title = "Солярис", EditionTypeId = 5, PublisherId = 2, Year = 1961 },
        new Book { Id = 9, InventoryNumber = "BK-109", AlphabetCode = "Х-910", Authors = "Ю. Харари", Title = "Sapiens", EditionTypeId = 4, PublisherId = 6, Year = 2011 },
        new Book { Id = 10, InventoryNumber = "BK-110", AlphabetCode = "Г-999", Authors = "А. Гауди", Title = "Архитектура форм", EditionTypeId = 1, PublisherId = 10, Year = 1925 },
    ];

    public List<Reader> Readers => new()
    {
        new Reader { Id = 1, FullName = "Орлов Денис Сергеевич", Address = "ул. Березовая, 12", Phone = "89110000001", RegistrationDate = DateOnly.FromDateTime(SeedNow.AddMonths(-3)) },
        new Reader { Id = 2, FullName = "Мельников Артем Игоревич", Address = "ул. Солнечная, 45", Phone = "89110000002", RegistrationDate = DateOnly.FromDateTime(SeedNow.AddYears(-2)) },
        new Reader { Id = 3, FullName = "Белов Кирилл Андреевич", Address = "ул. Полевая, 7", Phone = "89110000003", RegistrationDate = DateOnly.FromDateTime(SeedNow.AddMonths(-18)) },
        new Reader { Id = 4, FullName = "Егорова Марина Олеговна", Address = "ул. Озерная, 21", Phone = "89110000004", RegistrationDate = DateOnly.FromDateTime(SeedNow.AddMonths(-12)) },
        new Reader { Id = 5, FullName = "Тарасов Максим Дмитриевич", Address = "ул. Лесная, 3", Phone = "89110000005", RegistrationDate = DateOnly.FromDateTime(SeedNow.AddMonths(-10)) },
        new Reader { Id = 6, FullName = "Крылова Анастасия Павловна", Address = "ул. Школьная, 9", Phone = "89110000006", RegistrationDate = DateOnly.FromDateTime(SeedNow.AddMonths(-8)) },
        new Reader { Id = 7, FullName = "Никитин Роман Евгеньевич", Address = "ул. Центральная, 15", Phone = "89110000007", RegistrationDate = DateOnly.FromDateTime(SeedNow.AddMonths(-6)) },
        new Reader { Id = 8, FullName = "Волкова Дарья Ильинична", Address = "ул. Мира, 19", Phone = "89110000008", RegistrationDate = DateOnly.FromDateTime(SeedNow.AddMonths(-5)) },
        new Reader { Id = 9, FullName = "Зайцев Павел Николаевич", Address = "ул. Новая, 8", Phone = "89110000009", RegistrationDate = DateOnly.FromDateTime(SeedNow.AddMonths(-4)) },
        new Reader { Id = 10, FullName = "Громова София Артемовна", Address = "ул. Южная, 14", Phone = "89110000010", RegistrationDate = DateOnly.FromDateTime(SeedNow.AddMonths(-2)) },
    };

    public List<BookIssue> BookIssues => new()
    {
        new BookIssue { Id = 1, BookId = 1, ReaderId = 1, IssueDate = SeedNow.AddDays(-15), Days = 30 },
        new BookIssue { Id = 2, BookId = 2, ReaderId = 1, IssueDate = SeedNow.AddDays(-200), Days = 60 },
        new BookIssue { Id = 3, BookId = 3, ReaderId = 2, IssueDate = SeedNow.AddDays(-40), Days = 14 },
        new BookIssue { Id = 4, BookId = 4, ReaderId = 2, IssueDate = SeedNow.AddDays(-7), Days = 10 },
        new BookIssue { Id = 5, BookId = 5, ReaderId = 3, IssueDate = SeedNow.AddDays(-300), Days = 21 },
        new BookIssue { Id = 6, BookId = 6, ReaderId = 4, IssueDate = SeedNow.AddDays(-50), Days = 14 },
        new BookIssue { Id = 7, BookId = 7, ReaderId = 5, IssueDate = SeedNow.AddDays(-3), Days = 7 },
        new BookIssue { Id = 8, BookId = 8, ReaderId = 6, IssueDate = SeedNow.AddDays(-120), Days = 30 },
        new BookIssue { Id = 9, BookId = 9, ReaderId = 7, IssueDate = SeedNow.AddDays(-60), Days = 20 },
        new BookIssue { Id = 10, BookId = 10, ReaderId = 8, IssueDate = SeedNow.AddDays(-25), Days = 14 },
        new BookIssue { Id = 11, BookId = 1, ReaderId = 9, IssueDate = SeedNow.AddDays(-5), Days = 10 },
        new BookIssue { Id = 12, BookId = 2, ReaderId = 10, IssueDate = SeedNow.AddDays(-90), Days = 30 }
    };
}
