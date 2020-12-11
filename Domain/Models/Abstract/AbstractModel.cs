using System;
using Domain.ValueObjects.Abstract;

namespace Domain.Models.Abstract
{
    public abstract class AbstractModel
    {
        protected AbstractModel(Guid? id, DateTime? createdAt, DateTime? lastUpdate)
        {
            Id = new GuidValueObject(id);
            CreatedAt = new DateTimeValueObject(createdAt);
            LastUpdate = new DateTimeValueObject(lastUpdate);
        }

        /// <summary>
        ///     The model Id
        /// </summary>
        public GuidValueObject Id { get; }

        /// <summary>
        ///     The model created at datetime
        /// </summary>
        public DateTimeValueObject CreatedAt { get; }

        /// <summary>
        ///     The modal last update datetime
        /// </summary>
        public DateTimeValueObject LastUpdate { get; }
    }
}