using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using WorkSql;
using WorkSql.Models;

namespace Back_End_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPositionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IJobPositionTable _jobPositionTable;

        public JobPositionController(IConfiguration configuration, IJobPositionTable jobPositionTable)
        {
            _configuration = configuration;
            _jobPositionTable = jobPositionTable;
        }

        [HttpGet]
        public JsonResult Get()
        {
            List<JobPositionTable> table = _jobPositionTable.Get();
            //DataTable table = JobPositionManager.GetJobPosition();
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(JobPositionTable job)
        {
            _jobPositionTable.Create(job);
            //JobPositionManager.PostJobPosition(job);
            return new JsonResult("Post запрос выполнен!");
        }

        [HttpPut]
        public JsonResult Put(JobPositionTable job)
        {
            _jobPositionTable.Update(job);
            //JobPositionManager.PutJobPosition(job);
            return new JsonResult("Put запрос выполнен!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _jobPositionTable.Delete(id);
            //JobPositionManager.DeleteJobPosition(id);
            return new JsonResult("Delete запрос выполнен!");
        }
    }
}