using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override void Init(int payerNum, GenerateBoard board)
    {
        Debug.Log("INIT PAWN" + payerNum);
        base.Init(payerNum, board);
    }
}
