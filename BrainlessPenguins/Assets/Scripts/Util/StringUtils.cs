using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class IntegerStream
{
    public IntegerStream(string s)
    {
        var arr = s.Split(null);
        foreach (var token in arr)
        {
            if (!string.IsNullOrEmpty(token))
            {
                _intArray.Add(int.Parse(token));
            }
        }
    }
    public int Read()
    {
        if (_position < _intArray.Count)
        {
            return _intArray[_position++];
        }
        else
        {
            Debug.LogError("IntegerStream 의 범위를 초과하여 읽고 있습니 ");
            return -1;
        }
    }

    readonly List<int> _intArray = new List<int>();
    int _position;
}

public static class StringUtils
{
    public static MemoryStream GenerateStreamFromString(string value)
    {
        return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
    }
}
