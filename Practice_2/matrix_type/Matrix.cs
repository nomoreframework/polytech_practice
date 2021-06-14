using System;
using System.Text;

namespace matrix_type
{
    public class Matrix<T> : IMatrix<T> 
    {
        public virtual T this[int i, int j] {
            get
            {
                return matrix[i, j];
            }
            private set {
                matrix[i, j] = value;
            }
        }
        public virtual T this [int i]
        {
            get
            {
                return vector[i];
            }
            private set
            {
                vector[i] = value;
            }
        }
        public Matrix(T [,] matrix)
        {
            this.matrix = matrix;
            Rows = matrix.GetUpperBound(0) + 1;
            Columns = matrix.GetUpperBound(1) + 1;
            if (Rows == Columns) { IsSymmetric = true; IsSquared = true; }
            else { IsSymmetric = false; IsSquared = false; }
            if (Rows == 0 || Columns == 0) is_vector = false;

        }
        public Matrix(T [] vector)
        {
            this.vector = vector;
            IsUnity = false;
            is_vector = true;
            IsSymmetric = true; IsSquared = true;
            Size = vector.Length;
        }

        public virtual int Rows { get; protected set; }
        public virtual int Columns { get; protected set; }
        public virtual int Size { get; protected set; }
        public virtual bool IsSquared { get; protected set; }
        public virtual bool IsEmpty { get; protected set; }
        public virtual bool IsUnity { get; protected set; }
        public virtual bool IsDiagonal { get; protected set; }
        public virtual bool IsSymmetric { get; protected set; }
        protected static void NullRefExeption() => throw new Exception(new NullReferenceException().StackTrace);

        //private section
        private T[,] matrix;
        private T[] vector;
        public bool is_vector;

        public virtual Matrix<T> Transpose()
        {
            if (matrix == null) NullRefExeption();
            if(is_vector)
            {
                matrix = new T[vector.Length, 0];
                for(int i = 0; i < vector.Length; i++)
                {
                    matrix[i, 0] = vector[i];
                }
                return new Matrix<T>(matrix);
            }
            else
            {
                T[,] transpose_arr = new T [Columns,Rows];
                for(int i = 0; i < Columns;i++)
                { 
                    for(int j = 0; j < Rows;j++)
                    {
                        transpose_arr[i, j] = matrix[j, i];
                        Console.WriteLine(matrix[j, i]);
                    }
                }
                return new Matrix<T>(transpose_arr);
            }
        }
        protected virtual bool is_unity()
        {
            throw new Exception("Is not overriden");
        }
        public virtual Matrix<T> MultiplyByNumber(T number)
        {
            throw new Exception("Is not overriden");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            if (is_vector)
            {
                for (int i = 0; i < vector.Length; i++) result.Append(" " + vector[i].ToString());
            }
            else
            {
                for (int i = 0; i < Rows; i++) 
                {
                    for (int j = 0; j < Columns; j++) result.Append(" " + matrix[i,j].ToString());
                    result.Append("\n");
                }
            }
            return result.ToString();
        }
    }
}
