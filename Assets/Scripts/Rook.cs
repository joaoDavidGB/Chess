using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public override void Init(int payerNum, GenerateBoard board)
    {
        Debug.Log("Init ROOK");
        base.Init(payerNum, board);
    }

    public override bool[,] getPossibleMoves()
    {
        Debug.Log("ROOK POSSIBLE");
        int currentRow = this.getCurrentCell().getRow();
        int currentCol = this.getCurrentCell().getCol();
        bool[,] possibleMoves = new bool[8, 8];

        for (int row = 0; row < 8; ++row)
        {
            if (row != currentRow)
            {
                possibleMoves[row, currentCol] = true;
            }
        }

        for (int col = 0; col < 8; ++col)
        { 
            if (col != currentCol)
            {
                possibleMoves[currentRow, col] = true;
            }
        }
        Debug.Log(currentRow + " " + currentCol);
        Debug.Log("Possible Moves " + possibleMoves);
        return possibleMoves;
        return new bool[8, 8];
    }
}
