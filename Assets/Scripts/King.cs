using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public override void Init(int payerNum, GenerateBoard board)
    {
        base.Init(payerNum, board);
    }

    public override bool[,] getPossibleMoves()
    {
        Debug.Log("King POSSIBLE");
        return new bool[8, 8];
    }
}
