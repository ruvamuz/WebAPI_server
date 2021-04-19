using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WorkSql.Models;

namespace WorkSql
{
    public class WorkPlanManager : IWorkPlan
    {
        private string connectionString = null;

        public WorkPlanManager(string conn)
        {
            connectionString = conn;
        }

        public List<WorkPlan> Get()//int Id, string Date)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<WorkPlan>("SELECT " +
                    "WorkPlan.Id, " +
                    "CAST(WorkPlan.Date as nvarchar) as Date, " +
                    "WorkPlan.Employee, " +
                    "WorkPlan.time08, " +
                    "WorkPlan.time09, " +
                    "WorkPlan.time10, " +
                    "WorkPlan.time11, " +
                    "WorkPlan.time12, " +
                    "WorkPlan.time13, " +
                    "WorkPlan.time14, " +
                    "WorkPlan.time15, " +
                    "WorkPlan.time16, " +
                    "WorkPlan.time17, " +
                    "WorkPlan.time18, " +
                    "WorkPlan.time19, " +
                    "WorkPlan.Note " +
                    "FROM WorkPlan").ToList();
            }
        }

        public List<WorkPlan> Get(int Id, string startDate, string endDate)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var parameters = new { EmployeeId = Id, StartDate = startDate, EndDate = endDate };
                var sqlQuery = "SELECT " +
                    "WorkPlan.Id, " +
                    "CAST(WorkPlan.Date as nvarchar) as Date, " +
                    "WorkPlan.Employee, " +
                    "WorkPlan.time08, " +
                    "WorkPlan.time09, " +
                    "WorkPlan.time10, " +
                    "WorkPlan.time11, " +
                    "WorkPlan.time12, " +
                    "WorkPlan.time13, " +
                    "WorkPlan.time14, " +
                    "WorkPlan.time15, " +
                    "WorkPlan.time16, " +
                    "WorkPlan.time17, " +
                    "WorkPlan.time18, " +
                    "WorkPlan.time19, " +
                    "WorkPlan.Note " +
                    "FROM WorkPlan " +
                    "WHERE " +
                    "(Date BETWEEN @StartDate AND @EndDate) AND (Employee = @EmployeeId)";
                return db.Query<WorkPlan>(sqlQuery, parameters).ToList();
            }
        }

        public WorkPlan Get(int Id, string Date)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var parameters = new { EmployeeId = Id, Date = Date};
                var sqlQuery = "SELECT " +
                    "WorkPlan.Id, " +
                    "CAST(WorkPlan.Date as nvarchar) as Date, " +
                    "WorkPlan.Employee, " +
                    "WorkPlan.time08, " +
                    "WorkPlan.time09, " +
                    "WorkPlan.time10, " +
                    "WorkPlan.time11, " +
                    "WorkPlan.time12, " +
                    "WorkPlan.time13, " +
                    "WorkPlan.time14, " +
                    "WorkPlan.time15, " +
                    "WorkPlan.time16, " +
                    "WorkPlan.time17, " +
                    "WorkPlan.time18, " +
                    "WorkPlan.time19, " +
                    "WorkPlan.Note " +
                    "FROM WorkPlan " +
                    "WHERE " +
                    "(Date = @Date) AND (Employee = @EmployeeId)";
                return db.Query<WorkPlan>(sqlQuery, parameters).FirstOrDefault();
            }
        }

        public void Update(List<WorkPlan> workPlans)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                foreach(var item in workPlans)
                {
                    //var sqlQuery = "UPDATE WorkPlan SET " +
                    //    "Date=@Date, " +
                    //    "Employee=@Employee, " +
                    //    "time08=@time08, " +
                    //    "time09=@time09, " +
                    //    "time10=@time10, " +
                    //    "time11=@time11, " +
                    //    "time12=@time12, " +
                    //    "time13=@time13, " +
                    //    "time14=@time14, " +
                    //    "time15=@time15, " +
                    //    "time16=@time16, " +
                    //    "time17=@time17, " +
                    //    "time18=@time18, " +
                    //    "time19=@time19, " +
                    //    "Note=@Note, " +
                    //    "WHERE NOT EXISTS Id=@Id";
                    var sqlQuery = 
                        "IF (EXISTS (SELECT * FROM WorkPlan WHERE Employee = @Employee AND Date = @Date)) " +
                        "BEGIN " +
                            "UPDATE WorkPlan " +
                            "SET " +
                            "Date = @Date, " +
                            "Employee = @Employee, " +
                            "time08 = @time08, " +
                            "time09 = @time09, " +
                            "time10 = @time10, " +
                            "time11 = @time11, " +
                            "time12 = @time12, " +
                            "time13 = @time13, " +
                            "time14 = @time14, " +
                            "time15 = @time15, " +
                            "time16 = @time16, " +
                            "time17 = @time17, " +
                            "time18 = @time18, " +
                            "time19 = @time19, " +
                            "Note = @Note " +
                            "WHERE Employee = @Employee AND Date = @Date " +
                        "END " +
                            "ELSE " +
                                "BEGIN " +
                                    "INSERT INTO WorkPlan " +
                                    "(Date, Employee,   time08,  time09,  time10,  time11,  time12,  time13,  time14,  time15,  time16,  time17,  time18,  time19,  Note) " +
                                    "VALUES " +
                                    "(@Date, @Employee, @time08, @time09, @time10, @time11, @time12, @time13, @time14, @time15, @time16, @time17, @time18, @time19, @Note) " +
                                "END";

                    db.Execute(sqlQuery, item);
                }
                
            }
        }
    }
}
