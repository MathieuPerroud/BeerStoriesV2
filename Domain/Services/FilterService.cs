using System;
using System.Collections.Generic;
using System.Linq;
using Domain.FilterOperators;
using Domain.Models.Abstract;
using Domain.ValueObjects.Abstract;
using Domain.ValueObjects.Abstract.Interfaces;

namespace Domain.Services
{
    public static class FilterService<T> where T : AbstractModel
    {
        /// <summary>
        ///     Apply filters on pagination criterion
        /// </summary>
        /// <param name="query">The query object</param>
        /// <param name="page">The requested page</param>
        /// <param name="perPage">The requested page items count</param>
        public static void ApplyPaginationFilter(ref IQueryable<T> query, int page, int perPage)
        {
            query = query.Skip((page - 1) * perPage).Take(perPage);
        }

        // /// <summary>
        // ///     Apply filters on sort criterion
        // /// </summary>
        // /// <param name="query">The query object</param>
        // /// <param name="filters">The sort filters</param>
        // public static void ApplySortFilters(ref IQueryable<T> query, Dictionary<string, SortFilterOperator> filters)
        // {
        //     foreach (var (key, value) in filters)
        //     {
        //         query = value switch
        //         {
        //             SortFilterOperator.ASC => query.OrderBy(x => ((IValueObject<dynamic>) x.GetType().GetProperty(key).GetValue(x)).Value),
        //             SortFilterOperator.DESC => query.OrderByDescending(x => ((IValueObject<dynamic>) x.GetType().GetProperty(key).GetValue(x)).Value),
        //             _ => query
        //         };
        //     }
        // }
        
        /// <summary>
        ///     Apply filters on datetime criterion
        /// </summary>
        /// <param name="query">The query object</param>
        /// <param name="filters">The datetime filters</param>
        /// <param name="propertyName">The property name to filter on</param>
        public static void ApplyDateFilters(ref IQueryable<T> query, Dictionary<DateFilterOperator, DateTime> filters,
            string propertyName)
        {
            foreach (var (key, value) in filters)
                query = key switch
                {
                    DateFilterOperator.Eq => query.Where(m =>
                        DateTime.Compare(
                            ((IValueObject<DateTime>) m.GetType().GetProperty(propertyName).GetValue(m)).Value,
                            value) ==
                        0),
                    DateFilterOperator.Gt => query.Where(m =>
                        DateTime.Compare(
                            ((IValueObject<DateTime>) m.GetType().GetProperty(propertyName).GetValue(m)).Value, value) >
                        0),
                    DateFilterOperator.Gte => query.Where(m =>
                        DateTime.Compare(
                            ((IValueObject<DateTime>) m.GetType().GetProperty(propertyName).GetValue(m)).Value,
                            value) >=
                        0),
                    DateFilterOperator.Lt => query.Where(m =>
                        DateTime.Compare(
                            ((IValueObject<DateTime>) m.GetType().GetProperty(propertyName).GetValue(m)).Value, value) <
                        0),
                    DateFilterOperator.Lte => query.Where(m =>
                        DateTime.Compare(
                            ((IValueObject<DateTime>) m.GetType().GetProperty(propertyName).GetValue(m)).Value,
                            value) <=
                        0),
                    _ => query
                };
        }

        /// <summary>
        ///     Apply filters on string criterion
        /// </summary>
        /// <param name="query">The query object</param>
        /// <param name="filters">The string filters</param>
        /// <param name="propertyName">The property name to filter on</param>
        public static void ApplyStringFilters(ref IQueryable<T> query, Dictionary<StringFilterOperator, string> filters,
            string propertyName)
        {
            foreach (var (key, value) in filters)
                query = key switch
                {
                    StringFilterOperator.Eq => query.Where(m =>
                        ((IValueObject<string>) m.GetType().GetProperty(propertyName).GetValue(m)).Value.Equals(value)),
                    StringFilterOperator.Ct => query.Where(m =>
                        ((IValueObject<string>) m.GetType().GetProperty(propertyName).GetValue(m)).Value
                        .Contains(value)),
                    StringFilterOperator.Sw => query.Where(m =>
                        ((IValueObject<string>) m.GetType().GetProperty(propertyName).GetValue(m)).Value
                        .StartsWith(value)),
                    StringFilterOperator.Ew => query.Where(m =>
                        ((IValueObject<string>) m.GetType().GetProperty(propertyName).GetValue(m)).Value
                        .EndsWith(value)),
                    _ => query
                };
        }

        /// <summary>
        ///     Apply filters on number criterion
        /// </summary>
        /// <param name="query">The query object</param>
        /// <param name="filters">The number filters</param>
        /// <param name="propertyName">The property name to filter on</param>
        public static void ApplyNumberFilters(ref IQueryable<T> query, Dictionary<NumberFilterOperator, int> filters,
            string propertyName)
        {
            foreach (var (key, value) in filters)
                query = key switch
                {
                    NumberFilterOperator.Eq => query.Where(m =>
                        ((IValueObject<int>) m.GetType().GetProperty(propertyName).GetValue(m)).Value.Equals(value)),
                    NumberFilterOperator.Gt => query.Where(m =>
                        ((IValueObject<int>) m.GetType().GetProperty(propertyName).GetValue(m)).Value > value),
                    NumberFilterOperator.Gte => query.Where(m =>
                        ((IValueObject<int>) m.GetType().GetProperty(propertyName).GetValue(m)).Value >= value),
                    NumberFilterOperator.Lt => query.Where(m =>
                        ((IValueObject<int>) m.GetType().GetProperty(propertyName).GetValue(m)).Value < value),
                    NumberFilterOperator.Lte => query.Where(m =>
                        ((IValueObject<int>) m.GetType().GetProperty(propertyName).GetValue(m)).Value <= value),
                    _ => query
                };
        }
    }
}