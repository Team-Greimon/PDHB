using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayBtn : MonoBehaviour
{
    bool _isStart = false;
    bool _isChecked = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (_isStart)
        {
            GameManager.GetInst().SetGameRunning(false);
        }
        else
        {
            _isChecked = true;
            foreach (List<GameObject> list in UIManager.GetInst()._instructionArray)
            {
                foreach (GameObject instruction in list)
                {
                    UIInstructionBtn temp = instruction.GetComponent<UIInstructionBtn>();

                    if (temp._selfActionType != Instruction.Action.ActionType.nullAction)
                    {
                        InstructionManager.GetInst().setPenguinInstruction(temp._selfPenguinType, temp._selfConditionType, temp._selfActionType, temp._param);                        
                    }
                    else
                    {
                        _isChecked = false;
                        Debug.Log("Set All Action");
                    }
                }
            }
            if (_isChecked)
            {
                GameManager.GetInst().SetGameRunning(true);
            }
        }
        _isStart = !_isStart;
    }
}
