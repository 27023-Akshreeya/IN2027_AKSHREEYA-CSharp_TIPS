using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQchallenges.Application
{
    public class QueryBuilder<T>
    {
        private IEnumerable<T> _query;

        public QueryBuilder(IEnumerable<T> query)
        {
            this._query = query;
        }

        public QueryBuilder<T> Filter(Func<T, bool> condition)
        {
            this._query = this._query.Where(condition);

            return this;
        }

        public QueryBuilder<T> SortBy<TKey>(Func<T, TKey> keySelector)
        {
            this._query = this._query.OrderBy(keySelector);

            return this;
        }

        public QueryBuilder<TResult> Join<TOther, TKey, TResult>(
            IEnumerable<TOther> other,
            Func<T, TKey> outerKeySelector,
            Func<TOther, TKey> innerKeySelector,
            Func<T, TOther, TResult> resultSelector)
        {
            var result = this._query.Join(other, outerKeySelector, innerKeySelector, resultSelector);

            return new QueryBuilder<TResult>(result);
        }

        public IEnumerable<T> Execute()
        {
            return this._query;
        }
    }
}
