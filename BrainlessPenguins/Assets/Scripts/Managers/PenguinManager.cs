using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinManager : Singleton<PenguinManager>
{
    public void MakePenguin(int x, int y, Penguin.PenguinType penguinType)
    {
        GameObject newObject = Instantiate(_penguinPrefab) as GameObject;
        Penguin newPenguin = newObject.GetComponent<Penguin>();
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

    HashSet<Penguin> _penguins;
    public GameObject _penguinPrefab;

}
