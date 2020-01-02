using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayBtn : MonoBehaviour
{
    GameObject UIManager;

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
        foreach(List<GameObject> list in UIManager.GetComponent<UIManager>()._instructionArray)
        {
            foreach(GameObject instruction in list)
            {
                UIInstructionBtn temp = instruction.GetComponent<UIInstructionBtn>();
                InstructionManager.GetInst().setPenguinInstruction(temp._selfPenguinType,temp._selfConditionType,temp._selfActionType,temp._param);
            }
        }
    }
}
