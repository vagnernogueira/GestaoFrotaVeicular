using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrotaVeicular.Shared.Models
{
    public class VehicleType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Vehicle>? Vehicles { get; set; } = new List<Vehicle>();

        public VehicleType(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string? ToString()
        {
            return $@"Tipo de Veiculo: {Name} / {Description}";
        }
    }
}
