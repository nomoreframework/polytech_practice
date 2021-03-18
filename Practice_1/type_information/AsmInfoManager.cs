using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;

namespace type_information
{
    internal class AsmInfoManager: IAsmInfoManager<Dictionary<string, string>>
    {
        public Dictionary<string, string> Asm_info_storage { get; private set; }

        public int refAssemblies { get; private set; }

        public int types_Of_current_asm { get; private set; }
        public int refTypes { get; private set; }
        public int valueTypes { get; private set; }

        public int interfaceTypes { get; private set; }

        public string type_with_max_methods { get; private set; }

        public string max_name { get; private set; }

        public string max_args { get; private set; }

        internal AsmInfoManager()
        {
            max_name = "";
            var asm = Assembly.GetExecutingAssembly();
            var assms = AppDomain.CurrentDomain.GetAssemblies();
            refAssemblies = assms.Length;

            int current_count_of_methods = 0;
            //   int current_count_of_params = 0;
            foreach (var item in assms)
            {
                var types = item.GetTypes();
                types_Of_current_asm += types.Length;
                refTypes += types.Select(t => t).Where(t => t.IsClass).ToArray().Length;
                interfaceTypes += types.Select(t => t).Where(t => t.IsInterface).ToArray().Length;

                foreach (var t in types)
                {
                    string name = t.GetMethods().Select(m => m.Name.Max()).ToString();
                    var methods = t.GetMethods().Length;
                    //   string method_name = t.GetMethods().Max(m => m.GetParameters().Length);

                    if (t.GetMethods().Length > current_count_of_methods)
                    {
                        type_with_max_methods = t.Name;
                        current_count_of_methods = t.GetMethods().Length;
                    }
                    if (name.Length > max_name.Length) max_name = name;
                }
            }
            valueTypes = types_Of_current_asm - refTypes;
        }
        public Dictionary<string, string> Initial_Asm_info_storage()
        {
            Asm_info_storage = new Dictionary<string, string>
            {
                ["Подключенные сборки: "] = refAssemblies.ToString(),
                ["Всего типов повсем подключенным сборкам: "] = types_Of_current_asm.ToString(),
                ["Ссылочные типы: "] = refTypes.ToString(),
                ["Значимые типы: "] = valueTypes.ToString(),
                ["Типы-интерфейсы: "] = interfaceTypes.ToString(),
                ["Тип смаксимальным числом методов: "] = type_with_max_methods,
                ["Самое длинное название метода: "] = max_name,
                ["Метод с наибольшим числом аргументов: "] = "-"
            };
            return Asm_info_storage;
        }
    }
}