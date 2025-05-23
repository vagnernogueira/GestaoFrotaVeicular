using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrotaVeicular.Shared.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Vehicle>? Vehicles { get; set; } = new List<Vehicle>();

        public override string? ToString()
        {
            return $@"Departamento: {Name}  {Description}";
        }
    }
}
