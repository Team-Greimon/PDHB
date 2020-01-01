using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : Singleton<StepManager>
{
    public delegate void stepHandler();
    public static event stepHandler OnStep;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer.Update(Time.deltaTime))
        {
            OnStep?.Invoke();
            _timer.Reset();
        }
    }

    Timer _timer = new Timer(1.0f);
}
