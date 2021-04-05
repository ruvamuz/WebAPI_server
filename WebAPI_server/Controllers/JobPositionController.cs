using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

        public JobPositionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            DataTable table = JobPositionManager.GetJobPosition();
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(JobPositionTable job)
        {
            JobPositionManager.PostJobPosition(job);
            return new JsonResult("Post запрос выполнен!");
        }

        [HttpPut]
        public JsonResult Put(JobPositionTable job)
        {
            JobPositionManager.PutJobPosition(job);
            return new JsonResult("Put запрос выполнен!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            JobPositionManager.DeleteJobPosition(id);
            return new JsonResult("Delete запрос выполнен!");
        }
    }
}