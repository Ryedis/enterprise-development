namespace Library.Domain.Models;

/// Сущность выдачи книги с данными сроков и возвратов
public class BookIssue
{
    /// Уникальный идентификатор
    public required int Id { get; set; }

    /// Идентификатор книги
    public required int BookId { get; set; }

    /// Выданная книга
    public Book? Book { get; set; }

    /// Идентификатор читателя
    public required int ReaderId { get; set; }

    /// Читатель, кому выдана книга
    public Reader? Reader { get; set; }

    /// Дата выдачи книги
    public required DateTime IssueDate { get; set; }

    /// Количество дней, на которое выдана книга
    public required int Days { get; set; }

    /// Дата возврата книги
    public DateTime? ReturnDate { get; set; }

    /// Флаг просрочки срока возврата
    public bool IsOverdue =>
        ReturnDate == null && DateTime.UtcNow.Date > IssueDate.Date.AddDays(Days);
}