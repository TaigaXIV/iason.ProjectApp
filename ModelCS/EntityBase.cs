using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class EntityBase : IEntity, IEquatable<EntityBase>
    {
        [Key]
        public int Id { get; set; }

        public bool Equals(EntityBase other)
        {
            if (other == null)
                return false;
            if (this.Id > 0 && other.Id > 0)
                return Id == other.Id;
            else
                return this == other;
        }
    }

    public interface IEntity
    {
        int Id { get; set; }
    }
}
