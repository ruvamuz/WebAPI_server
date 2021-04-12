using System.Collections.Generic;

namespace WorkSql.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Patronymic { get; set; }
        public int JobPosition { get; set; }
        public string BirthDate { get; set; }
    }
    public interface IEmployeeManager
    {
        List<Employee> Get();
        Employee Get(int id);
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
