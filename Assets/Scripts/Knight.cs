using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public override void Init(int playerNum, GenerateBoard board)
    {
        base.Init(playerNum, board);
        if (playerNum == 2)
        {
            this.rotate180();
        }
    }

    public override bool[,] getPossibleMoves()
    {
        Debug.Log("Knight POSSIBLE");
        return new bool[8, 8];
    }
}
