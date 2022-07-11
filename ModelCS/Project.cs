using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class Project : EntityBase
    {
        public string Name { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public ICollection<Entry> Entries { get; set; }
        public ProjectStatus Status { get; set; }
        public ICollection<ProjectContract> ProjectContracts { get; set; }
    }

    public class ProjectContract
    {
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }
        public int ContractId { get; set; }
    }

    public enum ProjectStatus
    {
        New,
        Active,
        Closed
    }
}
