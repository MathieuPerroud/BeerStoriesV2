using System;
using Domain.Models.Abstract;
using Domain.Models.Interfaces;
using Domain.ValueObjects;

namespace Domain.Models
{
    public class BeerModel : AbstractModel, IBeerModel
    {
        public BeerModel(
            Guid? id,
            DateTime? createdAt,
            DateTime? lastUpdate,
            string label,
            string description,
            int stock = 0
        ) : base(id, createdAt, lastUpdate)
        {
            Label = new BeerLabelValueObject(label);
            Description = new BeerDescriptionValueObject(description);
            Stock = new BeerStockValueObject(stock);
        }

        /// <summary>
        ///     The beer label
        /// </summary>
        public BeerLabelValueObject Label { get; }

        /// <summary>
        ///     The beer description
        /// </summary>
        public BeerDescriptionValueObject Description { get; }

        /// <summary>
        ///     The beer stock
        /// </summary>
        public BeerStockValueObject Stock { get; private set; }

        public void IncreaseStock(int amount)
        {
            Stock = new BeerStockValueObject(Stock.Value + Math.Abs(amount));
        }

        public void DecreaseStock(int amount)
        {
            Stock = new BeerStockValueObject(Stock.Value - Math.Abs(amount));
        }
    }
}