using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPenguinBtn : MonoBehaviour
{
    public int _myNumber = 0;
    public void onClick()
    {
        UIManager.GetInst().btnEventTrigger(_myNumber);
    }
}
