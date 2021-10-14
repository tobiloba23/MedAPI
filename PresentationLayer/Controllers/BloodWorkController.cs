using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedChart.PocosLayer;
using MedChart.DataAccessLayer.Repositories;
using MedChart.DataAccessLayer.DbContexts;
using BusinessLogicLayer.MedChartManagers;
using BusinessLogicLayer.Utilities;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BloodWorkController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<BloodWorkController> _logger;
        private readonly BloodWorkLogic _bloodWorManager;
        private readonly string successMessage = "Request was successful!";

        public BloodWorkController(MedChartContext context, ILogger<BloodWorkController> logger)
        {
            _logger = logger;
            _bloodWorManager = new BloodWorkLogic(new MedChartRepository<BloodWorkPoco>(context));
        }

        [HttpGet]
        public async Task<IActionResult> GetBloodWork(int? page, int? pageSize, bool? getAll)
        {
            //var rng = new Random();
            //for (var i = 0; i < 5; i++)
            //{
            //    var bloodWork = new BloodWorkPoco
            //    {
            //        ExamDate = DateTime.UtcNow,
            //        ResultsDate = DateTime.Now.AddDays(i),
            //        Description = Summaries[rng.Next(Summaries.Length)],
            //        Hemoglobin = (byte)rng.Next(20, 55),
            //        Hematocrit = (byte)rng.Next(50, 75),
            //        WhiteBloodCellCountMCPMcL = (decimal)rng.Next(3000, 60000) / 1000,
            //        RedBloodCellCountMCPMcL = (decimal)rng.Next(2043, 52405) / 1000,
            //    };
            //    await _bloodWorManager.Add(new BloodWorkPoco[] { bloodWork });
            //};

            int? totalRecords = await _bloodWorManager.GetCount();

            Pager pager = getAll.HasValue && getAll.Value ? new Pager(totalRecords, page, pageSize) : new Pager(totalRecords, page, pageSize ?? 0);

            var result = await _bloodWorManager.GetAll(pager.PageSize, pager.Skip);

            var response = new { 
                status = Response.StatusCode,
                title = successMessage,
                result,
                pager
            };
            return new JsonResult(response);
        }

        [HttpGet]
        [Route("GetBloodWorkById/{id}")]
        public async Task<IActionResult> GetBloodWorkById(Guid? id)
        {
            BloodWorkPoco bloodWork = await _bloodWorManager.Get(id.Value);

            if (bloodWork == null)
            {
                return NotFound();
            }

            var response = new
            {
                status = Response.StatusCode,
                title = successMessage,
                Result = bloodWork
            };
            return new JsonResult(response);
        }

        [HttpPost]
        [Route("AddBloodWork")]
        public async Task<IActionResult> AddBloodWork(params BloodWorkPoco[] bloodWork)
        {
            var result = await _bloodWorManager.Add(bloodWork);
            var response = new
            {
                status = Response.StatusCode,
                title = successMessage,
                Result = result
            };
            return new JsonResult(response);
        }

        [HttpPut]
        [Route("EditBloodWork")]
        public async Task<IActionResult> EditBloodWork(params BloodWorkPoco[] bloodWork)
        {
            var result = await _bloodWorManager.Update(bloodWork);
            var response = new
            {
                status = Response.StatusCode,
                title = successMessage,
                Result = result
            };
            return new JsonResult(response);
        }

        [HttpDelete]
        [Route("DeleteBloodWork")]
        public async Task<IActionResult> DeleteBloodWork(params BloodWorkPoco[] bloodWork)
        {
            var result = await _bloodWorManager.Delete(bloodWork);
            var response = new
            {
                status = Response.StatusCode,
                title = successMessage,
                Result = result
            };
            return new JsonResult(response);
        }

        [HttpDelete]
        [Route("DeleteBloodWorkById/{id}")]
        public async Task<IActionResult> DeleteBloodWork(Guid? id)
        {
            BloodWorkPoco bloodWork = await _bloodWorManager.Get(id.Value);
            var result = await _bloodWorManager.Delete(bloodWork);
            var response = new
            {
                status = Response.StatusCode,
                title = successMessage,
                Result = result
            };
            return new JsonResult(response);
        }
    }
}
