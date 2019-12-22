using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncryptedVar<T>
{
    public T get()
    {
        return _elem;
    }

    public void set(T elem)
    {
        _elem = elem;
    }

    T _elem;
}
