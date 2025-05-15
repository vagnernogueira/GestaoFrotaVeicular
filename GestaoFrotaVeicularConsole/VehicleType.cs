using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrotaVeicularConsole
{
    internal class VehicleType
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public VehicleType(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string? ToString()
        {
            return $@"Tipo de Veiculo: {Name}";
        }

        private List<Vehicle> vehicles = new List<Vehicle>();

        public void addVehicle(Vehicle vehicle)
        {
            this.vehicles.Add(vehicle);
        }

        public void removeVehicle(Vehicle vehicle)
        {
            this.vehicles.Remove(vehicle);

        }

        public List<Vehicle> getVehicles()
        {
            return this.vehicles;
        }

        public void showVeicles()
        {
            Console.WriteLine($"Veiculos do Tipo: {Name}");

            foreach (Vehicle vehicle in this.vehicles)
            {
                Console.WriteLine($"Veiculo: {vehicle.MarkModel}/{vehicle.Year}-{vehicle.Plate}");
            }
        }
    }
}
