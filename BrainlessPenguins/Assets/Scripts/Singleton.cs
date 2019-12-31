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
                Debug.LogError("There needs to be one active GameManager script on a GameObject in your scene.");
        }

        return _instance;
    }
    private static T _instance;
}
