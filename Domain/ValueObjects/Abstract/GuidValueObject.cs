using System;
using Domain.ValueObjects.Abstract.Interfaces;

namespace Domain.ValueObjects.Abstract
{
    public class GuidValueObject : IValueObject<Guid>
    {
        public GuidValueObject(Guid? value)
        {
            Value = value ?? Guid.NewGuid();
        }

        public Guid Value { get; }
    }
}