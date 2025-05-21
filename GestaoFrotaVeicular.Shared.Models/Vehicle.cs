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

        public int VehicleTypeId { get; set; }

        public Vehicle(string markModel, int year, string plate, int vehicleTypeId)
        {
            MarkModel = markModel;
            Year = year;
            Plate = plate;
            VehicleTypeId = vehicleTypeId;
        }

        public override string? ToString()
        {
            return $@"Veiculo: {MarkModel}/{Year}/{Plate}";
        }
    }
}
