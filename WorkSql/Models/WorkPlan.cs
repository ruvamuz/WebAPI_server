using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSql.Models
{
    public class WorkPlan
    {
        public int Id { get; set; }
        public string DateWork { get; set; }
        public int Employee { get; set; }
        public int Contract { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Note { get; set; }
    }
    public interface IWorkPlan
    {
        List<WorkPlan> Get();//int Employee, string Date);
        List<WorkPlan> Get(int Employee, string startDate, string endDate);
        //List<WorkPlan> Get(int Employee);
        //List<WorkPlan> Get(string Date);
        //WorkPlan Get(int Employee);
        //WorkPlan Get(string Date);

        //void Create(WorkPlan workPlan);
        //void Update(WorkPlan workPlan);
       // void Delete(int id);
    }
}
