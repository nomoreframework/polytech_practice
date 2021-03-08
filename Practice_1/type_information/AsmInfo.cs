using System;

namespace type_information
{
    internal class AsmInfo : AsmInfoManager
    {
        internal void GetAsmInfo(Action<string> write, Read read)
        {
            write(CLIStringsStorage.ASM_MENU_HEADER);
            foreach(var obj in Initial_Asm_info_storage())
            {
                write(obj.Key + obj.Value);
            }
            write(CLIStringsStorage.RETURN_TO_MAIN_MENU);
            char m = read();
            if(m != '0') throw new Exception(CLIStringsStorage.ARGS_EXEPTION);
            Program.ShowMainMenu();
        }
    }
}