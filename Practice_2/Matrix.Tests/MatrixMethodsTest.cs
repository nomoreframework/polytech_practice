using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using matrix_type;

namespace Matrix.Tests
{
   public class MatrixMethodsTest
    {
        readonly MyMatrix matrix = new MyMatrix(new double[] { 1, 2, 3, 4, 5 });
        [Fact]
        public void MatrixToStringIsCorrect()
        {
            Assert.Equal(" 1 2 3 4 5", matrix.ToString());
        }
        [Fact]
        public void MatrixMultiplyCorrect()
        {
            Assert.Equal(new Matrix<double>(new double[3, 1] { { -18 }, {-20 }, {-16 }}),
                         new MyMatrix(new double[3, 3] { { 5, 8, -4}, { 6, 9, -5}, { 4, 7, -3 } }) * 
                         new MyMatrix(new double[3, 1] { { 2 }, { -3 }, { 1 } }));
        }
    }
}
