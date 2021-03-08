using System;
namespace type_information
{
    internal static class ConsoleParamsManager
    {
        internal static void SetCollor()
        {
            for (int i = 0; i < CLIStringsStorage.console_params_menu.Length; i++)
            {
                Console.WriteLine(CLIStringsStorage.console_params_menu[i] + (i + 1).ToString());
            }
            char val = Console.ReadKey(true).KeyChar;
            switch (val)
            {
                case '1':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Program.ShowMainMenu();
                    break;
                case '2':
                    Console.ForegroundColor = ConsoleColor.Green;
                    Program.ShowMainMenu();
                    break;
                case '3':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Program.ShowMainMenu();
                    break;
                case '4':
                    Console.ForegroundColor = ConsoleColor.Red;
                    Program.ShowMainMenu();
                    break;
                case '5':
                    Console.ForegroundColor = ConsoleColor.White;
                    Program.ShowMainMenu();
                    break;
            }
        }
    }
}