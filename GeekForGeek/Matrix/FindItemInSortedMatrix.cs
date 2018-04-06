using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Matrix
{
    /// <summary>
    /// Given a matrix in which each row and each column is sorted, write a method to find an element in it.
    /// </summary>
    public static class FindItemInSortedMatrix
    {
        /// <summary>
        /// Rows are sorted left to right in ascending order. Columns are sorted top to bottom in ascending order.
        /// Matrix is of size MxN.
        /// This algorithm works by elimination.Every move to the left (--col) eliminates all the elements
        /// below the current cell in that column.Likewise, every move down eliminates all the elements
        /// to the left of the cell inn that row.
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="elem"></param>
        /// <param name="M"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        private static bool FindElem(int[][] mat, int elem, int M, int N)
        {
            int row = 0, col = N - 1;
            while (row < M && col > 0)
            {
                if (mat[row][col] == elem)
                {
                    return true;
                }
                else if (mat[row][col] > elem)
                {
                    col--;
                }
                else
                {
                    row++;
                }
            }
            return false;
        }
    }
}
