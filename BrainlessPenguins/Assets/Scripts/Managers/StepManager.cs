using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : Singleton<StepManager>
{
    public delegate void stepHandler();
    public static event stepHandler onStep;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
