using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction
{
    public class Condition
    {
        public enum ConditionType
        {
            tileCollision,
            penguinCollision,
            always
        }
        ConditionType _conditionType;
        public int _param;

        public Condition(ConditionType conditionType,int param)
        {
            _conditionType = conditionType;
            _param = param;
        }
    }

    public class Action
    {
        public enum ActionType
        {
            turn
        }
        public ActionType _actionType;

        public Action(ActionType actionType)
        {
            _actionType = actionType;
        }
    }

    public Instruction(Condition condition,Action action)
    {
        _condition = condition;
        _action = action;
    }
    public Condition _condition;
    public Action _action;
}

public class InstructionManager : Singleton<InstructionManager>
{
    Dictionary<Penguin.PenguinType, List<Instruction>> _instructionDictionary;

    // Start is called before the first frame update
    void Start()
    {
        StepManager.OnStep += onStep;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onStep()
    {

    }

    //setPenguinInstruction(펭귄종류, 조건 종류, 액션 종류, 충돌물체종류)
    public void setPenguinInstruction(Penguin.PenguinType penguinType,
        Instruction.Condition.ConditionType conditionType,
        Instruction.Action.ActionType actionType,
        int param = -1
        )
    {
        _instructionDictionary[penguinType].Add(new Instruction(
            new Instruction.Condition(conditionType,param),
            new Instruction.Action(actionType)
            ));
    }

    //펭귄 instruction 리스트 반환
    public List<Instruction> getPenguinInstruction(Penguin.PenguinType penguinType)
    {
        return _instructionDictionary[penguinType];
    }

}
