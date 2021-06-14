
namespace matrix_type
{
   public interface IMatrix<T>
    {
        public T this[int i, int j] { get;}
        public int Rows { get;}
        public int Columns { get;}
        public int Size { get; }
        public bool IsSquared { get; }
        public bool IsEmpty { get; }
        public bool IsUnity { get;}
        public bool IsDiagonal { get;}
        public bool IsSymmetric { get;}
        public string ToString();
    }
}
