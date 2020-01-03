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
            _isStart = !_isStart;
            GameManager.GetInst().SetGameRunning(false);
            MapManager.GetInst().LoadMap(1);
        }
        else
        {
            InstructionManager.GetInst().clearPenguinInstruction();
            _isChecked = true;
            foreach (List<GameObject> list in UIManager.GetInst()._instructionArray)
            {
                foreach (GameObject instruction in list)
                {
                    UIInstructionBtn temp = instruction.GetComponent<UIInstructionBtn>();

                    InstructionManager.GetInst().setPenguinInstruction(temp._selfPenguinType, temp._selfConditionType, temp._selfActionType, temp._conditionParam,temp._actionParam);                        
                }
            }
            if (_isChecked)
            {
                _isStart = !_isStart;
                GameManager.GetInst().SetGameRunning(true);
            }
        }
    }
}
