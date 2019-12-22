using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    public enum PenguinType
    {
        red = 0,
        black = 1,
    }

    // StepManager 에 자기 자신도 이벤트 받도록 등록
    void OnEnable()
    {
        StepManager.onStep += onStep;
    }
    void OnDisable()
    {
        StepManager.onStep -= onStep;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onStep()
    {
        // 스텝이 넘어갈 때 이곳 실행
    }

    PenguinType _penguinType;
}
