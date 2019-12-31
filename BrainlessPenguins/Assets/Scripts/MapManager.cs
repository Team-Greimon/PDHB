using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MapManager : Singleton<MapManager>
{
    public void LoadMap(int mapId)
    {
        var map = GetMapFromFile(mapId);
        _map = map;
        MakeMapOnScene();
    }

    protected void MakeMapOnScene()
    {

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

    public Vector3 GetTileLocalPosition(int rowPos, int colPos)
    {
        return new Vector3(rowPos, colPos, 0);
    }

    public Tile GetTile(int r, int c)
    {
        return _map.GetTile(r, c);
    }
    protected Map _map;

    // tiles - todo: 구조적 개선 필요. tileData 클래스 생성
    public Sprite GetSpriteForTileType(Tile.TileType tileType)
    {
        string spriteName = "";
        switch (tileType)
        {
            case Tile.TileType.dirt:
                spriteName = "dirt";
                break;
            case Tile.TileType.grass:
                spriteName = "grass";
                break;
            case Tile.TileType.ice:
                spriteName = "ice";
                break;
            default:
                spriteName = "";
                break;
        }
        return _tileAtlas.GetSprite(spriteName);
    }
    public SpriteAtlas _tileAtlas;
}
