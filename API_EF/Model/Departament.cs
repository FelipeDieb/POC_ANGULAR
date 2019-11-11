using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PocAPI.Model
{
    public class Departament : EntityBase
    {
        public Departament() : base()
        {
            Employees = new HashSet<Employee>();
        }

        [NotNull]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
