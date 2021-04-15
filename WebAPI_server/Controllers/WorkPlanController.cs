using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WorkSql.Models;

namespace Back_End_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkPlanController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IWorkPlan _workPlan;

        public WorkPlanController(IConfiguration configuration, IWorkPlan workPlan)
        {
            _configuration = configuration;
            _workPlan = workPlan;
        }

        [HttpGet]
        public JsonResult Get()
        {
            List<WorkPlan> table = _workPlan.Get(); //ContractManager..Get();
            return new JsonResult(table);
        }

        [HttpGet("{Id}/{startDate}/{endDate}")]
        public JsonResult Get(int Id, string startDate, string endDate)
        {
            List<WorkPlan> table = _workPlan.Get(Id, startDate, endDate); //ContractManager..Get();
            return new JsonResult(table);
        }

        /*[HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Contract contract = _workPlan.Get(id);
            return new JsonResult(contract);
        }

        [HttpPost]
        public JsonResult Post(Contract contr)
        {
            _workPlan.Create(contr);
            //ContractManager.PostContract(contr);
            return new JsonResult("POST запрос выполнен!");
        }

        [HttpPut]
        public JsonResult Put(Contract contr)
        {
            _workPlan.Update(contr);
            //ContractManager.PutContract(contr);
            return new JsonResult("Put запрос выполнен!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _workPlan.Delete(id);
            //ContractManager.DeleteContract(id);
            return new JsonResult("Delete запрос выполнен!");
        }*/
    }
}
