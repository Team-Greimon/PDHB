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

        public Condition(ConditionType conditionType)
        {
            _conditionType = conditionType;
            _param = -1;
        }

        public Condition(ConditionType conditionType, Penguin.PenguinType penguinType)
        {
            _conditionType = conditionType;
            _param = (int)penguinType;
        }
        public Condition(ConditionType conditionType, Tile.TileType tileType)
        {
            _conditionType = conditionType;
            _param = (int)tileType;
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
        StepManager.onStep += onStep;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onStep()
    {

    }

    //setPenguinInstruction(펭귄종류, 조건 종류, 액션 종류, 충돌한 펭귄종류, 충돌한 타일종류)
    //충돌했을때의 조건에서 펭귄 타일 구분을 좀더 개선 해야함.
    public void setPenguinInstruction(Penguin.PenguinType penguinType, 
        Instruction.Condition.ConditionType conditionType, 
        Instruction.Action.ActionType actionType, 
        Penguin.PenguinType colisionPenguin =Penguin.PenguinType.black, 
        Tile.TileType colisionTile = Tile.TileType.ice)
    {
        switch (conditionType)
        {
            case Instruction.Condition.ConditionType.always:
                _instructionDictionary[penguinType].Add(new Instruction(
                        new Instruction.Condition(conditionType),
                        new Instruction.Action(actionType)
                    ));
                break;
            case Instruction.Condition.ConditionType.penguinCollision:
                _instructionDictionary[penguinType].Add(new Instruction(
                        new Instruction.Condition(conditionType,colisionPenguin),
                        new Instruction.Action(actionType)
                    ));
                break;
            case Instruction.Condition.ConditionType.tileCollision:
                _instructionDictionary[penguinType].Add(new Instruction(
                        new Instruction.Condition(conditionType,colisionTile),
                        new Instruction.Action(actionType)
                    ));
                break;
            default:

                break;
        }
    }

    //펭귄 instruction 리스트 반환
    public List<Instruction> getPenguinInstruction(Penguin.PenguinType penguinType)
    {
        return _instructionDictionary[penguinType];
    }

}
