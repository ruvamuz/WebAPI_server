using Microsoft.Data.SqlClient;
using System.Data;
using WorkSql.Models;

namespace WorkSql
{
    public class EmployeeManager
    {

        private static string connectionString = "Server=.; Initial Catalog=WorkDB; Integrated Security=true";

        //Получение Таблицы Сотрудников
        static public DataTable GetEmployee()
        {
            string GetEmployee = @"SELECT Employee.Id, Employee.Family, Employee.Name, Employee.Patronymic, JobPosition.JobPosition,
                convert(varchar(10),Employee.BirthDate,120) as BirthDate FROM Employee
                LEFT JOIN JobPosition On JobPosition.Id = Employee.JobPosition";
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(GetEmployee, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }
            return table;
        }

        //Добавление Сотрудника POST
        public static void PostEmployee(Employee emp)
        {
            string AddEmployee = @"INSERT INTO Employee 
                    (Family, Name, Patronymic, JobPosition, BirthDate) VALUES 
                    ('" + emp.Family + @"'
                    ,'" + emp.Name + @"'
                    ,'" + emp.Patronymic + @"'
                    ,'" + emp.JobPosition + @"'
                    ,'" + emp.BirthDate+"')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(AddEmployee, connection);
                command.ExecuteNonQuery();
            }
        }

        //Изменение Сотрудника PUT
        public static void PutEmployee(Employee emp)
        {
            string EditEmployee = @"
                    UPDATE Employee SET 
                      Family='" +      emp.Family + @"'
                    , Name='" +        emp.Name + @"' 
                    , Patronymic='" +  emp.Patronymic + @"' 
                    , JobPosition='" + emp.JobPosition + @"' 
                    , BirthDate='" +   emp.BirthDate + @"' 
                    WHERE Id='" +      emp.Id + @"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(EditEmployee, connection);
                command.ExecuteNonQuery();
            }
        }

        //Удаление Сотрудника Delete
        public static void DeleteEmployee(int id)
        {
            string DeleteEmployee = @"DELETE FROM Employee WHERE Id='" + id + @"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(DeleteEmployee, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
