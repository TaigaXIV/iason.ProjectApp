using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public ICollection<Entry> Entries { get; set; }
        public ProjectStatus Status { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }

    public enum ProjectStatus
    {
        New,
        Active,
        Closed
    }
}
