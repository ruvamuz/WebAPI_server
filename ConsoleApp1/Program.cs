using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using WorkSql;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //DbConection dbConection = new DbConection();
            //UserManager userManager = new UserManager();

            ContractManager.DeleteContract(1);
            ContractManager.GetContract();

            //Console.ReadKey();
            //Строка для соединения с БД
            //string connectionString = "Server=.; Initial Catalog=WorkDB; Integrated Security=true";

            //Работа с Таблицей Contract
            //Получение всех значений Таблицы Get
            //string GetContract = "SELECT * FROM Contract";
            //var JsonText = new JsonResult("");
            DataTable table = new DataTable();

            /*using (SqlConnection connection = new SqlConnection(connectionString))
            {
                 connection.Open();

                SqlCommand command = new SqlCommand(GetContract, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                    /*if (reader.HasRows) // если есть данные
                    {
                        // выводим названия столбцов
                        string columnName1 = reader.GetName(0);
                        string columnName2 = reader.GetName(1);
                        string columnName3 = reader.GetName(2);

                        Console.WriteLine($"{columnName1}\t{columnName3}\t{columnName2}");

                        while (reader.Read()) // построчно считываем данные
                        {
                            object id = reader["Id"];
                            object ShortNameContract = reader["ShortNameContract"];
                            object FullNameContract = reader["FullNameContract"];

                            Console.WriteLine($"{id} \t{ShortNameContract} \t{FullNameContract}");
                        }
                    }
                    JsonText = new JsonResult(table);
                }
            }*/

            table = ContractManager.GetContract();
            static void PrintValues(DataTable table)
            {
                foreach (DataRow row in table.Rows)
                {
                    string str = "";
                    foreach (DataColumn column in table.Columns)
                    {
                        str += "\t"+row[column];
                        //Console.WriteLine(row[column]);
                    }
                    Console.WriteLine(str);
                }
            }
            PrintValues(table);
            Console.Read();

            //Добавление Контракта POST
            //string AddConract = "INSERT INTO Contract (ShortNameContract, FullNameContract) VALUES ('shortNameContract3','fullNamecontractForWorkAndworkworkwork3')";

            //Изменение Контракта PUT
            //string EditContract = "UPDATE Contract SET ShortNameContract='shortNameContract1', FullNameContract='fullNamecontractForWorkAndworkworkwork1' WHERE Id='1'";

            //Удаление Контракта Delete
            //string DeleteContract = "DELETE FROM Contract WHERE Id='3'";

            // Создание подключения
            /*using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(DeleteContract, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Добавлено объектов: {number}");

                //Console.WriteLine("Подключение открыто");
            }*/


            /*Console.WriteLine("Подключение закрыто...");
            Console.WriteLine("Программа завершила работу.");*/
            //Console.Read();
        }
    }
}
