using System;
using Domain.ValueObjects.Abstract.Interfaces;

namespace Domain.ValueObjects.Abstract
{
    public class DateTimeValueObject : IValueObject<DateTime>
    {
        public DateTimeValueObject(DateTime? value)
        {
            Value = value ?? DateTime.Now;
        }

        public DateTime Value { get; }
    }
}