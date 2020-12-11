using System;
using Domain.ValueObjects.Abstract.Interfaces;

namespace Domain.ValueObjects
{
    public class BeerLabelValueObject : IValueObject<string>
    {
        public BeerLabelValueObject(string value)
        {
            Value = value.Length >= 3 ? value : throw new Exception("");
        }

        public string Value { get; }
    }
}