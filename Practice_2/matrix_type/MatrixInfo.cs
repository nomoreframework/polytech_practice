using System;
using System.Collections.Generic;
using System.Text;

namespace matrix_type
{
    public class MatrixInfo<T> where T : class
    {
        public T matrix;
        public Dictionary<int, string> MainMenuKeyValuePair {
            get {
                mainMenuKeyValuePair = new Dictionary<int, string>
                {
                    [1] = " - Ввод матрицы",
                    [2] = " - Операции",
                    [0] = " - Выход"
                };
                return mainMenuKeyValuePair;
            }
            protected set { } }
        public Dictionary<int, string> OperationMenuKeyValuePair {
            get {
                operationMenuKeyValuePair = new Dictionary<int, string>
                {
                    [1] = " - Информация о матрице/матрицах",
                    [2] = " - Умножить матрицу на число",
                    [3] = " - Перемножить матрицы",
                    [4] = " - Сложить матрицы",
                    [5] = " - Вычесть матрицы",
                    [6] = " - Порождение единичной матрицы указаного размера",
                    [7] = " - Порождение нулевой матрицы указаного размера",
                    [0] = " - Вернуться в главное меню"
                };
                return operationMenuKeyValuePair;
            } protected set { }
        }

        //private section
        private Dictionary<int, string> mainMenuKeyValuePair;
        private Dictionary<int, string> operationMenuKeyValuePair;
        //public section 
        internal virtual string GetMatrixInfo(List<MyMatrix> matrix_list)
        {
            if (matrix_list == null) throw new Exception("matrices not found");
            StringBuilder info = new StringBuilder("");
            info.Append(new String(operationMenuKeyValuePair[1]));
            foreach (var matrix in matrix_list)
            {
                info.Append(new String("\n"
                + matrix.ToString()
                + "\n"
                + "Пустая" + (matrix.IsEmpty ? " - да" : "нет")
                + "\n"
                + "квадратная" + (matrix.IsSquared ? " - да" : " - нет")
                + "\n"
                + "диоганальная" + (matrix.IsDiagonal ? " - да" : " - нет")
                + "\n"
                + "Симметричная" + (matrix.IsSymmetric ? " - да" : "- нет")
                + "\n"
                + "Единичная" + (matrix.IsUnity ? " - да" : "- нет")
                + "\n"));
            }
            return  info.ToString();
        }
    }
}
