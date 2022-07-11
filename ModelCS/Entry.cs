using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Model
{
    public class Entry : EntityBase
    {
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int CostPerHour { get; set; }

        //public static IEnumerable<Entry> GetEntries()
        //{
        //    return new List<Entry>()
        //    {
        //        new Entry() { ProjectId = 1, Id = 1, Description = "Just a Test", StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks), EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), CostPerHour = 45, User = new User() { FirstName = "Kyle", LastName = "Admin", Email = "k.admin@online.com", Password = "adminpassword", IsAdmin = true } },
        //        new Entry() { ProjectId = 4, Id = 1, Description = "Just a Test", StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks), EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), CostPerHour = 45, User = new User() { FirstName = "Kyle", LastName = "Admin", Email = "k.admin@online.com", Password = "adminpassword", IsAdmin = true } },
        //        new Entry() { ProjectId = 3, Id = 1, Description = "Just a Test", StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks), EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), CostPerHour = 45, User = new User() { FirstName = "Kyle", LastName = "Admin", Email = "k.admin@online.com", Password = "adminpassword", IsAdmin = true } },
        //        new Entry() { ProjectId = 1, Id = 1, Description = "Just a Test", StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks), EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), CostPerHour = 45, User = new User() { FirstName = "Kyle", LastName = "Admin", Email = "k.admin@online.com", Password = "adminpassword", IsAdmin = true } },
        //        new Entry() { ProjectId = 3, Id = 1, Description = "Just a Test", StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks), EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), CostPerHour = 45, User = new User() { FirstName = "Kyle", LastName = "Admin", Email = "k.admin@online.com", Password = "adminpassword", IsAdmin = true } },
        //        new Entry() { ProjectId = 1, Id = 1, Description = "Just a Test", StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks), EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), CostPerHour = 45, User = new User() { FirstName = "Kyle", LastName = "Admin", Email = "k.admin@online.com", Password = "adminpassword", IsAdmin = true } },
        //        new Entry() { ProjectId = 1, Id = 1, Description = "Just a Test", StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks), EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), CostPerHour = 45, User = new User() { FirstName = "Kyle", LastName = "Admin", Email = "k.admin@online.com", Password = "adminpassword", IsAdmin = true } },
        //        new Entry() { ProjectId = 3, Id = 1, Description = "Just a Test", StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks), EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), CostPerHour = 45, User = new User() { FirstName = "Kyle", LastName = "Admin", Email = "k.admin@online.com", Password = "adminpassword", IsAdmin = true } },
        //        new Entry() { ProjectId = 1, Id = 1, Description = "Just a Test", StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks), EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), CostPerHour = 45, User = new User() { FirstName = "Kyle", LastName = "Admin", Email = "k.admin@online.com", Password = "adminpassword", IsAdmin = true } },
        //        new Entry() { ProjectId = 2, Id = 1, Description = "Just a Test", StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks), EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), CostPerHour = 45, User = new User() { FirstName = "Kyle", LastName = "Admin", Email = "k.admin@online.com", Password = "adminpassword", IsAdmin = true } },
        //        new Entry() { ProjectId = 1, Id = 1, Description = "Just a Test", StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks), EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), CostPerHour = 45, User = new User() { FirstName = "Kyle", LastName = "Admin", Email = "k.admin@online.com", Password = "adminpassword", IsAdmin = true } }
        //    };
        //}

        //public static IEnumerable<Entry> GetEntries(int Id)
        //{
        //    return new List<Entry>(GetEntries().Where(e => e.ProjectId == Id));
        //}
    }
}
