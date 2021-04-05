using WorkSql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WorkSql;

namespace Back_End_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            DataTable table = EmployeeManager.GetEmployee();
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            EmployeeManager.PostEmployee(emp);
            return new JsonResult("Post запрос выполнен!");
        }

        [HttpPut]
        public JsonResult Put(Employee emp)
        {
            EmployeeManager.PutEmployee(emp);
            return new JsonResult("Put запрос выполнен!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            EmployeeManager.DeleteEmployee(id);
            return new JsonResult("Delete запрос выполнен!");
        }
    }
}
