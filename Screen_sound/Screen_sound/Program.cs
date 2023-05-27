using System;

List<string> bandList = new List<string>();

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

    Console.WriteLine("Digite a sua opção: ");
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
            Console.WriteLine("Você digitou a opção " + chosenOption + ".");
            break;
        case 4:
            Console.WriteLine("Você digitou a opção " + chosenOption + ".");
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
    bandList.Add(bandName);
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

    foreach (string band in bandList) {
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

DisplayMenuOptions();