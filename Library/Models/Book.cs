namespace Library.Domain.Models;

/// Сущность книги, содержащая сведения из каталога библиотеки
public class Book
{
    /// Уникальный идентификатор
    public required int Id { get; set; }

    /// Инвентарный номер
    public required string InventoryNumber { get; set; }

    /// Шифр в алфавитном каталоге
    public required string AlphabetCode { get; set; }

    /// Инициалы и фамилии авторов
    public string? Authors { get; set; }

    /// Название
    public required string Title { get; set; }

    /// Идентификатор вида издания
    public required int EditionTypeId { get; set; }

    /// Вид издания
    public EditionType? EditionType { get; set; }

    /// Идентификатор издательства
    public required int PublisherId { get; set; }

    /// Издательство
    public Publisher? Publisher { get; set; }

    /// Год издания
    public int Year { get; set; }

    /// Записи о выдаче книги
    public ICollection<BookIssue> Issues { get; set; } = [];
}