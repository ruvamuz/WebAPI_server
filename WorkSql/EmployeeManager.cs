using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WorkSql.Models;

namespace WorkSql
{
    public class EmployeeManager : IEmployeeManager
    {

        private string connectionString = null;

        public EmployeeManager(string conn)
        {
            connectionString = conn;
        }

        //Получение Таблицы Сотрудников
        //static public DataTable GetEmployee()
        //{
        //    string GetEmployee = @"SELECT Employee.Id, Employee.Family, Employee.Name, Employee.Patronymic, JobPosition.JobPosition,
        //        convert(varchar(10),Employee.BirthDate,120) as BirthDate FROM Employee
        //        LEFT JOIN JobPosition On JobPosition.Id = Employee.JobPosition";
        //    DataTable table = new DataTable();
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(GetEmployee, connection);
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            table.Load(reader);
        //        }
        //    }
        //    return table;
        //}
        public List<Employee> Get()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Employee>("SELECT Employee.Id, " +
                    "Employee.Family, " +
                    "Employee.Name, " +
                    "Employee.Patronymic, " +
                    "Employee.JobPosition, " +
                    //"JobPosition.JobPosition, " +
                    "convert(varchar(10),Employee.BirthDate,120) as BirthDate FROM Employee " +
                    //"LEFT JOIN JobPosition On JobPosition.Id = Employee.JobPosition" +
                    "").ToList();
            }
        }

        public Employee Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Employee>("SELECT Employee.Id, " +
                    "Employee.Family, " +
                    "Employee.Name, " +
                    "Employee.Patronymic, " +
                    "Employee.JobPosition, " +
                    //"JobPosition.JobPosition, " +
                    "convert(varchar(10),Employee.BirthDate,120) as BirthDate FROM Employee " +
                    //"LEFT JOIN JobPosition On JobPosition.Id = Employee.JobPosition " +
                    "WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        //Добавление Сотрудника POST
        //public static void PostEmployee(Employee emp)
        //{
        //    string AddEmployee = @"INSERT INTO Employee 
        //            (Family, Name, Patronymic, JobPosition, BirthDate) VALUES 
        //            ('" + emp.Family + @"'
        //            ,'" + emp.Name + @"'
        //            ,'" + emp.Patronymic + @"'
        //            ,'" + emp.JobPosition + @"'
        //            ,'" + emp.BirthDate+"')";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(AddEmployee, connection);
        //        command.ExecuteNonQuery();
        //    }
        //}
        public void Create(Employee employee)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Employee " +
                    "(Family, Name, Patronymic, JobPosition, BirthDate) " +
                    "VALUES (@Family, @Name, @Patronymic, @JobPosition, @BirthDate)";
                db.Execute(sqlQuery, employee);
            }
        }

        //Изменение Сотрудника PUT
        //public static void PutEmployee(Employee emp)
        //{
        //    string EditEmployee = @"
        //            UPDATE Employee SET 
        //              Family='" +      emp.Family + @"'
        //            , Name='" +        emp.Name + @"' 
        //            , Patronymic='" +  emp.Patronymic + @"' 
        //            , JobPosition='" + emp.JobPosition + @"' 
        //            , BirthDate='" +   emp.BirthDate + @"' 
        //            WHERE Id='" +      emp.Id + @"'";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(EditEmployee, connection);
        //        command.ExecuteNonQuery();
        //    }
        //}
        public void Update(Employee employee)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Employee SET " +
                    "Family=@Family, " +
                    "Name=@Name, " +
                    "Patronymic=@Patronymic, " +
                    "JobPosition=@JobPosition, " +
                    "BirthDate=@BirthDate " +
                    "WHERE Id=@Id";
                db.Execute(sqlQuery, employee);
            }
        }

        //Удаление Сотрудника Delete
        //public static void DeleteEmployee(int id)
        //{
        //    string DeleteEmployee = @"DELETE FROM Employee WHERE Id='" + id + @"'";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(DeleteEmployee, connection);
        //        command.ExecuteNonQuery();
        //    }
        //}
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Employee WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}