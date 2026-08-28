using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQchallenges.Application
{
    /// <summary>
    /// Implements a fluent builder pattern to chain LINQ query operations.
    /// </summary>
    /// <typeparam name="T">The type of elements in the query.</typeparam>
    public class QueryBuilder<T>
    {
        private IEnumerable<T> _query;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
        /// </summary>
        /// <param name="query">The initial data source collection.</param>
        public QueryBuilder(IEnumerable<T> query)
        {
            this._query = query;
        }

        /// <summary>
        /// Filters the query based on a specified condition.
        /// </summary>
        /// <param name="condition">The filter predicate function.</param>
        /// <returns>The updated query builder instance.</returns>
        public QueryBuilder<T> Filter(Func<T, bool> condition)
        {
            this._query = this._query.Where(condition);

            return this;
        }

        /// <summary>
        /// Sorts the query elements in ascending order by a key.
        /// </summary>
        /// <typeparam name="TKey">The type of the sorting key.</typeparam>
        /// <param name="keySelector">A function to extract the sorting key.</param>
        /// <returns>The updated query builder instance.</returns>
        public QueryBuilder<T> SortBy<TKey>(Func<T, TKey> keySelector)
        {
            this._query = this._query.OrderBy(keySelector);

            return this;
        }

        /// <summary>
        /// Joins the current query with another collection based on matching keys.
        /// </summary>
        /// <typeparam name="TOther">The type of elements in the other collection.</typeparam>
        /// <typeparam name="TKey">The type of the keys used to match elements.</typeparam>
        /// <typeparam name="TResult">The type of the resulting joined elements.</typeparam>
        /// <param name="other">The foreign data collection to join with.</param>
        /// <param name="outerKeySelector">A function to extract the key from the source collection.</param>
        /// <param name="innerKeySelector">A function to extract the key from the foreign collection.</param>
        /// <param name="resultSelector">A function to project the joined elements into a new shape.</param>
        /// <returns>A new query builder instance containing the joined results.</returns>
        public QueryBuilder<TResult> Join<TOther, TKey, TResult>(
            IEnumerable<TOther> other,
            Func<T, TKey> outerKeySelector,
            Func<TOther, TKey> innerKeySelector,
            Func<T, TOther, TResult> resultSelector)
        {
            var result = this._query.Join(other, outerKeySelector, innerKeySelector, resultSelector);

            return new QueryBuilder<TResult>(result);
        }

        /// <summary>
        /// Finalizes the built sequence and returns the query.
        /// </summary>
        /// <returns>The underlying enumerable query sequence.</returns>
        public IEnumerable<T> Execute()
        {
            return this._query;
        }
    }
}
