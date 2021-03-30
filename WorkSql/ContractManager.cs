using Microsoft.Data.SqlClient;
using System.Data;
using WorkSql.Models;

namespace WorkSql
{
    public static class ContractManager
    {
        static string connectionString = "Server=.; Initial Catalog=WorkDB; Integrated Security=true";

        static public DataTable GetContract()
        {
            string GetContract = "SELECT * FROM Contract";
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

        //Добавление Контракта POST
        public static void PostContract(Contract contr)
        {
            string AddContract = @"INSERT INTO Contract 
                    (ShortNameContract, FullNameContract) VALUES 
                    ('" + contr.ShortNameContract + @"'
                    ,'" + contr.FullNameContract + @"')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(AddContract, connection);
                command.ExecuteNonQuery();
            }
        }

        //Изменение Контракта PUT
        public static void PutContract(Contract contr)
        {
            string EditContract = @"
                    UPDATE Contract SET 
                     ShortNameContract='"+contr.ShortNameContract+@"'
                    , FullNameContract='"+contr.FullNameContract+@"' 
                    WHERE Id='"+contr.Id+@"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(EditContract, connection);
                command.ExecuteNonQuery();
            }
        }

        //Удаление Контракта Delete
        public static void DeleteContract(int id)
        {
            string DeleteContract = @"DELETE FROM Contract WHERE Id='" +id+@"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(DeleteContract, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
