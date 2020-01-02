using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using condType = Instruction.Condition.ConditionType;
using actionType = Instruction.Action.ActionType;
using System;

public class Penguin : MonoBehaviour
{
    public void Initialize(int r, int c, PenguinType penguinType, Direction direction)
    {
        _r = r;
        _c = c;
        _penguinType = penguinType;
        _direction = direction;

        transform.position = MapManager.GetInst().GetTileLocalPosition(r, c);
        gameObject.SetActive(true);
    }

    public enum PenguinType
    {
        black = 0,
        pink = 1,
    }
    public enum Direction
    {
        east = 0,
        north = 1,
        west = 2,
        south = 3,
    }
    // x, y 가 아닌 r, c임 주ㅇ
    public static readonly Dictionary<Direction, System.Tuple<int, int>> DirToVec =
        new Dictionary<Direction, Tuple<int, int>>
        {
            [Direction.east] = Tuple.Create(0, 1),
            [Direction.north] = Tuple.Create(-1, 0),
            [Direction.west] = Tuple.Create(0, -1),
            [Direction.south] = Tuple.Create(1, 0)
        };


    // StepManager 에 자기 자신도 이벤트 받도록 등록
    void OnEnable()
    {
        StepManager.BeforeStep += BeforeStep;
        StepManager.OnStep += OnStep;
        StepManager.EndStep += EndStep;
    }
    void OnDisable()
    {
        StepManager.BeforeStep -= BeforeStep;
        StepManager.OnStep -= OnStep;
        StepManager.EndStep -= EndStep;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 스텝이 넘어갈 때 이곳 실행
    void BeforeStep()
    {
        CheckConditionsMet();
    }

    void OnStep()
    {
        RunActions();
    }

    void EndStep()
    {
        transform.position = MapManager.GetInst().GetTileLocalPosition(_r, _c);
    }

    protected void CheckConditionsMet()
    {
        _instructionsToRun.Clear();
        //var instructions = InstructionManager.GetInst().getPenguinInstruction(_penguinType);
        var instructions = GetDummyInstructions();
        foreach (var inst in instructions)
        {
            var condition = inst._condition;
            if (checkCondition(condition._conditionType, condition._param))
            {
                _instructionsToRun.Add(condition._conditionType, inst);
            }
        }

    }
    protected bool checkCondition(condType conditionType, int param)
    {
        switch (conditionType)
        {
            case condType.tileCollision:
                var tile = MapManager.GetInst().GetTile(_r, _c);
                return (int)tile._type == param;

            case condType.always:
                return true;

            default:
                return false;
        }
    }
    protected SortedList<condType, Instruction> _instructionsToRun = new SortedList<condType, Instruction>();

    protected void RunActions()
    {
       foreach (var keyValuePair in _instructionsToRun)
        {
            var inst = keyValuePair.Value;
            RunAction(inst._action);
        }
    }
    protected void RunAction(Instruction.Action action)
    {
        switch (action._actionType)
        {
            case actionType.turn:
                _direction += action._param;
                _direction = (Direction)(((int)_direction + 4) % 4);
                break;

            case actionType.moveForward:
                var vecToMove = DirToVec[_direction];
                _r += vecToMove.Item1;
                _c += vecToMove.Item2;
                break;

            case actionType.color:
                MapManager.GetInst().SetTile(_r, _c, (Tile.TileType)action._param);
                break;

            default:
                break;
        }
    }

    private List<Instruction> GetDummyInstructions()
    {
        List<Instruction> ret = new List<Instruction>();
        {
            var cond = new Instruction.Condition(condType.always);
            var ac = new Instruction.Action(actionType.moveForward);
            ret.Add(new Instruction(cond, ac));
        }
        {
            var cond = new Instruction.Condition(condType.tileCollision, 1);
            var ac = new Instruction.Action(actionType.turn, -1);
            ret.Add(new Instruction(cond, ac));
        }
        {
            var cond = new Instruction.Condition(condType.tileCollision, 3);
            var ac = new Instruction.Action(actionType.color, 2);
            ret.Add(new Instruction(cond, ac));
        }
        return ret;
    }

    int _r;
    int _c;
    Direction _direction;
    PenguinType _penguinType;
}
