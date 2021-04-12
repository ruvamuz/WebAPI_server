using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSql.Models
{
    public class JobPositionTable
    {
        public int Id { get; set; }
        public string JobPosition { get; set; }
    }

    public interface IJobPositionTable
    {
        List<JobPositionTable> Get();
        //JobPositionTable Get(int id);
        void Create(JobPositionTable job);
        void Update(JobPositionTable job);
        void Delete(int id);
    }
}
