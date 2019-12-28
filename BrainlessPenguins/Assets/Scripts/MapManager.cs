using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    public void LoadMap(int mapId)
    {
        string fileName = string.Format("Map{0,4:D4}", mapId);
        string word = File.ReadAllText(txtFilePath);
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        string[] words = textAsset.text.Split();
        foreach (string word in words)
        {
            int i = int.Parse(word);

        }

    }

    public Tile GetTile(int r, int c)
    {
        return _map.GetTile(r, c);
    }
    protected Map _map;
}