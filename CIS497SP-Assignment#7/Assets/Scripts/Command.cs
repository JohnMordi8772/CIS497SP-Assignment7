/* 
 * John Mordi
 * Command.cs
 * Assignment#7
 * interface for command classes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    void Execute(RaycastHit hit, GameObject innerPiece);
    void Undo();
}
