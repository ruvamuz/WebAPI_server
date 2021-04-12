using System.Collections.Generic;

namespace WorkSql.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string ShortNameContract { get; set; }
        public string FullNameContract { get; set; }
    }

    public interface IContractManager
    {
        List<Contract> Get();
        Contract Get(int id);
        void Create(Contract contract);
        void Update(Contract contract);
        void Delete(int id);
    }
}
