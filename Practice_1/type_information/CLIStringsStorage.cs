
namespace type_information
{
    internal static class CLIStringsStorage
    {
        internal const string MAIN_MENU_HEADER = "Информация по типам:\n";
        internal const string ASM_MENU_HEADER = "Общая информация по типам:\n";
        internal const string RETURN_TO_MAIN_MENU = "Вернуться в главное меню: 0";
        internal const string ARGS_EXEPTION = "Invalid comand line argument ";
       
        internal readonly static string[] main_menu = new string[4]{
            "Выход из программы: ",
            "Общая информация по типам: ",
            "Выбрать тип изсписка: ",
            "Параметры консоли: "
        };
        internal readonly static string[] console_params_menu = new string[5]{
            "Синий: ",
            "Зеленый: ",
            "Желтый: ",
            "Красный: ",
            "Сбросить цвет: "
        };

        internal static string[] list_of_types = new string[9]{
            " - uint",
            " - int",
            " - long",
            " - float",
            " - double",
            " - char",
            " - string",
            " - decimal",
            " - Guid",
        };
    }
}