using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    public void Initialize(int r, int c, PenguinType penguinType, Direction direction)
    {
        _r = r;
        _c = c;
        _penguinType = penguinType;
        _direction = direction;

        transform.position = MapManager.GetInst().GetTileLocalPosition(r, c);
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

    // 스텝이 넘어갈 때 이곳 실행
    void OnStep()
    {
        _c++;
        transform.position = MapManager.GetInst().GetTileLocalPosition(_r, _c);
    }

    int _r;
    int _c;
    Direction _direction;
    PenguinType _penguinType;
}