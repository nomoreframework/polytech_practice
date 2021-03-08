using System;

namespace type_information
{
    internal class TypeInfoManager<T> : SetingsManager<T>
    {
        internal TypeInfoManager()
        {
            var s_manager = new SetingsManager<T>();
        }
        internal void GetTypeInfo(Action<string> write, Read read)
        {
            write(TYPE_MENY_HEADER);
            foreach (var obj in type_menu_dict)
            {
                write(obj.Key + obj.Value);
            }
            write(METHODS_MENY_HEADER);
            write(CLIStringsStorage.RETURN_TO_MAIN_MENU);
            char r = read();
            if (r == '0') Program.ShowMainMenu();
            else if (r != 'm') throw new Exception(CLIStringsStorage.ARGS_EXEPTION +  ", exepted: m or 0");
            else getMethodsInfo(write, read);
        }
        private void getMethodsInfo(Action<string> write, Read read)
        {
            foreach (var m in get_type_methods_info())
            {
                write(m.Key + m.Value._overloads + m.Value._parametrs);
            }
            write(CLIStringsStorage.RETURN_TO_MAIN_MENU);
            char r = read();
            if (r == '0') Program.ShowMainMenu();
            else throw new Exception( CLIStringsStorage.ARGS_EXEPTION + ", exepted: 0");
        }
    }
}