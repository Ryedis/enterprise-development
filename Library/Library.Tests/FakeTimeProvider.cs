using Library.Domain.Abstractions;

namespace Library.Tests;

/// <summary>
/// Провайдер времени, возвращающий фиксированное значение
/// </summary>
public class FakeTimeProvider : ITimeProvider
{
    /// <summary>
    /// Текущее время
    /// </summary>
    public DateTime Now { get; }

    /// <summary>
    /// Создаёт экземпляр с заданным временем
    /// </summary>
    public FakeTimeProvider(DateTime now)
    {
        Now = now;
    }
}
