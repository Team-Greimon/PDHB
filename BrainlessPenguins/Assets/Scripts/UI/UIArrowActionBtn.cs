using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrowActionBtn : MonoBehaviour
{
    public int _actionType;
    
    public void onClick()
    {
        UIManager.GetInst().actionBtnEventTrigger(_actionType);
    }
}
