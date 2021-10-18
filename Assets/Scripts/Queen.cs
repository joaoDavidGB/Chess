using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public override void Init(int payerNum, GenerateBoard board)
    {
        base.Init(payerNum, board);
    }

    public override bool[,] getPossibleMoves()
    {
        Debug.Log("Queen POSSIBLE");
        return new bool[8, 8];
    }
}
