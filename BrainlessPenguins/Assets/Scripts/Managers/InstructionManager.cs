using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Instruction
{
    public class Condition
    {
        // 먼저 올수록 먼저 체크된다
        public enum ConditionType
        {
            tileCollision,
            penguinCollision,
            always
        }
        public ConditionType _conditionType;
        public int _param;

        public Condition(ConditionType conditionType, int param = -1)
        {
            _conditionType = conditionType;
            _param = param;
        }
    }

    public class Action
    {
        public enum ActionType
        {
            turn,
            moveForward,
            color,
            createPenguin,
            nullAction
        }
        public ActionType _actionType;
        public int _param;

        public Action(ActionType actionType, int param = -1)
        {
            _actionType = actionType;
            _param = param;
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
        _instructionDictionary = new Dictionary<Penguin.PenguinType, List<Instruction>>();
        foreach(Penguin.PenguinType penguinType in Enum.GetValues(typeof(Penguin.PenguinType)))
        {
            _instructionDictionary[penguinType] = new List<Instruction>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //setPenguinInstruction(펭귄종류, 조건 종류, 액션 종류, 충돌물체종류)
    public void setPenguinInstruction(Penguin.PenguinType penguinType,
        Instruction.Condition.ConditionType conditionType,
        Instruction.Action.ActionType actionType,
        int param = -1
        )
    {
        // Fixme: ActionType 에도 param 추가한 것 반영 (0은 더미)
        _instructionDictionary[penguinType].Add(new Instruction(
            new Instruction.Condition(conditionType,param),
            new Instruction.Action(actionType, 0)
            ));
    }

    //펭귄 instruction 리스트 반환
    public List<Instruction> getPenguinInstruction(Penguin.PenguinType penguinType)
    {
        return _instructionDictionary[penguinType];
    }

}
