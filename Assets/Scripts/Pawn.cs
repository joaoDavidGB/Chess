using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override void Init(int playerNum, GenerateBoard board)
    {
        Debug.Log("INIT PAWN" + playerNum);
        base.Init(playerNum, board);
    }

    public override bool[,] getPossibleMoves()
    {
        Debug.Log("PAWN MOVES");
        int currentRow = this.getCurrentCell().getRow();
        int currentCol = this.getCurrentCell().getCol();
        bool[,] possibleMoves = new bool[8, 8];
        if (this.playerNum == 1)
        {
            possibleMoves[currentRow, currentCol + 1] = true;
        } else
        {
            possibleMoves[currentRow, currentCol - 1] = true;
        }
        Debug.Log(currentRow + " " + currentCol);
        Debug.Log("Possible Moves " + possibleMoves);
        return possibleMoves;
    }
}
