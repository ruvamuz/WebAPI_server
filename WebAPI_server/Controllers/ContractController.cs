using WorkSql.Models;
using WorkSql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Back_End_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ContractController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            DataTable table = ContractManager.GetContract();
            return new JsonResult(table);
        }
        
        [HttpPost]
        public JsonResult Post(Contract contr)
        {
            ContractManager.PostContract(contr);
            return new JsonResult("Post запрос успешен!");
        }

        [HttpPut]
        public JsonResult Put(Contract contr)
        {
            ContractManager.PutContract(contr);
            return new JsonResult("Put метод успешен!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            ContractManager.DeleteContract(id);
            return new JsonResult("Delete метод успешен!");
        }
    }
}
