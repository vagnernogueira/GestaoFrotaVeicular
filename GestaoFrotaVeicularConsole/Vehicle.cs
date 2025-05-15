using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrotaVeicularConsole
{
    internal class Vehicle
    {
        public string MarkModel { get; set; }

        public int Year {  get; set; }

        public string Plate {  get; set; }

        public Vehicle(string markModel, int year, string plate)
        {
            MarkModel = markModel;
            Year = year;
            Plate = plate;
        }

        public override string? ToString()
        {
            return $@"Veiculo: {MarkModel}";
        }
    }
}
