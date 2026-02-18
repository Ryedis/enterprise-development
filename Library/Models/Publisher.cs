namespace Library.Domain.Models;

/// Справочник издательств, к которым относятся книги
public class Publisher
{
    /// Уникальный идентификатор
    public required int Id { get; set; }

    /// Наименование издательства
    public required string Name { get; set; }
}