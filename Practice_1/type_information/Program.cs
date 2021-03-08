using System;
using System.Diagnostics;

namespace type_information
{
    public delegate char Read();
    internal class Program
    {
        internal static void Main(string[] args)
        {
            ShowMainMenu();
        }
        internal static void ShowMainMenu()
        {
            for (int i = 1; i < CLIStringsStorage.main_menu.Length; i++)
            {
                Console.WriteLine(CLIStringsStorage.main_menu[i] + i.ToString());
            }
            Console.WriteLine(CLIStringsStorage.main_menu[0] + "0");
            while (true)
            {
                char val = readChar();
                CheckInput(val);
                switch (val)
                {
                    case '1':
                        new AsmInfo().GetAsmInfo(Console.WriteLine, readChar);
                        break;
                    case '2':
                        new TypeInfoPrinter().show_type_info();
                        break;
                    case '3':
                        ConsoleParamsManager.SetCollor();
                        break;
                    case '0':
                        Process.GetCurrentProcess().Kill();
                        break;
                }
            }
        }

        internal static void CheckInput(char val)
        {
            if ((byte)val < 48 || (byte)val > 57)
            {
                throw new Exception(CLIStringsStorage.ARGS_EXEPTION);
            }
        }
        internal static char readChar()
        {
            return Console.ReadKey(true).KeyChar;
        }
    }
}
