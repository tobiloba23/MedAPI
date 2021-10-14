using MedChart.PocosLayer;
using System;
using System.Linq;
using System.Text;
using MedChart.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MedChart.BusinessLogicLayer;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BusinessLogicLayer.MedChartManagers
{
    public class BloodWorkLogic : BaseLogic<BloodWorkPoco>
    {

        public BloodWorkLogic(IDataRepository<BloodWorkPoco> repository) : base(repository)
        {
        }

        public override async Task<List<BloodWorkPoco>> GetAll(int take, int skip)
        {
            Expression<Func<BloodWorkPoco, object>>[] navigationProperties = new Expression<Func<BloodWorkPoco, object>>[] {
                p => p.DateCreated
            };
            return await _repository.GetAll(take, skip, navigationProperties);
        }

        public override async Task<int?> Add(params BloodWorkPoco[] pocos)
        {
            Verify(pocos);
            return await base.Add(pocos);
        }

        public override async Task<int?> Update(params BloodWorkPoco[] pocos)
        {
            Verify(pocos);
            return await base.Update(pocos);
        }

        protected override void Verify(params BloodWorkPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            int index = 0;
            foreach (var poco in pocos)
            {
                if (poco.ExamDate < DateTime.Now.AddYears(-100))
                    exceptions.Add(new ValidationException($"An examination date of BloodWork for {index} is required.", null, $"[{index}].ExamDate"));
                if (string.IsNullOrEmpty(poco.Description))
                    exceptions.Add(new ValidationException($"A description of BloodWork for {index} is required.", null, $"[{index}].ExamDate"));
                if (poco.Hematocrit >= 100 || poco.Hematocrit <= 0)
                    exceptions.Add(new ValidationException($"The Hematocrit number of BloodWork for {index} cannot be negative or over 100.", null, $"[{index}].ExamDate"));
                if (poco.Hemoglobin >= 100 || poco.Hemoglobin <= 0)
                    exceptions.Add(new ValidationException($"The Hemoglobin number of BloodWork for {index} cannot be negative or over 100.", null, $"[{index}].ExamDate"));
                if (poco.WhiteBloodCellCountMCPMcL >= 100 || poco.WhiteBloodCellCountMCPMcL <= 0)
                    exceptions.Add(new ValidationException($"The Red Blood Cell count of BloodWork for {index} cannot be negative or over 100.", null, $"[{index}].ExamDate"));
                if (poco.RedBloodCellCountMCPMcL >= 100 || poco.RedBloodCellCountMCPMcL <= 0)
                    exceptions.Add(new ValidationException($"The Red Blood Cell count of BloodWork {index} cannot be negative or over 100.", null, $"[{index}].ExamDate"));
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

    }
}