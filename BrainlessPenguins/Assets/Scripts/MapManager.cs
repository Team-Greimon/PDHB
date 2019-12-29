using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    public void LoadMap(int mapId)
    {
        var map = GetMapFromFile(mapId);
        _map = map;
    }

    protected Map GetMapFromFile(int mapId)
    {
        string fileName = string.Format("map{0,4:D4}", mapId);
        List<List<Tile>> tiles = new List<List<Tile>>();
        try
        {
            // string word = File.ReadAllText(txtFilePath);
            TextAsset textAsset = Resources.Load<TextAsset>(fileName);
            string[] lines = textAsset.text.Split('\n');

            foreach (string line in lines)
            {
                List<Tile> tileLine = new List<Tile>();
                var words = line.Split();
                foreach (string word in words)
                {
                    int tileTypeNum = int.Parse(word);
                    tileLine.Add(new Tile((Tile.TileType)tileTypeNum));
                }
                tiles.Add(tileLine);
            }
        }
        catch
        {
            Debug.LogError(fileName + " 을 읽는 데에 실패하였습니다.");
        }
        return new Map(tiles);
    }

    public Tile GetTile(int r, int c)
    {
        return _map.GetTile(r, c);
    }
    protected Map _map;
}