using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WorkSql.Models;

namespace WorkSql
{
    public class ContractManager : IContractManager
    {
        private string connectionString = null;

        public ContractManager(string conn)
        {
            connectionString = conn;
        }

        public List<Contract> Get()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Contract>("SELECT * FROM Contract").ToList();
            }
            //string GetContract = "SELECT * FROM Contract";
            //DataTable table = new DataTable();
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand(GetContract, connection);
            //    using (SqlDataReader reader = command.ExecuteReader())
            //    {
            //        table.Load(reader);
            //    }
            //}
            //return table;
        }

        public Contract Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Contract>("SELECT * FROM Contract WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        //Добавление Контракта POST
        //public static void PostContract(Contract contr)
        //{
        //    string AddContract = @"INSERT INTO Contract 
        //            (ShortNameContract, FullNameContract) VALUES 
        //            ('" + contr.ShortNameContract + @"'
        //            ,'" + contr.FullNameContract + @"')";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(AddContract, connection);
        //        command.ExecuteNonQuery();
        //    }
        //}

        public void Create(Contract contract)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Contract (ShortNameContract, FullNameContract) " +
                    "VALUES (@ShortNameContract , @FullNameContract)";
                db.Execute(sqlQuery, contract);
            }
        }

        //Изменение Контракта PUT
        //public static void PutContract(Contract contr)
        //{
        //    string EditContract = @"
        //            UPDATE Contract SET 
        //             ShortNameContract='"+contr.ShortNameContract+@"'
        //            , FullNameContract='"+contr.FullNameContract+@"' 
        //            WHERE Id='"+contr.Id+@"'";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(EditContract, connection);
        //        command.ExecuteNonQuery();
        //    }
        //}
        public void Update(Contract contract)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Contract SET ShortNameContract= @ShortNameContract, " +
                    "FullNameContract= @FullNameContract WHERE Id = @id";
                db.Execute(sqlQuery, contract);
            }
        }

        //Удаление Контракта Delete
        //public static void DeleteContract(int id)
        //{
        //    string DeleteContract = @"DELETE FROM Contract WHERE Id='" +id+@"'";
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
                var sqlQuery = "DELETE FROM Contract WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
