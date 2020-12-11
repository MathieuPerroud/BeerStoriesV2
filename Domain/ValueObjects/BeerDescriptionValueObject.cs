using System;
using Domain.ValueObjects.Abstract.Interfaces;

namespace Domain.ValueObjects
{
    public class BeerDescriptionValueObject : IValueObject<string>
    {
        public BeerDescriptionValueObject(string value)
        {
            Value = value.Length >= 3 ? value : throw new Exception("");
        }

        public string Value { get; }
    }
}