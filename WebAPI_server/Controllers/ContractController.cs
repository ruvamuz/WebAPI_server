using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WorkSql.Models;

namespace Back_End_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IContractManager _contractManager;

        public ContractController(IConfiguration configuration, IContractManager contractManager)
        {
            _configuration = configuration;
            _contractManager = contractManager;
        }

        [HttpGet]
        public JsonResult Get()
        {
            List<Contract> table = _contractManager.Get(); //ContractManager..Get();
            return new JsonResult(table);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Contract contract = _contractManager.Get(id);
            return new JsonResult(contract);
        }

        [HttpPost]
        public JsonResult Post(Contract contr)
        {
            _contractManager.Create(contr);
            //ContractManager.PostContract(contr);
            return new JsonResult("POST запрос выполнен!");
        }

        [HttpPut]
        public JsonResult Put(Contract contr)
        {
            _contractManager.Update(contr);
            //ContractManager.PutContract(contr);
            return new JsonResult("Put запрос выполнен!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _contractManager.Delete(id);
            //ContractManager.DeleteContract(id);
            return new JsonResult("Delete запрос выполнен!");
        }
    }
}
