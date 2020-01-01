using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T GetInst()
    {
        if (!_instance)
        {
            _instance = FindObjectOfType<T>();
            if (!_instance)
            {
                var errMsg = string.Format("There needs to be one active Manager script for {0} in your scene.", typeof(T).Name);
                Debug.LogError(errMsg);
            }
        }

        return _instance;
    }
    private static T _instance;
}
