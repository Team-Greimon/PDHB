using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public Timer(float duration)
    {
        _duration = duration;
        _timeLeft = duration;
    }

    public void SetDuration(float duration)
    {
        _duration = duration;
        _timeLeft = duration;
    }
    public bool Update(float dt)
    {
        if (_timeLeft > 0.0f)
        {
            _timeLeft -= dt;
        }
        return _timeLeft <= 0.0f;
    }
    public void Reset()
    {
        _timeLeft += _duration;
    }

    float _timeLeft;
    float _duration;
}
