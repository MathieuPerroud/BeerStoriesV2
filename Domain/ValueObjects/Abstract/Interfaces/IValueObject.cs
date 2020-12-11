using System;

namespace Domain.ValueObjects.Abstract.Interfaces
{
    public interface IValueObject<out T>
    {
        T Value { get; }
    }
}