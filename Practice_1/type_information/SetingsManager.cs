using System.Collections.Generic;
using System;

namespace type_information
{
    internal struct Signature
    {
        internal string _overloads;
        internal string _parametrs;
        private int parametrs;
        internal int Parametrs
        {
            get => parametrs;
            set
            {
                parametrs = Parametrs;
            }
        }
    }
    internal class SetingsManager<T>
    {
        static Type t = typeof(T);
        const string MAIN_MENU_HEADER = "Информация по типам:\n";
        protected internal readonly string SELECT_TYPE = "Выберите тип:\n";
        protected internal readonly string TYPE_MENY_HEADER = "Информация по типу:" + t.Name;
        protected internal readonly string METHODS_MENY_HEADER = "Нажмите ‘M’ для вывода дополнительной информации по методам " + t.Name + ":";
        protected internal readonly string METHOTDS_OF_TYPE = "Методы типа " + t.Name + ":" + "\n";
        protected internal readonly string METHOD_NAME = "Название";
        protected internal readonly string COUNT_OF_OVERLOAD = "Число перегрузок";
        protected internal readonly string COUNT_OF_PARAMS = "Число параметров";

        protected internal Dictionary<string, Signature> type_methods_info;
        protected Dictionary<string, Signature> get_type_methods_info()
        {
            type_methods_info = new Dictionary<string, Signature>();
            var methods = t.GetMethods();
            int length = methods.Length;
            int current_overloads = 0;
            int most_count_parametrs = 0;
            int j = 1;
            for (int i = 0; i < length; i++)
            {
                if (j == length) break;
                most_count_parametrs = methods[i].GetParameters().Length;
                while (methods[j].Name == methods[i].Name)
                {
                    if (methods[j].GetParameters().Length > most_count_parametrs)
                        most_count_parametrs = methods[j].GetParameters().Length;
                    current_overloads++;
                    j++;
                    i++;
                }
                if (!type_methods_info.ContainsKey(methods[i].Name))
                    type_methods_info.Add(methods[i].Name, new Signature
                    {
                        _overloads = current_overloads.ToString(),
                        Parametrs = most_count_parametrs,
                        _parametrs = most_count_parametrs > 1 ? "0.." + most_count_parametrs.ToString() :
                                                                        most_count_parametrs.ToString()
                    });
                current_overloads = 0;
                j++;
            }
            return type_methods_info;
        }
        protected internal readonly Dictionary<string, string> type_menu_dict = new Dictionary<string, string>
        {
            ["Значимый тип: "] = new string(t.IsClass ? "-" : "+"),
            ["Пространство имен: "] = t.Namespace,
            ["Сборка: "] = t.Assembly.GetName().Name,
            ["Общее число элементов: "] = t.GetMembers().Length.ToString(),
            ["Число методов: "] = t.GetMethods().Length.ToString(),
            ["Число свойств: "] = t.GetProperties().Length.ToString(),
            ["Число полей: "] = t.GetFields().Length.ToString(),
            ["Список полей: "] = new String(String.IsNullOrEmpty(String.Concat<System.Reflection.FieldInfo>(t.GetFields())) ?
                                            "-" :
                                            String.Concat<System.Reflection.FieldInfo>(t.GetFields())),
            ["Список свойств: "] = new String(String.IsNullOrEmpty(String.Concat<System.Reflection.PropertyInfo>(t.GetProperties())) ?
                                             "-" :
                                            String.Concat<System.Reflection.PropertyInfo>(t.GetProperties()))
        };
    }
}

