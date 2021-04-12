using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WorkSql.Models;

namespace Back_End_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IEmployeeManager _employeeManager;

        public EmployeeController(IConfiguration configuration, IEmployeeManager employeeManager)
        {
            _configuration = configuration;
            _employeeManager = employeeManager;
        }

        [HttpGet]
        public JsonResult Get()
        {
            List<Employee> table = _employeeManager.Get();
            return new JsonResult(table);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Employee employee = _employeeManager.Get(id);
            return new JsonResult(employee);
        }

        [HttpPost]
        public JsonResult Post(Employee employee)
        {
            _employeeManager.Create(employee);
            //EmployeeManager.PostEmployee();
            return new JsonResult("Post запрос выполнен!");
        }

        [HttpPut]
        public JsonResult Put(Employee employee)
        {
            _employeeManager.Update(employee);
            //EmployeeManager.PutEmployee(emp);
            return new JsonResult("Put запрос выполнен!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _employeeManager.Delete(id);
            //EmployeeManager.DeleteEmployee(id);
            return new JsonResult("Delete запрос выполнен!");
        }
    }
}
