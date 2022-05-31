using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ProjectManager
    {        
        public static IEnumerable<Project> GetProjects()
        {
            return new List<Project>()
            {
                new Project() { Id = 1, Name = "Projecta 1", DateCreated = new DateTimeOffset(DateTime.Now), Status = ProjectStatus.Active },
                new Project() { Id = 2, Name = "Projecte 2", DateCreated = new DateTimeOffset(DateTime.Now), Status = ProjectStatus.Active },
                new Project() { Id = 3, Name = "Projecti 3", DateCreated = new DateTimeOffset(DateTime.Now), Status = ProjectStatus.Active },
                new Project() { Id = 4, Name = "Projectus 4", DateCreated = new DateTimeOffset(DateTime.Now), Status = ProjectStatus.Active },
                new Project() { Id = 5, Name = "Projecto 5", DateCreated = new DateTimeOffset(DateTime.Now), Status = ProjectStatus.Active },
                new Project() { Id = 6, Name = "Projectu 6", DateCreated = new DateTimeOffset(DateTime.Now), Status = ProjectStatus.Active },
                new Project() { Id = 7, Name = "Projecty 7", DateCreated = new DateTimeOffset(DateTime.Now), Status = ProjectStatus.Active },
                new Project() { Id = 8, Name = "Projectx 8", DateCreated = new DateTimeOffset(DateTime.Now), Status = ProjectStatus.Active },
                new Project() { Id = 9, Name = "Projectoy 9", DateCreated = new DateTimeOffset(DateTime.Now), Status = ProjectStatus.Active },
                new Project() { Id = 10, Name = "Projectai 10", DateCreated = new DateTimeOffset(DateTime.Now), Status = ProjectStatus.Active }
            };
        }
    }
}
