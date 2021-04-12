using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WorkSql.Models;

namespace WorkSql
{
    public class JobPositionManager : IJobPositionTable
    {
        private string connectionString = null;

        public JobPositionManager(string connection)
        {
            connectionString = connection;
        }

        //Получение Таблицы Должности
        //static public DataTable GetJobPosition()
        //{
        //    string GetContract = @"SELECT * FROM JobPosition";
        //    DataTable table = new DataTable();
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(GetContract, connection);
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            table.Load(reader);
        //        }
        //    }
        //    return table;
        //}
        public List<JobPositionTable> Get()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<JobPositionTable>("SELECT * FROM JobPosition").ToList();
            }
        }


        //Добавление Должности POST
        //public static void PostJobPosition(JobPositionTable job)
        //{
        //    string AddJobPosition = @"INSERT INTO JobPosition 
        //            (JobPosition) VALUES 
        //            ('" + job.JobPosition + @"')";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(AddJobPosition, connection);
        //        command.ExecuteNonQuery();
        //    }
        //}
        public void Create(JobPositionTable jobPosition)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO JobPosition (JobPosition) VALUES (@JobPosition)";
                db.Execute(sqlQuery, jobPosition);
            }
        }

        //Изменение Должности PUT
        //public static void PutJobPosition(JobPositionTable job)
        //{
        //    string EditJobPosition = @"
        //            UPDATE JobPosition SET 
        //             JobPosition='" + job.JobPosition + @"' 
        //            WHERE Id='" + job.Id + @"'";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(EditJobPosition, connection);
        //        command.ExecuteNonQuery();
        //    }
        //}
        public void Update(JobPositionTable jobPosition)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE JobPosition SET JobPosition= @JobPosition WHERE Id = @id";
                db.Execute(sqlQuery, jobPosition);
            }
        }

        //Удаление Должности Delete
        //public static void DeleteJobPosition(int id)
        //{
        //    string DeleteContract = @"DELETE FROM JobPosition WHERE Id='" + id + @"'";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(DeleteContract, connection);
        //        command.ExecuteNonQuery();
        //    }
        //}
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM JobPosition WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
