using System;

namespace Question6;

public class OperationTable
{
    public delegate int BinaryOp(int x, int y);
    private int _sRow, _eRow;
    private int _sCol, _eCol;
    private BinaryOp bOp;

    public OperationTable(int sRow, int eRow, int sCol,int eCol, BinaryOp op)
    {
        _sRow = sRow;
        _eRow = eRow;
        _sCol = sCol;
        _eCol = eCol;
        bOp = op;
    }

    public void Print()
    {
        Console.Write("\t");

        for (int col = _sCol; col <= _eCol; col++)
        {
            Console.Write($"{col}\t");
        }
        Console.WriteLine();

        Console.WriteLine("\t" + new string('-', (_eCol - _sCol + 1) * 8));

        for (int row = _sRow; row <= _eRow; row++)
        {
            Console.Write($"{row} |\t");

            for (int col = _sCol; col <= _eCol; col++)
            {
                int result = bOp(row, col);
                Console.Write($"{result}\t");
            }

            Console.WriteLine();
        }
    }
}