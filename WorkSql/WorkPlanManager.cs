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
    }
}
