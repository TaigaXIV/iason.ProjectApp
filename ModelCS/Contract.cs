using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Contract : EntityBase
    {
        public string Name { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public ICollection<ProjectContract> ProjectContracts { get; set; }

        //public static IEnumerable<Contract> GetContracts()
        //{
        //    return new List<Contract>()
        //    {
        //        new Contract() {Name = "Contract 1", StartDate = new DateTimeOffset(DateTime.Now), EndDate = new DateTimeOffset(DateTime.Now)},
        //        new Contract() {Name = "Contract 2", StartDate = new DateTimeOffset(DateTime.Now), EndDate = new DateTimeOffset(DateTime.Now)},
        //        new Contract() {Name = "Contract 3", StartDate = new DateTimeOffset(DateTime.Now), EndDate = new DateTimeOffset(DateTime.Now)},
        //    };
        //}
    }
}
