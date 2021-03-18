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
            string spaces = new string(' ', 10);
            write(METHOD_NAME + spaces + COUNT_OF_OVERLOAD + spaces + COUNT_OF_PARAMS);
            foreach (var m in get_type_methods_info())
            {
                write((m.Key + new string(' ', METHOD_NAME.Length + spaces.Length - m.Key.Length)) 
                      +( m.Value._overloads + new string(' ', COUNT_OF_OVERLOAD.Length + spaces.Length - m.Value._overloads.Length))
                      + (m.Value._parametrs + new string(' ', COUNT_OF_PARAMS.Length + spaces.Length - m.Value._parametrs.Length)));
            }
            write(CLIStringsStorage.RETURN_TO_MAIN_MENU);
            char r = read();
            if (r == '0') Program.ShowMainMenu();
            else throw new Exception( CLIStringsStorage.ARGS_EXEPTION + ", exepted: 0");
        }
    }
}