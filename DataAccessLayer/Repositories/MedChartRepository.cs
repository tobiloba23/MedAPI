using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using log4net;
using System.Threading.Tasks;
using MedChart.DataAccessLayer.DbContexts;

namespace MedChart.DataAccessLayer.Repositories
{
    public class MedChartRepository<TPoco> : IDataRepository<TPoco> where TPoco : class
    {
        private MedChartContext _context;
        private static readonly ILog _logger = LogManager.GetLogger(typeof(MedChartRepository<TPoco>));

        public MedChartRepository(MedChartContext context)
        {
            _context = context;
        }

        public async Task<List<TPoco>> GetAll(int take, int skip, params Expression<Func<TPoco, object>>[] navigationProperties)
        {
            try
            {
                return await _context.Set<TPoco>().Skip(skip).Take(take).OrderBy(navigationProperties[0]).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.Debug($"Error processing GetList({typeof(TPoco)}): ", ex);
                throw;
            }
        }

        public async Task<List<TPoco>> GetList(Expression<Func<TPoco, bool>> where, params Expression<Func<TPoco, object>>[] navigationProperties)
        {
            try
            {
                return await _context.Set<TPoco>().Where(where).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.Debug($"Error processing GetList({typeof(TPoco)}): ", ex);
                throw;
            }
        }

        public async Task<TPoco> GetSingle(Expression<Func<TPoco, bool>> where, params Expression<Func<TPoco, object>>[] navigationProperties)
        {
            try
            {
                return await _context.Set<TPoco>().Where(where).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.Debug($"Error processing GetList({typeof(TPoco)}): ", ex);
                throw;
            }
        }

        public async Task<int?> GetCount()
        {
            return await _context.BloodWorks.CountAsync();
        }

        public async Task<int?> Add(params TPoco[] items)
        {
            foreach (var item in items)
            {
                _context.Entry(item).State = EntityState.Added;
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int?> Update(params TPoco[] items)
        {
            try
            {
                foreach (TPoco item in items)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.Debug($"Error processing GetList({typeof(TPoco)}): ", ex);
                throw;
            }
        }

        public async Task<int?> Remove(params TPoco[] items)
        {
            try
            {
                foreach (TPoco item in items)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.Debug($"Error processing GetList({typeof(TPoco)}): ", ex);
                throw;
            }
        }
    }
}
