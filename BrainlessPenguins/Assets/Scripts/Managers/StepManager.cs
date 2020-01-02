using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : Singleton<StepManager>
{
    public float stepDuration = 0.5f;

    public delegate void stepHandler();
    public static event stepHandler BeforeStep;
    public static event stepHandler OnStep;
    public static event stepHandler EndStep;

    // Start is called before the first frame update
    void Start()
    {
        _timer = new Timer(stepDuration);
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer.Update(Time.deltaTime))
        {
            BeforeStep?.Invoke();
            OnStep?.Invoke();
            EndStep?.Invoke();
            _timer.Reset();
        }
    }

    Timer _timer;
}
