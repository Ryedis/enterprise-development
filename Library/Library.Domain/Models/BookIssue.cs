namespace Library.Domain.Models;

/// <summary>
/// Сущность выдачи книги читателю с указанием сроков и состояния возврата
/// </summary>
public class BookIssue
{
    private readonly Library.Domain.Abstractions.ITimeProvider _timeProvider;

    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор книги
    /// </summary>
    public required int BookId { get; set; }

    /// <summary>
    /// Выданная книга
    /// </summary>
    public Book? Book { get; set; }

    /// <summary>
    /// Идентификатор читателя
    /// </summary>
    public required int ReaderId { get; set; }

    /// <summary>
    /// Читатель, которому была выдана книга
    /// </summary>
    public Reader? Reader { get; set; }

    /// <summary>
    /// Дата выдачи книги
    /// </summary>
    public required DateTime IssueDate { get; set; }

    /// <summary>
    /// Количество дней, на которое выдана книга
    /// </summary>
    public required int Days { get; set; }

    /// <summary>
    /// Дата возврата книги (IssueDate + Days)
    /// </summary>
    public DateTime? ReturnDate => IssueDate.AddDays(Days);

    /// <summary>
    /// Конструктор с опциональным поставщиком времени
    /// </summary>
    public BookIssue(Library.Domain.Abstractions.ITimeProvider? timeProvider = null)
    {
        _timeProvider = timeProvider ?? new Library.Domain.Abstractions.SystemTimeProvider();
    }

    /// <summary>
    /// Флаг просрочки срока возврата книги
    /// </summary>
    public bool IsOverdue =>
        ReturnDate == null && _timeProvider.Now.Date > IssueDate.AddDays(Days).Date;
}