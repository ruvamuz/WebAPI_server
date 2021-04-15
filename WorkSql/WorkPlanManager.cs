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
                    "CAST(WorkPlan.DateWork as nvarchar) as DateWork, " +
                    "WorkPlan.Employee, " +
                    "WorkPlan.Contract, " +
                    "CAST(WorkPlan.StartTime as nvarchar) as StartTime, " +
                    "CAST(WorkPlan.EndTime as nvarchar) as EndTime, " +
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
                    "CAST(WorkPlan.DateWork as nvarchar) as DateWork, " +
                    "WorkPlan.Employee, " +
                    "WorkPlan.Contract, " +
                    "CAST(WorkPlan.StartTime as nvarchar) as StartTime, " +
                    "CAST(WorkPlan.EndTime as nvarchar) as EndTime, " +
                    "WorkPlan.Note " +
                    "FROM WorkPlan " +
                    "WHERE " +
                    "(DateWork BETWEEN @StartDate AND @EndDate) AND (Employee = @EmployeeId)";
                return db.Query<WorkPlan>(sqlQuery, parameters).ToList();

            }
        }
    }
}
