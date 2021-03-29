/* 
 * John Mordi
 * InputInvoker.cs
 * Assignment#7
 * Handles player inputs and calls the necessary commands based on the inputs
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputInvoker : MonoBehaviour
{
    Command clickMoveW;
    Command clickMoveB;
    public Piece piece;
    GameObject innerPiece;
    Stack<Command> commands;
    // Start is called before the first frame update
    private void Awake()
    {
        clickMoveB = new ClickMoveB(piece);
        clickMoveW = new ClickMoveW(piece);
        commands = new Stack<Command>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Ground" && innerPiece != null)
                {
                    if (innerPiece.tag == "BPiece")
                    {
                        commands.Push(clickMoveB);
                        clickMoveB.Execute(hit, innerPiece);
                        innerPiece = null;
                    }
                    else if (innerPiece.tag == "WPiece")
                    {
                        commands.Push(clickMoveW);
                        clickMoveW.Execute(hit, innerPiece);
                        innerPiece = null;
                    }
                }
                else if(hit.collider.tag != "Ground" && innerPiece == null)
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    innerPiece = hit.collider.gameObject;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Command temp = commands.Pop();
            temp.Undo();
        }
    }
}
