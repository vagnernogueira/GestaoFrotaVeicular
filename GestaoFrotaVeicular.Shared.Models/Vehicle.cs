using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrotaVeicular.Shared.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string MarkModel { get; set; }

        public int Year {  get; set; }

        public string Plate {  get; set; }

        public virtual VehicleType? VehicleType { get; set; }

        public virtual ICollection<Department>? Departments { get; set; } = new List<Department>();

        public Vehicle() { }

        public Vehicle(string markModel, int year, string plate)
        {
            MarkModel = markModel;
            Year = year;
            Plate = plate;
        }

        public override string? ToString()
        {
            return $@"Veiculo: {MarkModel}/{Year}/{Plate}";
        }
    }
}
