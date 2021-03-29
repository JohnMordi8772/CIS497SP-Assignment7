/* 
 * John Mordi
 * ClickMoveW.cs
 * Assignment#7
 * Command functionality for white pieces
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoveW : Command
{
    Piece piece;
    Stack<GameObject> piecesMoved;
    Stack<Vector3> posMovedFrom;

    public ClickMoveW(Piece piece)
    {
        this.piece = piece;
        piecesMoved = new Stack<GameObject>();
        posMovedFrom = new Stack<Vector3>();
    }

    public void Execute(RaycastHit hit, GameObject innerPiece)
    {
        piecesMoved.Push(innerPiece);
        posMovedFrom.Push(innerPiece.transform.position);
        piece.ClickMoveW(hit, innerPiece);
    }

    public void Undo()
    {
        if (piecesMoved.Count != 0)
        {
            Debug.Log("In statement");
            piecesMoved.Pop().transform.position = posMovedFrom.Pop();
        }
    }
}
