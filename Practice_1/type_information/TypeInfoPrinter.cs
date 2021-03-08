using System;

namespace type_information
{
    internal class TypeInfoPrinter
    {
        internal void show_type_info()
        {
            for (int j = 0; j < CLIStringsStorage.list_of_types.Length; j++)
            {
                Console.WriteLine((j + 1) + CLIStringsStorage.list_of_types[j]);
            }
            Console.WriteLine(CLIStringsStorage.RETURN_TO_MAIN_MENU);
            while (true)
            {
                char val = Program.readChar();
                Program.CheckInput(val);
                switch (val)
                {
                    case '1':
                        new TypeInfoManager<uint>().GetTypeInfo(Console.WriteLine, new Read(Program.readChar));
                        break;
                    case '2':
                        new TypeInfoManager<int>().GetTypeInfo(Console.WriteLine, new Read(Program.readChar)); ;
                        break;
                    case '3':
                        new TypeInfoManager<long>().GetTypeInfo(Console.WriteLine, new Read(Program.readChar));
                        break;
                    case '4':
                        new TypeInfoManager<float>().GetTypeInfo(Console.WriteLine, new Read(Program.readChar));
                        break;
                    case '5':
                        new TypeInfoManager<double>().GetTypeInfo(Console.WriteLine, new Read(Program.readChar));
                        break;
                    case '6':
                        new TypeInfoManager<char>().GetTypeInfo(Console.WriteLine, new Read(Program.readChar));
                        break;
                    case '7':
                        new TypeInfoManager<string>().GetTypeInfo(Console.WriteLine, new Read(Program.readChar));
                        break;
                    case '8':
                        new TypeInfoManager<decimal>().GetTypeInfo(Console.WriteLine, new Read(Program.readChar));
                        break;
                    case '9':
                        new TypeInfoManager<Guid>().GetTypeInfo(Console.WriteLine, new Read(Program.readChar));
                        break;
                    case '0':
                        Program.ShowMainMenu();
                        break;
                }
            }
        }
    }
}