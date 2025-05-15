// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;
using GestaoFrotaVeicularConsole;

Dictionary<string, Vehicle> vehicleList = new Dictionary<string, Vehicle>();

bool exit = false;

while (!exit)
{
    Console.WriteLine("Bem vindo ao Gestão de Frota Veicular!");
    Console.WriteLine("Digite 1 para registrar um Veículo");
    Console.WriteLine("Digite 2 para registrar um Tipo de Veículo");
    Console.WriteLine("Digite 3 para mostrar todos os Veículo");
    Console.WriteLine("Digite 4 para mostrar os Veículo de um Tipo de Veículo");
    Console.WriteLine("Digite -1 para sair :(");

    Console.WriteLine("Informe sua opção");
    int option = int.Parse(Console.ReadLine());

    switch (option)
    {
        case 1:
            VehicleRegistration();
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

void VehicleRegistration()
{
    throw new NotImplementedException();
}