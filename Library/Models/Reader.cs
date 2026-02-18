namespace Library.Domain.Models;

/// Сущность читателя библиотеки с персональными данными и историей выдач
public class Reader
{
    /// Уникальный идентификатор
    public required int Id { get; set; }

    /// ФИО читателя
    public required string FullName { get; set; }

    /// Адрес читателя
    public string? Address { get; set; }

    /// Телефон читателя
    public required string Phone { get; set; }

    /// Дата регистрации читателя
    public DateTime? RegistrationDate { get; set; }

    /// Выданные читателю книги
    public ICollection<BookIssue> BookIssues { get; set; } = [];
}