using Microsoft.Data.SqlClient;
using System.Data;
using WorkSql.Models;

namespace WorkSql
{
    public class JobPositionManager
    {
        private static string connectionString = "Server=.; Initial Catalog=WorkDB; Integrated Security=true";

        //Получение Таблицы Должности
        static public DataTable GetJobPosition()
        {
            string GetContract = @"SELECT * FROM JobPosition";
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(GetContract, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }
            return table;
        }

        //Добавление Должности POST
        public static void PostJobPosition(JobPositionTable job)
        {
            string AddJobPosition = @"INSERT INTO JobPosition 
                    (JobPosition) VALUES 
                    ('" + job.JobPosition + @"')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(AddJobPosition, connection);
                command.ExecuteNonQuery();
            }
        }

        //Изменение Должности PUT
        public static void PutJobPosition(JobPositionTable job)
        {
            string EditJobPosition = @"
                    UPDATE JobPosition SET 
                     JobPosition='" + job.JobPosition + @"' 
                    WHERE Id='" + job.Id + @"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(EditJobPosition, connection);
                command.ExecuteNonQuery();
            }
        }

        //Удаление Должности Delete
        public static void DeleteJobPosition(int id)
        {
            string DeleteContract = @"DELETE FROM JobPosition WHERE Id='" + id + @"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(DeleteContract, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
