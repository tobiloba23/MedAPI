using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedChart.DataAccessLayer
{
    public interface IDataRepository<T>
    {
        Task<List<T>> GetAll(int take, int skip, params Expression<Func<T, object>>[] navigationProperties);
        Task<List<T>> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        Task<T> GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        Task<int?> GetCount();
        Task<int?> Add(params T[] items);
        Task<int?> Update(params T[] items);
        Task<int?> Remove(params T[] items);
    }
}
