namespace Library.Domain.Abstractions;

/// <summary>
/// Поставщик времени, возвращающий текущее системное время
/// </summary>
public class SystemTimeProvider : ITimeProvider
{
    /// <summary>
    /// Возвращает текущее системное локальное время.
    /// </summary>
    public DateTime Now => DateTime.Now;
}
