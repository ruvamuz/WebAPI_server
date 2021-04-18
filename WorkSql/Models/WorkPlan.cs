using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSql.Models
{
    public class WorkPlan
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Employee { get; set; }
        public int time08 { get; set; }
        public int time09 { get; set; }
        public int time10 { get; set; }
        public int time11 { get; set; }
        public int time12 { get; set; }
        public int time13 { get; set; }
        public int time14 { get; set; }
        public int time15 { get; set; }
        public int time16 { get; set; }
        public int time17 { get; set; }
        public int time18 { get; set; }
        public int time19 { get; set; }
        public string Note { get; set; }
    }
    public interface IWorkPlan
    {
        WorkPlan Get(int Employee, string Date);
        List<WorkPlan> Get();//int Employee, string Date);
        List<WorkPlan> Get(int Employee, string startDate, string endDate);

        //List<WorkPlan> Get(int Employee);
        //WorkPlan Get(string Date);

        //void Create(WorkPlan workPlan);
        //void Update(WorkPlan workPlan);
        // void Delete(int id);
    }
}
