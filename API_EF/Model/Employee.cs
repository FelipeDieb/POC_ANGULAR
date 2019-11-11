using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PocAPI.Model
{
    public class Employee : EntityBase
    {
        [NotNull]
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public Month StartMonth { get; set; }
        public long DepartamentId { get; set; }

        public virtual Departament Departament { get; set; }
    }
}
