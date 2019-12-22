using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    public Penguin(int x, int y, PenguinType penguinType)
    {
        _x = x;
        _y = y;
        _penguinType = penguinType;
    }

    public enum PenguinType
    {
        red = 0,
        black = 1,
    }
    // StepManager 에 자기 자신도 이벤트 받도록 등록
    void OnEnable()
    {
        StepManager.onStep += OnStep;
    }
    void OnDisable()
    {
        StepManager.onStep -= OnStep;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnStep()
    {
        // 스텝이 넘어갈 때 이곳 실행
    }

    int _x;
    int _y;
    PenguinType _penguinType;
}