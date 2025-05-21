// See https://aka.ms/new-console-template for more information
using GestaoFrotaVeicular.Shared.Data.DB;
using GestaoFrotaVeicular.Shared.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var vehicleTypeDAL = new DAL<VehicleType>();

        var vehicleDAL = new DAL<Vehicle>();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Bem vindo ao Gestão de Frota Veicular!\n");
            Console.WriteLine("Digite 1 para registrar um Tipo de Veículo");
            Console.WriteLine("Digite 2 para registrar um Veículo");
            Console.WriteLine("Digite 3 para mostrar todos os Veículos");
            Console.WriteLine("Digite 4 para mostrar os Veículos de um Tipo de Veículo");
            Console.WriteLine("Digite -1 para sair :(");

            Console.WriteLine("Informe sua opção");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    VehicleTypeRegistration();
                    break;
                case 2:
                    VehicleRegistration();
                    break;
                case 3:
                    VehicleGet();
                    break;
                case 4:
                    VehicleTypeGet();
                    break;
                case -1:
                    Console.Clear();
                    Console.WriteLine("Até logo!");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            Thread.Sleep(1500);
            Console.Clear();
        }

        void VehicleTypeGet()
        {
            Console.Clear();
            Console.WriteLine("Exibir Veículos de um Tipo de Veículo");
            Console.WriteLine("Digite o Tipo de Veículo");
            string name = Console.ReadLine();
            VehicleType vehicleType = vehicleTypeDAL.ReadBy(vt => vt.Name.ToUpper().Equals(name.ToUpper()));
            if (vehicleType == null) Console.WriteLine($"O Tipo de Veículo {name} não existe");
            else
            {
                Console.WriteLine($"Veiculos do Tipo: {vehicleType.Name}");
                foreach (var vehicle in vehicleType.Vehicles)
                {
                    Console.WriteLine($"Veiculo: {vehicle.MarkModel}/{vehicle.Year}/{vehicle.Plate}");
                }
            }
        }

        void VehicleGet()
        {
            Console.Clear();
            Console.WriteLine("Lista de Veículos:");
            foreach (var vehicle in vehicleTypeDAL.Read())
            {
                Console.WriteLine($"{vehicle}");
            }
        }

        void VehicleRegistration()
        {
            Console.Clear();
            Console.WriteLine("Registro de Veículos");
            Console.WriteLine("Digite a Marca/Modelo do Veículo que você deseja cadastrar");
            string markModel = Console.ReadLine();
            Console.WriteLine("Digite o Ano do Veículo que você deseja cadastrar");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Placa do Veículo que você deseja cadastrar");
            string plate = Console.ReadLine();
            Console.WriteLine("Digite o Nome do Tipo de Veículo do Veículo que você deseja cadastrar");
            string vehicleTypeName = Console.ReadLine();
            VehicleType vehicleType = vehicleTypeDAL.ReadBy(vt => vt.Name.ToUpper().Equals(vehicleTypeName.ToUpper()));
            if (vehicleType is null) Console.WriteLine($"O Tipo de Veículo {vehicleTypeName} não existe.");
            else
            {
                Vehicle vehicle = new(markModel, year, plate);
                vehicleDAL.Create(vehicle);
                Console.WriteLine($"Veículo {plate} CREATE com sucesso!");
                vehicleType.Vehicles?.Add(vehicle);
                vehicle.VehicleType = vehicleType;
                vehicleDAL.Update(vehicle);
                Console.WriteLine($"Veículo {plate} UPDATE com sucesso!");
            }
        }

        void VehicleTypeRegistration()
        {
            Console.Clear();
            Console.WriteLine("Registro de Tipo de Veículo");
            Console.WriteLine("Digite o Nome do Tipo de Veículo que você deseja cadastrar");
            string name = Console.ReadLine();
            Console.WriteLine("Digite a Descrição do Tipo de Veículo que você deseja cadastrar");
            string description = Console.ReadLine();
            VehicleType vehicleType = new(name, description);
            vehicleTypeDAL.Create(vehicleType);
        }
    }
}
