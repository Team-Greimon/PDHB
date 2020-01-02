using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetGameRunning(bool gameRunning)
    {
        _gameRunning = gameRunning;
    }

    void LoadLevel()
    {
        MapManager.GetInst().LoadMap(1);
    }

    public bool _gameRunning { get; }
}
