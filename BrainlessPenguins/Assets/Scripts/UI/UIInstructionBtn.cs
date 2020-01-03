using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInstructionBtn : MonoBehaviour
{
    public GameObject _arrowContainer;
    public KeyValuePair<int, int> _index = new KeyValuePair<int, int>(-1, -1);
    public Instruction _instruction;
    public Penguin.PenguinType _selfPenguinType;
    public Instruction.Condition.ConditionType _selfConditionType;
    public Instruction.Action.ActionType _selfActionType;
    public int _param = -1;
    public GameObject _selfCondition;
    public GameObject _selfDirection;
    // Start is called before the first frame update
    void Start()
    {
        _selfActionType = Instruction.Action.ActionType.nullAction;
        _selfDirection.GetComponent<Image>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        _arrowContainer.transform.position = new Vector2(transform.position.x-20,transform.position.y+50);
        _arrowContainer.SetActive(true);
        _arrowContainer.GetComponent<UIArrowContainer>()._instructionBtn = gameObject;
    }

}
