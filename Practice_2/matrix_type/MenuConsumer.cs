using System;
using System.Collections.Generic;
using System.Text;

namespace matrix_type
{
    internal class MenuConsumer : MatrixInfo<Matrix<double>>
    {
        private Action exit;
        private Action<string> print;
        private Func<string> input;
        private List<MyMatrix> matrices;
        private string select_matrix = "Укажите какие матрицы ";
        internal MenuConsumer(Action<string> print, Func<string> read,Action exit, List<MyMatrix> myMatrices)
        {
            this.print = print;
            this.exit = exit;
            input = read;
            matrices = myMatrices;
        }
        internal void ShowMenu()
        {
           print(menu_info(MainMenuKeyValuePair));
            double inp = try_read_asDouble();
            switch(inp)
            {
                case 1:
                    print(MainMenuKeyValuePair[1]);
                    matrices.Add(MyMatrix.ParseMatrix(input()));
                    print("Ваши матрицы: " + "\n");
                    print_matrix();
                    ShowMenu();
                    break;
                case 2:
                    Operationmenu();
                    break;
                case 0:
                    exit();
                    break;
                //default:
                //    throw new Exception(arg_exeption);
                     
            }
        }
        internal void Operationmenu()
        {
            while (true)
            {
                int first = 0;
                int second = 0;
                try
                {
                    print(menu_info(OperationMenuKeyValuePair));
                    double inp = try_read_asDouble();
                    switch (inp)
                    {
                        case 1:
                            print(GetMatrixInfo(matrices));
                            break;
                        case 2:
                            print("Выберите матрицу: ");
                            print_matrix();
                            int choise = Convert.ToInt32(input());
                            if (matrices == null || matrices.Count == 0)
                            {
                                print("Создайте матрицу выбрав пункт [1] главного меню" + "\n");
                                ShowMenu();
                            }
                            print("Введите число: " + "\n");
                            double d = try_read_asDouble();
                            if (choise < 0 || choise > matrices.Count - 1) throw new Exception($"Matrix with index[{choise}] not found" + "\n");
                            print(matrices[choise].MultiplyByNumber(d).ToString());
                            break;
                        case 3:
                            print(select_matrix + ",произведение которых нужно найти: " + "\n");
                            print_matrix();
                            second = 0;
                            first = read_args(out first);
                            matrix = matrices[second] * matrices[first];
                            print(matrix.ToString());
                            break;
                        case 4:
                            print(select_matrix + ",сумму которых нужно найти: " + "\n");
                            print_matrix();
                            second = 0;
                            first = read_args(out first);
                            matrix = matrices[second] + matrices[first];
                            print(matrix.ToString());
                            break;
                        case 5:
                            print(select_matrix + ",разницу которых нужно найти: " + "\n");
                            print_matrix();
                            second = 0;
                            first = read_args(out first);
                            matrix = matrices[second] - matrices[first];
                            print(matrix.ToString());
                            break;
                        case 6:
                            print(MyMatrix.GetUnityOrEmpty(Convert.ToInt32(input())).ToString());
                            break;
                        case 7:
                            print(MyMatrix.GetUnityOrEmpty(Convert.ToInt32(input()), true).ToString());
                            break;
                        case 0:
                            ShowMenu();
                            break;
                    }
                }
                catch(Exception ex)
                {
                    print(ex.Message);
                    ShowMenu();
                }
            }

        }
        private string menu_info(Dictionary<int,string> info)
        {
            StringBuilder menu_content = new StringBuilder();
            foreach (var key_val_pair in info) menu_content.Append(key_val_pair.Key.ToString() + key_val_pair.Value + "\n");
            return menu_content.ToString();
        }
        private double try_read_asDouble()
        {
            try
            {
                double inp = Convert.ToDouble(input());
                return inp;
            }
             catch
            {
                throw new ArgumentException("Uncorrect argument!");
            }
        }
        private void print_matrix()
        {
            int i = 0;
            foreach (var m in matrices)
            {
                print("[" + i.ToString() + "]" + "\n");
                print(m.ToString());
                i++;
            }
        }
        private int read_args( out int reg_2)
        {
            reg_2 = Convert.ToInt32(input());
            return Convert.ToInt32(input());
        }
    }
}
