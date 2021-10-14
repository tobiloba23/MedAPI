using MedChart.DataAccessLayer;
using MedChart.PocosLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedChart.BusinessLogicLayer
{
    public class BaseLogic<TPoco> where TPoco : IPoco
	{
		protected IDataRepository<TPoco> _repository;
		public BaseLogic(IDataRepository<TPoco> repository)
		{
			_repository = repository;
		}

		protected virtual void Verify(params TPoco[] pocos)
		{
			return;
		}

		public virtual async Task<TPoco> Get(Guid id)
		{
			return await _repository.GetSingle(c => c.Id == id);
		}

		public virtual async Task<List<TPoco>> GetAll(int take, int skip)
		{
			return await _repository.GetAll(take, skip);
		}

		public async Task<int?> GetCount()
		{
			return await _repository.GetCount();
		}

		public virtual async Task<int?> Add(params TPoco[] pocos)
		{
			foreach (TPoco poco in pocos)
			{
				if (poco.Id == Guid.Empty)
				{
					poco.Id = Guid.NewGuid();
				}
			}

			return await _repository.Add(pocos);
		}

		public virtual async Task<int?> Update(params TPoco[] pocos)
		{
			return await _repository.Update(pocos);
		}

		public async Task<int?> Delete(params TPoco[] pocos)
		{
			return await _repository.Remove(pocos);
		}
	}
}
