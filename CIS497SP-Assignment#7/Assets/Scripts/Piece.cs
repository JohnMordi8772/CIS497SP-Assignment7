/* 
 * John Mordi
 * Pieces.cs
 * Assignment#7
 * Holds the functions called by execute in command classes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    GameObject piece = null;

    public void ClickMoveW(RaycastHit hit, GameObject innerPiece)
    {
            piece = innerPiece;
            piece.transform.position = hit.collider.transform.position;
            piece.GetComponent<MeshRenderer>().material.color = Color.white;
            piece = null;
    }

    public void ClickMoveB(RaycastHit hit, GameObject innerPiece)
    {
            piece = innerPiece;
            piece.transform.position = hit.collider.transform.position;
            piece.GetComponent<MeshRenderer>().material.color = Color.gray;
            piece = null;
    }
}
