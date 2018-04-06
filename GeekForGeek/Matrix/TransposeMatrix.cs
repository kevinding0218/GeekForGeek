using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.LinkedList
{
    /// <summary>
    /// Transpose of a matrix is obtained by changing rows to columns and columns to rows. 
    /// In other words, transpose of A[][] is obtained by changing A[i][j] to A[j][i].
    /// Input:
    /// 00 10 20
    /// 01 11 21
    /// 02 12 22
    /// Output:
    /// 00 01 02
    /// 10 11 12
    /// 20 21 22
    /// </summary>
    public static class TransposeMatrix
    {
        private static void transpose(int[][] A, int[][] B, int N)
        {
            int i, j;
            for (i = 0; i < N; i++)
                for (j = 0; j < N; j++)
                    B[i][j] = A[j][i];
        }
    }
}
