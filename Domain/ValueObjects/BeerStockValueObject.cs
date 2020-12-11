using System;
using Domain.ValueObjects.Abstract;
using Domain.ValueObjects.Abstract.Interfaces;

namespace Domain.ValueObjects
{
    public class BeerStockValueObject : IValueObject<int>
    {
        public BeerStockValueObject(int value)
        {
            Value = value >= 0 ? value : throw new Exception();
        }

        public int Value { get; }
    }
}