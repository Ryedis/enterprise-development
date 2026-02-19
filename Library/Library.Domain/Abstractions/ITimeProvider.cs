namespace Library.Domain.Abstractions;

/// <summary>
/// Интерфейс поставщика времени для детерминированного тестирования
/// </summary>
public interface ITimeProvider
{
    public DateTime Now { get; }
}
