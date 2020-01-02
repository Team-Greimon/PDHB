using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.U2D;

public class MapManager : Singleton<MapManager>
{
    public void LoadMap(int mapId)
    {
        ConstructMapFromFile(mapId);
        MakeTilesOnScene();
    }

    protected void MakeTilesOnScene()
    {
        _tileObjects = new List<List<TileObject>>();
        for (int r = 0; r < _map.GetHeight(); r++)
        {
            _tileObjects.Add(new List<TileObject>());
            for (int c = 0; c < _map.GetWidth(); c++)
            {
                var gameObj = ObjectPoolManager.GetInst().GetPooledObject("Tile");
                var tileObj = gameObj.GetComponent<TileObject>();
                tileObj.Initialize(_map.GetTile(r, c)._type, r, c);
                _tileObjects[r].Add(tileObj);
            }
        }
    }

    protected void ConstructMapFromFile(int mapId)
    {
        string fileName = string.Format("map{0,4:D4}", mapId);
        List<List<Tile>> tiles = new List<List<Tile>>();
        try
        {
            // string word = File.ReadAllText(txtFilePath);
            TextAsset textAsset = Resources.Load<TextAsset>(fileName);
            IntegerStream integerStream = new IntegerStream(textAsset.text);
          
            int R = integerStream.Read();
            int C = integerStream.Read();
            for (int curR = 0; curR < R; curR++)
            {
                List<Tile> tileLine = new List<Tile>();
                for (int curC = 0; curC < C; curC++)
                {
                    int tileTypeNum = integerStream.Read();
                    tileLine.Add(new Tile((Tile.TileType)tileTypeNum));
                }
                tiles.Add(tileLine);
            }
            _map = new Map(tiles);

            int penguinNum = integerStream.Read();
            for (int curPen = 0; curPen < penguinNum; curPen++)
            {
                int pen_r = integerStream.Read();
                int pen_c = integerStream.Read();
                int pen_type = integerStream.Read();
                int pen_direction = integerStream.Read();
                PenguinManager.GetInst().MakePenguin(
                    pen_r,
                    pen_c,
                    (Penguin.PenguinType)pen_type,
                    (Penguin.Direction)pen_direction);
            }
            
        }
        catch (System.Exception e)
        {
            Debug.LogError(fileName + " 을 읽는 데에 실패하였습니다.");
            Debug.LogError(e.Message);
            Debug.LogError(e.StackTrace);
        }
    }

    public Vector3 GetTileLocalPosition(int rowPos, int colPos)
    {
        return new Vector3(colPos, _map.GetHeight() - 1 - rowPos, 0);
    }

    public void SetTile(int r, int c, Tile.TileType tileType)
    {
        _map.GetTile(r, c)._type = tileType;
        GetTileObject(r, c).SetTile(tileType);
    }
    public bool IsTileOutOfBounds(int r, int c)
    {
        bool ret = r < 0 || r >= _map.GetHeight();
        ret |= c < 0 || c >= _map.GetWidth();
        return ret;
    }
    public Tile GetTile(int r, int c)
    {
        return _map.GetTile(r, c);
    }
    public TileObject GetTileObject(int r, int c)
    {
        return _tileObjects[r][c];
    }
    // todo: tileObject 와 실제 tile 간의 관계 가능하다면 개선
    protected Map _map;
    protected List<List<TileObject>> _tileObjects;

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
