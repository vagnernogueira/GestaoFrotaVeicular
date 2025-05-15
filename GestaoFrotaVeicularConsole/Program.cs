// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;
using GestaoFrotaVeicularConsole;

Dictionary<string, VehicleType> vehicleTypeList = new Dictionary<string, VehicleType>();

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
    if (vehicleTypeList.ContainsKey(name))
    {
        VehicleType vehicleType = vehicleTypeList[name];
        vehicleType.showVeicles();
    }
    else
    {
        Console.WriteLine($"O Tipo de Veículo {name} não existe");
    }
}

void VehicleGet()
{
    Console.Clear();
    Console.WriteLine("Lista de Veículos:");
    foreach (var item in vehicleTypeList.Values)
    {
        item.showVeicles();
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
    Vehicle vehicle = new(markModel, year, plate);
    Console.WriteLine("Digite o Nome do Tipo de Veículo do Veículo que você deseja cadastrar");
    string vehicleTypeName = Console.ReadLine();
    if (vehicleTypeList.ContainsKey(vehicleTypeName))
    {
        vehicleTypeList[vehicleTypeName].addVehicle(vehicle);
    }
    else
    {
        Console.WriteLine($"O Tipo de Veículo {vehicleTypeName} não existe.");
    }
    Console.WriteLine($"Veículo {plate} adcionado com sucesso!");
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
    vehicleTypeList.Add(name, vehicleType);
}
