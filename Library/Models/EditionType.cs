namespace Library.Domain.Models;

/// Справочник видов издания
public class EditionType
{
    /// Уникальный идентификатор
    public required int Id { get; set; }

    /// Наименование вида издания
    public required string Name { get; set; }
}