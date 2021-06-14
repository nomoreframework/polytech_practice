using System;
namespace matrix_type
{
    public class MyMatrix : Matrix<double>
    {
        private Matrix<double> matrix;
        private static string example = "\n" + "Example -> '1 2 3, 1.4 12 1.1'" +
        "\n" + "1" + "   " + "2" + "   " + "3" + "   " + "\n" + "1.4 12 1.1";
        public MyMatrix(double[,] matrix) : base(matrix)
        {
            this.matrix = new Matrix<double>(matrix);
            IsUnity = is_unity();
        }
        public MyMatrix(double [] vector) : base(vector)
        {
            matrix = new Matrix<double>(vector);
        }
        public static Matrix<double> GetUnityOrEmpty(int size, bool empty = false)
        {
            if (empty) return new Matrix<double>(new double[size, size]);
            double[,] matrix_unity = new double[size, size];
            int column_position = 0;
            for (int i = 0; i < size; i++)
            {
                matrix_unity[i, column_position] = 1; 
                column_position++;
            }
            return new Matrix<double>(matrix_unity);
        }
        public static MyMatrix ParseMatrix(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new Exception($"Error! - string - '{value}' doesn't contains numbers" + example);
            string[] rows = value.Split(',');
            string[] columns = rows[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double[,] matrix = new double[rows.Length, columns.Length];
            try
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    columns = rows[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < columns.Length; j++)
                    {
                        matrix[i, j] = Convert.ToDouble(columns[j].Replace('.', ','));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return new MyMatrix(matrix);
        }
        protected override bool is_unity()
        {
                for(int j = 0; j < Columns; j++)
                {
                    if(matrix[j,j] != (double)1)
                    {
                        return false;
                    }
                }
            return true;
        }
        public override Matrix<double> MultiplyByNumber(double number)
        {
            if(matrix.is_vector)
            {
                double[] res = new double[matrix.Size];
                for (int i = 0; i < matrix.Size; i++) res[i] = matrix[i] * number;
                return new Matrix<double>(res);
            }
            double[,] result = new double[Rows, Columns];
            for(int i = 0; i < Rows;i++)
            {
                for(int j = 0; j < Columns; j++)
                {
                   result[i,j] =  matrix[i, j] * number;
                }
            }
            return new Matrix<double>(result);
        }
        public static Matrix<double> operator +(MyMatrix matrix1, Matrix<double> matrix2)
        {
            if (matrix1 == null || matrix2 == null) NullRefExeption();
            if (matrix1.Rows != matrix2.Rows && matrix1.Columns != matrix2.Columns) throw new Exception("Matrices have different dimensions");
            double[,] result = new double[matrix1.Columns, matrix1.Rows]; 
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for(int j = 0; j < matrix1.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return new Matrix<double>(result);
        }
        public static Matrix<double> operator -(MyMatrix matrix1, Matrix<double> matrix2)
        {
            if (matrix1 == null || matrix2 == null) NullRefExeption();
            if (matrix1.Rows != matrix2.Rows && matrix1.Columns != matrix2.Columns) throw new Exception("Matrices have different dimensions");
            double[,] result = new double[matrix1.Columns, matrix1.Rows];
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return new Matrix<double>(result);
        }
        public static Matrix<double> operator *(MyMatrix matrix1, Matrix<double> matrix2)
        {
            if (matrix1 == null || matrix2 == null) NullRefExeption();
            if (matrix1.Columns != matrix2.Rows) throw new Exception("The number of rows in matrix # 1 does not match the number of columns in matrix # 2");
            double[,] result = new double[matrix1.Rows, matrix2.Columns];
            for(int i = 0; i < matrix1.Rows; i++)
            {
                for(int j = 0; j < matrix2.Columns; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < matrix1.Columns; k++)
                    {

                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }                    
                }
            }
            return new Matrix<double>(result);
        }
    }
}
