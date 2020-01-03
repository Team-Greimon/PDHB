using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrowActionBtn : MonoBehaviour
{
    public int _actionType;
    public int _param;
    public int _btnID;
    
    public void onClick()
    {
        UIManager.GetInst().actionBtnEventTrigger(_actionType,_param,_btnID);
    }
}
