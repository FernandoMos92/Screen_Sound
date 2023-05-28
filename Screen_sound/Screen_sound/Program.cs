using System;

/*List<string> bandList = new List<string>();*/

Dictionary<string, List<int>> bandResgistration = new Dictionary<string, List<int>>();
bandResgistration.Add("Linkin Park", new List<int> {10, 8, 6});
bandResgistration.Add("The Beatles", new List<int>());

void DisplayWelcomeMessage() {
    string projectName = @"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░";
    string welcomeMessage = "Boas vindas ao Screen Sound";
    Console.WriteLine(projectName);
    Console.WriteLine(welcomeMessage);
}

void DisplayMenuOptions() {
    DisplayWelcomeMessage();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair\n");

    Console.Write("Digite a sua opção: ");
    string chosenOption = Console.ReadLine()!;
    int chosenNumberOption = int.Parse(chosenOption);

    switch (chosenNumberOption) {
        case 1:
            RegistrationBand();
            break;
        case 2:
            ShowRegisteredBands();
            break;
        case 3:
            EvaluateBand();
            break;
        case 4:
            BandAverage();
            break;
        case 0:
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrationBand() {
    Console.Clear();
    ShowOptionTitle("Registro das bandas");
    Console.Write("\nDigite o nome da banda que deseja registrar: ");
    string bandName = Console.ReadLine()!;
    bandResgistration.Add(bandName, new List<int>());
    Console.WriteLine($"A banda {bandName} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    Console.Write("Você deseja cadastrar mais uma banda? 1-Sim ou 2-Não? ");
    string userOption = Console.ReadLine()!;
    if (int.Parse(userOption) == 1) {
        Console.Clear();
        RegistrationBand();
    }
    else {
        Console.Clear();
        DisplayMenuOptions();
    }
}

void ShowRegisteredBands() {
    Console.Clear();
    ShowOptionTitle("Lista de bandas");

    foreach (string band in bandResgistration.Keys) {
        Console.WriteLine($"Banda: {band}");
    }


    Console.WriteLine("\nDigite enter para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    DisplayMenuOptions();
}

void ShowOptionTitle(string title) {
    int amountLetter = title.Length;
    string asterisks = string.Empty.PadLeft(amountLetter, '*');
    Console.WriteLine(asterisks);
    Console.WriteLine(title);
    Console.WriteLine(asterisks + "\n");
}

void backToMenu(string bandName) {
    Console.WriteLine($"\nA banda {bandName} não foi encontrada!");
    Console.WriteLine("Digite uma tecla para voltar ao menu.");
    Console.ReadKey();
    Console.Clear();
    DisplayMenuOptions();
}

void EvaluateBand() 
{
    Console.Clear();
    ShowOptionTitle("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string bandName = Console.ReadLine()!;

    if(bandResgistration.ContainsKey(bandName)) 
    {
        Console.Write($"Qual nota a nota que a banda {bandName} merece: ");
        int bandPoints = int.Parse(Console.ReadLine()!);
        bandResgistration[bandName].Add(bandPoints);
        Thread.Sleep(3000);
        Console.WriteLine($"A nota {bandPoints} para a banda {bandName} foi registrada com sucesso!");
        Thread.Sleep(3000);
        Console.Clear();
        DisplayMenuOptions(); 
    }else {
        backToMenu(bandName);
    }
}

void BandAverage() {
    Console.Clear();
    ShowOptionTitle("Média de nota da banda");
    Console.Write("Digite o nome da banda que deseja saber a média: ");
    string bandName = Console.ReadLine()!;

    if(bandResgistration.ContainsKey(bandName)) {
        List<int> band = bandResgistration[bandName];
        Console.WriteLine($"\nA média da banda {bandName} é: {band.Average()}.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        DisplayMenuOptions();
    } else {
        backToMenu(bandName);
    }
}

DisplayMenuOptions();