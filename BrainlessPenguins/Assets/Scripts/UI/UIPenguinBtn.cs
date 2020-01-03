using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPenguinBtn : MonoBehaviour
{
    public int _myNumber = 0;
    public void onClick()
    {
        UIManager.GetInst()._instructionContainer.transform.position = new Vector2(UIManager.GetInst()._instructionContainer.transform.position.x,0);
        UIManager.GetInst().btnEventTrigger(_myNumber);
    }
}
