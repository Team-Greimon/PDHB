using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinManager : Singleton<PenguinManager>
{
    public void Reset()
    {
        foreach (var penguin in _penguins)
        {
            penguin.gameObject.SetActive(false);
        }
    }

    public void MakePenguin(int r, int c, Penguin.PenguinType penguinType, Penguin.Direction direction)
    {
        var gameObj = ObjectPoolManager.GetInst().GetPooledObject("Penguin");
        Penguin newPenguin = gameObj.GetComponent<Penguin>();
        newPenguin.Initialize(r, c, penguinType, direction);
        _penguins.Add(newPenguin);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    HashSet<Penguin> _penguins = new HashSet<Penguin>();
    public GameObject _penguinPrefab;

}
