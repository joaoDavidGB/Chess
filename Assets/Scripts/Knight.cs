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
            //this._renderer.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
