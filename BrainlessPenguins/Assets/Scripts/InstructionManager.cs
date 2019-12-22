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
        public int _param;
    }

    public class Action
    {
        public enum ActionType
        {
            turn
        }
        public ActionType _actionType;
    }

    public Condition _condition;
    public Action _action;
}

public class InstructionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
